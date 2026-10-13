using EjemploRazorPages.Data;

// crea el constructor de la aplicacion web
var builder = WebApplication.CreateBuilder(args);

// registra el soporte de razor pages
builder.Services.AddRazorPages();
// registra el repositorio como singleton: una sola copia de los datos
builder.Services.AddSingleton<RepositorioLibros>();

// construye la aplicacion
var app = builder.Build();

// sirve los archivos estaticos de wwwroot (css, js, imagenes)
app.UseStaticFiles();
// activa el enrutamiento
app.UseRouting();
// conecta las razor pages (sus rutas salen de donde esta cada archivo)
app.MapRazorPages();

// arranca el servidor web
app.Run();
