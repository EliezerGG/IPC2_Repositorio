using BodegaApi.Datos;
using BodegaApi.Modelos;
using BodegaApi.Servicios;

namespace BodegaApi.Endpoints;

// rutas relacionadas con los movimientos de inventario
public static class MovimientosEndpoints
{
    // metodo de extension: se llama desde el archivo de arranque
    public static void MapearMovimientos(this IEndpointRouteBuilder app)
    {
        // todas las rutas de este grupo empiezan con /api/movimientos
        var grupo = app.MapGroup("/api/movimientos");

        // post: recibe un json con un movimiento y lo procesa
        grupo.MapPost("/", (MovimientoSolicitud solicitud, ProcesadorMovimientos procesador) =>
        {
            // la logica vive en el procesador, el endpoint solo traduce el resultado a http
            ResultadoMovimiento r = procesador.ProcesarUno(solicitud);

            // si hubo error respondemos con el estado que decidio el procesador
            if (!r.Exito) return Results.Json(new { error = r.Error }, statusCode: r.Estado);

            // 201 con el resultado del movimiento
            return Results.Created($"/api/movimientos?codigo={r.Datos!.Codigo}", r.Datos);
        });

        // post: recibe un json con una lista de movimientos y los procesa todos o ninguno
        grupo.MapPost("/lote", (LoteSolicitud lote, ProcesadorMovimientos procesador) =>
        {
            ResultadoLote r = procesador.ProcesarLote(lote);

            // el mensaje de error indica cual movimiento fallo
            if (!r.Exito) return Results.Json(new { error = r.Error }, statusCode: r.Estado);

            // 201 con el resumen del lote
            return Results.Created("/api/movimientos", r.Resumen);
        });

        // get: historial, con filtro opcional por codigo y limite de filas
        grupo.MapGet("/", (string? codigo, int? limite, BodegaRepositorio repo) =>
        {
            // el limite por defecto es 50 y nunca pasa de 200
            int tope = Math.Clamp(limite ?? 50, 1, 200);
            // el codigo se normaliza solo si viene
            string? filtro = string.IsNullOrWhiteSpace(codigo) ? null : codigo.Trim().ToUpperInvariant();

            using var con = repo.Abrir();
            return Results.Ok(repo.ListarMovimientos(con, filtro, tope));
        });
    }
}
