using EjemploMvcCsharp.Data;

// crea el constructor de la aplicacion web
var builder = WebApplication.CreateBuilder(args);

// registra los controladores (la parte que atiende /api/...)
builder.Services.AddControllers();
// registra el repositorio como singleton: una sola copia de los datos
builder.Services.AddSingleton<RepositorioTareas>();

// construye la aplicacion con lo configurado arriba
var app = builder.Build();

// usa index.html como pagina por defecto al entrar a la raiz
app.UseDefaultFiles();
// sirve los archivos estaticos de la carpeta wwwroot (html, css, js)
app.UseStaticFiles();

// conecta las rutas de los controladores de c#
app.MapControllers();

// arranca el servidor web
app.Run();
