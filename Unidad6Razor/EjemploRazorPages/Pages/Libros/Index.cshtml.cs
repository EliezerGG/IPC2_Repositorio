using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EjemploRazorPages.Data;
using EjemploRazorPages.Models;

namespace EjemploRazorPages.Pages.Libros
{
    // pagemodel: el codigo de c# que acompana a la pagina del catalogo.
    // hereda de la clase base de paginas y guarda sus datos y handlers.
    public class IndexModel : PageModel
    {
        // referencia al repositorio (los datos)
        private readonly RepositorioLibros _repo;

        // el repositorio llega por inyeccion de dependencias
        public IndexModel(RepositorioLibros repo)
        {
            // guarda el repositorio recibido
            _repo = repo;
        }

        // la lista de libros que la pagina va a mostrar
        public List<Libro> Libros { get; set; }

        // se llenan solos con los campos del formulario al hacer post
        [BindProperty] public string Titulo { get; set; }
        [BindProperty] public string Autor { get; set; }

        // handler get: se ejecuta al abrir la pagina; prepara los libros
        public void OnGet()
        {
            // pide todos los libros al repositorio
            Libros = _repo.ObtenerTodos();
        }

        // handler post por defecto: agrega un libro nuevo
        public IActionResult OnPost()
        {
            // solo si llego un titulo valido
            if (!string.IsNullOrWhiteSpace(Titulo))
            {
                // pide al repositorio agregar el libro
                _repo.Agregar(Titulo, Autor);
            }
            // recarga la pagina (patron post-redirect-get)
            return RedirectToPage();
        }

        // handler con nombre: alterna el libro entre disponible y prestado
        public IActionResult OnPostAlternar(int id)
        {
            // pide al repositorio alternar el libro
            _repo.Alternar(id);
            // recarga la pagina
            return RedirectToPage();
        }

        // handler con nombre: elimina un libro del catalogo
        public IActionResult OnPostEliminar(int id)
        {
            // pide al repositorio eliminar el libro
            _repo.Eliminar(id);
            // recarga la pagina
            return RedirectToPage();
        }
    }
}
