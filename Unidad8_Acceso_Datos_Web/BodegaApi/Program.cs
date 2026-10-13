using BodegaApi.Datos;
using BodegaApi.Endpoints;
using BodegaApi.Servicios;

// el constructor prepara la configuracion y el contenedor de servicios
var builder = WebApplication.CreateBuilder(args);

// el archivo de la base de datos queda junto al proyecto
string rutaBd = Path.Combine(builder.Environment.ContentRootPath, "bodega.db");

// un solo repositorio para toda la aplicacion
builder.Services.AddSingleton(new BodegaRepositorio($"Data Source={rutaBd}"));
// el procesador recibe el repositorio por inyeccion
builder.Services.AddSingleton<ProcesadorMovimientos>();

// construimos la aplicacion con todo lo registrado
var app = builder.Build();

// creamos las tablas y los datos de ejemplo antes de recibir peticiones
app.Services.GetRequiredService<BodegaRepositorio>().Inicializar();

// sirve wwwroot/index.html cuando se abre la raiz del sitio
app.UseDefaultFiles();
// sirve los archivos estaticos de wwwroot: html, css y js
app.UseStaticFiles();

// registramos las rutas de la api
app.MapearProductos();
app.MapearMovimientos();
app.MapearAdministracion();

// arranca el servidor y espera peticiones
app.Run();
