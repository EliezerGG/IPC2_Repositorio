using BodegaApi.Datos;

namespace BodegaApi.Endpoints;

// rutas de mantenimiento de la base de datos
public static class AdministracionEndpoints
{
    // metodo de extension: se llama desde el archivo de arranque
    public static void MapearAdministracion(this IEndpointRouteBuilder app)
    {
        // post: borra todos los datos; con ?ejemplo=false la base queda vacia
        app.MapPost("/api/reiniciar", (bool? ejemplo, BodegaRepositorio repo) =>
        {
            // si no se indica nada, se cargan los datos de ejemplo
            bool conEjemplo = ejemplo ?? true;

            // borra y recarga dentro de una transaccion
            repo.Reiniciar(conEjemplo);

            // 200 con un mensaje que el frontend puede mostrar
            return Results.Ok(new
            {
                mensaje = conEjemplo ? "datos reiniciados con los productos de ejemplo" : "base de datos vaciada",
                datosDeEjemplo = conEjemplo
            });
        });
    }
}
