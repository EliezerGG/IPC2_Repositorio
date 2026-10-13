using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjemploRazorPages.Pages
{
    // pagina de inicio ("/"): manda al usuario al catalogo de libros.
    public class IndexModel : PageModel
    {
        // al abrir la raiz, redirige a la pagina del catalogo
        public IActionResult OnGet()
        {
            // envia a la pagina del catalogo de libros
            return RedirectToPage("/Libros/Index");
        }
    }
}
