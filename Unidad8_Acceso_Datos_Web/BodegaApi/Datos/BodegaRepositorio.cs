using BodegaApi.Modelos;
using Microsoft.Data.Sqlite;

namespace BodegaApi.Datos;

// concentra todo el acceso a sqlite: ningun otro archivo escribe sql
public class BodegaRepositorio
{
    // cadena de conexion, por ejemplo: data source=bodega.db
    private readonly string _cadenaConexion;

    // recibe la cadena de conexion desde el archivo de arranque
    public BodegaRepositorio(string cadenaConexion)
    {
        // la guardamos para usarla cada vez que abramos una conexion
        _cadenaConexion = cadenaConexion;
    }

    // abre una conexion nueva; quien la pide la cierra con using
    public SqliteConnection Abrir()
    {
        // creamos la conexion con la cadena guardada
        var con = new SqliteConnection(_cadenaConexion);
        // la abrimos antes de devolverla
        con.Open();
        return con;
    }

    // crea las tablas si no existen y carga datos de ejemplo la primera vez
    public void Inicializar()
    {
        // una conexion solo para preparar la base
        using var con = Abrir();

        // tabla de productos: el codigo es la llave primaria y el stock nunca baja de cero
        Ejecutar(con, null, @"CREATE TABLE IF NOT EXISTS productos (
                codigo TEXT PRIMARY KEY,
                nombre TEXT NOT NULL,
                stock INTEGER NOT NULL CHECK (stock >= 0),
                stock_minimo INTEGER NOT NULL CHECK (stock_minimo >= 0))");

        // tabla de movimientos: cada fila apunta a un producto
        Ejecutar(con, null, @"CREATE TABLE IF NOT EXISTS movimientos (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                codigo TEXT NOT NULL REFERENCES productos(codigo),
                tipo TEXT NOT NULL CHECK (tipo IN ('entrada', 'salida')),
                cantidad INTEGER NOT NULL CHECK (cantidad > 0),
                motivo TEXT,
                fecha TEXT NOT NULL)");

        // contamos los productos para saber si es la primera vez
        long total;
        using (var cmd = Comando(con, null, "SELECT COUNT(*) FROM productos"))
        {
            total = Convert.ToInt64(cmd.ExecuteScalar());
        }

        // si ya hay datos no cargamos nada mas
        if (total > 0) return;

        // primera vez: cargamos los datos de ejemplo para poder probar de inmediato
        CargarEjemplo(con, null);
    }

    // borra todos los datos y, si se pide, vuelve a cargar los de ejemplo
    public void Reiniciar(bool conEjemplo)
    {
        using var con = Abrir();
        // todo en una transaccion: o se borra y se recarga completo, o no cambia nada
        using var tx = con.BeginTransaction();

        // primero los movimientos, porque cada uno apunta a un producto
        Ejecutar(con, tx, "DELETE FROM movimientos");
        Ejecutar(con, tx, "DELETE FROM productos");
        // el contador de ids vuelve a empezar en 1
        Ejecutar(con, tx, "DELETE FROM sqlite_sequence WHERE name = 'movimientos'");

        // los datos de ejemplo son opcionales
        if (conEjemplo) CargarEjemplo(con, tx);

        tx.Commit();
    }

    // inserta los cinco repuestos de ejemplo
    private void CargarEjemplo(SqliteConnection con, SqliteTransaction? tx)
    {
        InsertarProducto(con, tx, new Producto { Codigo = "REP-001", Nombre = "Filtro de aceite", Stock = 25, StockMinimo = 10 });
        InsertarProducto(con, tx, new Producto { Codigo = "REP-002", Nombre = "Pastillas de freno", Stock = 8, StockMinimo = 10 });
        InsertarProducto(con, tx, new Producto { Codigo = "REP-003", Nombre = "Bujia estandar", Stock = 60, StockMinimo = 20 });
        InsertarProducto(con, tx, new Producto { Codigo = "REP-004", Nombre = "Bateria 12V", Stock = 5, StockMinimo = 3 });
        InsertarProducto(con, tx, new Producto { Codigo = "REP-005", Nombre = "Faja de motor", Stock = 12, StockMinimo = 5 });
    }

    // devuelve todos los productos ordenados por codigo
    public List<Producto> ListarProductos(SqliteConnection con)
    {
        // la lista que vamos a llenar
        var lista = new List<Producto>();
        // consulta sin parametros
        using var cmd = Comando(con, null, "SELECT codigo, nombre, stock, stock_minimo FROM productos ORDER BY codigo");
        // el lector recorre fila por fila
        using var lector = cmd.ExecuteReader();
        while (lector.Read())
        {
            // cada fila se convierte en un objeto
            lista.Add(LeerProducto(lector));
        }
        return lista;
    }

    // busca un producto por codigo; devuelve null si no existe
    public Producto? ObtenerProducto(SqliteConnection con, string codigo, SqliteTransaction? tx = null)
    {
        // consulta con un parametro para evitar inyeccion de sql
        using var cmd = Comando(con, tx, "SELECT codigo, nombre, stock, stock_minimo FROM productos WHERE codigo = $codigo");
        cmd.Parameters.AddWithValue("$codigo", codigo);
        using var lector = cmd.ExecuteReader();
        // si hay una fila la convertimos; si no, null
        return lector.Read() ? LeerProducto(lector) : null;
    }

    // inserta un producto nuevo
    public void InsertarProducto(SqliteConnection con, SqliteTransaction? tx, Producto p)
    {
        // los valores viajan como parametros, nunca pegados al texto del sql
        using var cmd = Comando(con, tx, "INSERT INTO productos (codigo, nombre, stock, stock_minimo) VALUES ($codigo, $nombre, $stock, $minimo)");
        cmd.Parameters.AddWithValue("$codigo", p.Codigo!);
        cmd.Parameters.AddWithValue("$nombre", p.Nombre!);
        cmd.Parameters.AddWithValue("$stock", p.Stock);
        cmd.Parameters.AddWithValue("$minimo", p.StockMinimo);
        cmd.ExecuteNonQuery();
    }

    // cambia el stock de un producto
    public void ActualizarStock(SqliteConnection con, SqliteTransaction? tx, string codigo, int nuevoStock)
    {
        // actualizamos solo la fila del codigo indicado
        using var cmd = Comando(con, tx, "UPDATE productos SET stock = $stock WHERE codigo = $codigo");
        cmd.Parameters.AddWithValue("$stock", nuevoStock);
        cmd.Parameters.AddWithValue("$codigo", codigo);
        cmd.ExecuteNonQuery();
    }

    // guarda un movimiento en el historial y devuelve el id que le asigno sqlite
    public long InsertarMovimiento(SqliteConnection con, SqliteTransaction? tx, string codigo, string tipo, int cantidad, string? motivo)
    {
        // la fecha se guarda en utc con formato iso 8601
        string fecha = DateTime.UtcNow.ToString("o");
        using (var cmd = Comando(con, tx, "INSERT INTO movimientos (codigo, tipo, cantidad, motivo, fecha) VALUES ($codigo, $tipo, $cantidad, $motivo, $fecha)"))
        {
            cmd.Parameters.AddWithValue("$codigo", codigo);
            cmd.Parameters.AddWithValue("$tipo", tipo);
            cmd.Parameters.AddWithValue("$cantidad", cantidad);
            // un motivo ausente se guarda como null de base de datos
            cmd.Parameters.AddWithValue("$motivo", (object?)motivo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("$fecha", fecha);
            cmd.ExecuteNonQuery();
        }
        // preguntamos cual fue el ultimo id generado en esta conexion
        using var consulta = Comando(con, tx, "SELECT last_insert_rowid()");
        return Convert.ToInt64(consulta.ExecuteScalar());
    }

    // devuelve los ultimos movimientos, opcionalmente de un solo producto
    public List<MovimientoRegistro> ListarMovimientos(SqliteConnection con, string? codigo, int limite)
    {
        var lista = new List<MovimientoRegistro>();
        // si el codigo es null el filtro no se aplica
        using var cmd = Comando(con, null, "SELECT id, codigo, tipo, cantidad, motivo, fecha FROM movimientos WHERE ($codigo IS NULL OR codigo = $codigo) ORDER BY id DESC LIMIT $limite");
        cmd.Parameters.AddWithValue("$codigo", (object?)codigo ?? DBNull.Value);
        cmd.Parameters.AddWithValue("$limite", limite);
        using var lector = cmd.ExecuteReader();
        while (lector.Read())
        {
            lista.Add(new MovimientoRegistro
            {
                Id = lector.GetInt64(0),
                Codigo = lector.GetString(1),
                Tipo = lector.GetString(2),
                Cantidad = lector.GetInt32(3),
                // el motivo puede ser null en la base de datos
                Motivo = lector.IsDBNull(4) ? null : lector.GetString(4),
                Fecha = lector.GetString(5)
            });
        }
        return lista;
    }

    // convierte la fila actual del lector en un producto
    private static Producto LeerProducto(SqliteDataReader lector)
    {
        // las columnas se leen por posicion, en el orden del select
        return new Producto
        {
            Codigo = lector.GetString(0),
            Nombre = lector.GetString(1),
            Stock = lector.GetInt32(2),
            StockMinimo = lector.GetInt32(3)
        };
    }

    // arma un comando asociado a la conexion y, si existe, a la transaccion
    private static SqliteCommand Comando(SqliteConnection con, SqliteTransaction? tx, string sql)
    {
        var cmd = con.CreateCommand();
        cmd.CommandText = sql;
        // sin esta linea, un comando dentro de una transaccion falla
        cmd.Transaction = tx;
        return cmd;
    }

    // ejecuta una sentencia sin resultados, como create table
    private static void Ejecutar(SqliteConnection con, SqliteTransaction? tx, string sql)
    {
        using var cmd = Comando(con, tx, sql);
        cmd.ExecuteNonQuery();
    }
}
