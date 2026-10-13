using BodegaApi.Datos;
using BodegaApi.Modelos;
using Microsoft.Data.Sqlite;

namespace BodegaApi.Servicios;

// aqui vive la logica de negocio: validar el json, aplicar la regla de stock y guardar
public class ProcesadorMovimientos
{
    // acceso a la base de datos
    private readonly BodegaRepositorio _repo;

    // el repositorio llega por inyeccion de dependencias
    public ProcesadorMovimientos(BodegaRepositorio repo)
    {
        _repo = repo;
    }

    // procesa un solo movimiento dentro de su propia transaccion
    public ResultadoMovimiento ProcesarUno(MovimientoSolicitud? solicitud)
    {
        // una conexion y una transaccion para este movimiento
        using var con = _repo.Abrir();
        using var tx = con.BeginTransaction();

        // aplicamos la regla de negocio
        ResultadoMovimiento r = Aplicar(con, tx, solicitud);

        // si salio bien confirmamos; si no, deshacemos todo
        if (r.Exito) tx.Commit(); else tx.Rollback();
        return r;
    }

    // procesa varios movimientos: o se aplican todos o no se aplica ninguno
    public ResultadoLote ProcesarLote(LoteSolicitud lote)
    {
        // un lote sin movimientos no tiene sentido
        if (lote.Movimientos is null || lote.Movimientos.Count == 0)
            return ResultadoLote.Falla(400, "el lote no trae movimientos");

        // limite para que una sola peticion no sea gigante
        if (lote.Movimientos.Count > 100)
            return ResultadoLote.Falla(400, "el lote admite hasta 100 movimientos");

        // una sola conexion y una sola transaccion para todo el lote
        using var con = _repo.Abrir();
        using var tx = con.BeginTransaction();

        var resumen = new ResumenLote();
        int numero = 0;

        foreach (MovimientoSolicitud? m in lote.Movimientos)
        {
            // el numero sirve para decirle al cliente cual movimiento fallo
            numero++;
            ResultadoMovimiento r = Aplicar(con, tx, m);

            if (!r.Exito)
            {
                // un fallo deshace los movimientos anteriores del lote
                tx.Rollback();
                return ResultadoLote.Falla(r.Estado, $"movimiento {numero}: {r.Error}");
            }

            // acumulamos los totales del resumen
            resumen.Procesados++;
            if (r.Datos!.Tipo == "entrada") resumen.UnidadesEntrada += r.Datos.Cantidad;
            else resumen.UnidadesSalida += r.Datos.Cantidad;
            resumen.Movimientos.Add(r.Datos);
        }

        // las alertas se calculan con el stock final, no con el de cada paso
        foreach (MovimientoResultado d in resumen.Movimientos)
        {
            // si el codigo ya esta marcado no lo revisamos otra vez
            if (resumen.ProductosEnAlerta.Contains(d.Codigo)) continue;
            Producto? p = _repo.ObtenerProducto(con, d.Codigo, tx);
            if (p != null && p.Stock <= p.StockMinimo) resumen.ProductosEnAlerta.Add(d.Codigo);
        }

        // todo salio bien: confirmamos la transaccion
        tx.Commit();
        return ResultadoLote.Correcto(resumen);
    }

    // valida y aplica un movimiento usando la conexion y transaccion recibidas
    private ResultadoMovimiento Aplicar(SqliteConnection con, SqliteTransaction tx, MovimientoSolicitud? s)
    {
        // primero validamos la forma del json
        string? error = Validar(s);
        if (error != null) return ResultadoMovimiento.Falla(400, error);

        // normalizamos para que el codigo en minusculas y en mayusculas sea el mismo
        string codigo = s!.Codigo!.Trim().ToUpperInvariant();
        string tipo = s.Tipo!.Trim().ToLowerInvariant();

        // el producto debe existir
        Producto? p = _repo.ObtenerProducto(con, codigo, tx);
        if (p is null) return ResultadoMovimiento.Falla(404, $"no existe el producto {codigo}");

        // calculamos el stock que quedaria
        int stockAnterior = p.Stock;
        int stockNuevo = tipo == "entrada" ? stockAnterior + s.Cantidad : stockAnterior - s.Cantidad;

        // regla de negocio: no se puede sacar mas de lo que hay
        if (stockNuevo < 0)
            return ResultadoMovimiento.Falla(409, $"stock insuficiente en {codigo}: hay {stockAnterior} y se piden {s.Cantidad}");

        // guardamos el nuevo stock y el movimiento en el historial
        _repo.ActualizarStock(con, tx, codigo, stockNuevo);
        long id = _repo.InsertarMovimiento(con, tx, codigo, tipo, s.Cantidad, s.Motivo);

        // armamos la respuesta, con la alerta de reposicion incluida
        return ResultadoMovimiento.Correcto(new MovimientoResultado
        {
            Id = id,
            Codigo = codigo,
            Tipo = tipo,
            Cantidad = s.Cantidad,
            StockAnterior = stockAnterior,
            StockNuevo = stockNuevo,
            AlertaReposicion = stockNuevo <= p.StockMinimo
        });
    }

    // devuelve un mensaje de error o null si el movimiento es valido
    private static string? Validar(MovimientoSolicitud? s)
    {
        // un elemento nulo dentro de un lote
        if (s is null) return "el movimiento viene vacio";
        // el codigo es obligatorio
        if (string.IsNullOrWhiteSpace(s.Codigo)) return "falta el codigo del producto";
        // el tipo solo puede ser uno de dos valores
        string tipo = (s.Tipo ?? "").Trim().ToLowerInvariant();
        if (tipo != "entrada" && tipo != "salida") return "el tipo debe ser entrada o salida";
        // la cantidad debe ser positiva y razonable
        if (s.Cantidad <= 0) return "la cantidad debe ser mayor que cero";
        if (s.Cantidad > 100000) return "la cantidad maxima por movimiento es 100000";
        // el motivo es opcional pero con limite de largo
        if (s.Motivo != null && s.Motivo.Length > 100) return "el motivo admite hasta 100 caracteres";
        return null;
    }
}
