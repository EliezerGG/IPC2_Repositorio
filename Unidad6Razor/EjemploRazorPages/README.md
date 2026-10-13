# EjemploRazorPages — Catálogo de Libros con Razor Pages

Una aplicación de **Razor Pages** (ASP.NET Core): un catálogo de libros donde se
pueden ver, agregar, prestar/devolver y eliminar libros. Usa el modelo *basado
en páginas*: cada página tiene su HTML (`.cshtml`) y su código al lado
(`.cshtml.cs`, el PageModel).

Los comentarios del código están en minúsculas, sin tildes y sin "ñ".

## Estructura

```
EjemploRazorPages/
├─ Program.cs                       (configura Razor Pages)
├─ Models/
│  └─ Libro.cs                      (el modelo: Titulo, Autor, Disponible)
├─ Data/
│  └─ RepositorioLibros.cs          (los libros en memoria)
├─ Pages/
│  ├─ _ViewImports.cshtml           (usings, namespace y tag helpers)
│  ├─ _ViewStart.cshtml             (fija el layout)
│  ├─ Shared/_Layout.cshtml         (la plantilla comun)
│  ├─ Index.cshtml (+ .cs)          (inicio: redirige al catalogo)
│  └─ Libros/
│     ├─ Index.cshtml               (la pagina del catalogo)
│     └─ Index.cshtml.cs            (el PageModel con los handlers)
└─ wwwroot/
   └─ estilos.css                   (los estilos)
```

## Cómo ejecutarlo

```bash
dotnet run
```

Abre la dirección que muestra la consola (por ejemplo `http://localhost:5000`).
La raíz redirige al catálogo en `/Libros`.

## Conceptos de Razor Pages que usa

- **@page** — convierte la vista en una página que responde a una URL.
- **@model** — enlaza la página con su PageModel.
- **PageModel** — la clase (`IndexModel`) con los datos (`Libros`) y los handlers.
- **Handlers** — `OnGet` (al abrir) y `OnPost` (al enviar el formulario).
- **Handlers con nombre** — `OnPostAlternar` y `OnPostEliminar`, llamados con
  `asp-page-handler="Alternar"` / `"Eliminar"` y `asp-route-id`.
- **[BindProperty]** — llena solas las propiedades `Titulo` y `Autor` con los
  campos del formulario.
- **Enrutamiento por carpetas** — `Pages/Libros/Index.cshtml` responde en
  `/Libros`.
- **Layout y estáticos** — `_Layout.cshtml` con `@RenderBody()` y el CSS en
  `wwwroot`, enlazado con `~/`.

## Cómo funciona una acción (ejemplo: prestar un libro)

1. Haces clic en el botón de estado del libro → se envía un formulario (POST)
   con `asp-page-handler="Alternar"` y el `id` del libro.
2. Razor Pages ejecuta el handler **`OnPostAlternar(int id)`** del PageModel.
3. El PageModel le pide al repositorio alternar el libro y hace
   `RedirectToPage()` para recargar la página con el nuevo estado.

## Relación con MVC

Es la misma idea que el ejemplo de MVC, pero sin controlador aparte: el código
de la página vive a su lado, en el PageModel. Para páginas y formularios como
este, Razor Pages suele ser más directo.

## Nota

En este entorno no había `dotnet` para compilar, así que la lógica del
repositorio se verificó reproduciéndola de forma equivalente y se revisó que las
páginas y los PageModels estén bien formados. El código está escrito para correr
con `dotnet run`. La imagen `preview.png` representa la página que genera Razor.
