using BodegaApi.Datos;
using BodegaApi.Modelos;

namespace BodegaApi.Endpoints;

// rutas relacionadas con los productos
public static class ProductosEndpoints
{
    // metodo de extension: se llama desde el archivo de arranque
    public static void MapearProductos(this IEndpointRouteBuilder app)
    {
        // todas las rutas de este grupo empiezan con /api/productos
        var grupo = app.MapGroup("/api/productos");

        // get de la lista completa
        grupo.MapGet("/", (BodegaRepositorio repo) =>
        {
            // abrimos la conexion y la cerramos al salir del bloque
            using var con = repo.Abrir();
            // 200 con la lista convertida a json
            return Results.Ok(repo.ListarProductos(con));
        });

        // get de un producto por codigo
        grupo.MapGet("/{codigo}", (string codigo, BodegaRepositorio repo) =>
        {
            using var con = repo.Abrir();
            // normalizamos el codigo igual que al guardarlo
            Producto? p = repo.ObtenerProducto(con, codigo.Trim().ToUpperInvariant());
            // 404 si no existe, 200 si existe
            return p is null ? Error(404, $"no existe el producto {codigo}") : Results.Ok(p);
        });

        // post: crea un producto nuevo con el json recibido
        grupo.MapPost("/", (Producto nuevo, BodegaRepositorio repo) =>
        {
            // limpiamos y normalizamos lo que llego
            string codigo = (nuevo.Codigo ?? "").Trim().ToUpperInvariant();
            string nombre = (nuevo.Nombre ?? "").Trim();

            // validaciones: cada una responde 400 con un mensaje claro
            if (codigo.Length == 0 || codigo.Length > 20) return Error(400, "el codigo es obligatorio y admite hasta 20 caracteres");
            if (nombre.Length == 0 || nombre.Length > 80) return Error(400, "el nombre es obligatorio y admite hasta 80 caracteres");
            if (nuevo.Stock < 0) return Error(400, "el stock no puede ser negativo");
            if (nuevo.StockMinimo < 0) return Error(400, "el stock minimo no puede ser negativo");

            using var con = repo.Abrir();

            // 409 si el codigo ya esta registrado
            if (repo.ObtenerProducto(con, codigo) != null) return Error(409, $"ya existe el producto {codigo}");

            // guardamos con los valores normalizados
            var producto = new Producto { Codigo = codigo, Nombre = nombre, Stock = nuevo.Stock, StockMinimo = nuevo.StockMinimo };
            repo.InsertarProducto(con, null, producto);

            // 201 con la direccion del recurso creado en la cabecera location
            return Results.Created($"/api/productos/{codigo}", producto);
        });
    }

    // arma una respuesta de error con el mismo formato en toda la api
    private static IResult Error(int estado, string mensaje)
    {
        return Results.Json(new { error = mensaje }, statusCode: estado);
    }
}
