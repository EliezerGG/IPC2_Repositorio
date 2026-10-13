using System.Collections.Generic;
using System.Linq;
using EjemploRazorPages.Models;

namespace EjemploRazorPages.Data
{
    // repositorio: guarda los libros en memoria y ofrece las operaciones.
    // se registra como singleton para que los datos duren mientras corre el server.
    public class RepositorioLibros
    {
        // lista con tres libros de ejemplo al iniciar
        private readonly List<Libro> _libros = new List<Libro>
        {
            // un libro disponible
            new Libro { Id = 1, Titulo = "El Quijote", Autor = "Cervantes", Disponible = true },
            // un libro prestado
            new Libro { Id = 2, Titulo = "La Odisea", Autor = "Homero", Disponible = false },
            // otro libro disponible
            new Libro { Id = 3, Titulo = "Fahrenheit 451", Autor = "Bradbury", Disponible = true }
        };
        // guarda el siguiente id disponible
        private int _siguienteId = 4;

        // devuelve todos los libros
        public List<Libro> ObtenerTodos()
        {
            // entrega la lista completa
            return _libros;
        }

        // agrega un libro nuevo con el titulo y el autor recibidos
        public void Agregar(string titulo, string autor)
        {
            // crea el libro (empieza disponible) y lo agrega a la lista
            _libros.Add(new Libro { Id = _siguienteId, Titulo = titulo, Autor = autor, Disponible = true });
            // aumenta el id para el proximo libro
            _siguienteId++;
        }

        // alterna el libro entre disponible y prestado
        public void Alternar(int id)
        {
            // busca el libro por su id
            var libro = _libros.FirstOrDefault(l => l.Id == id);
            // si existe, invierte su disponibilidad
            if (libro != null) libro.Disponible = !libro.Disponible;
        }

        // elimina el libro con el id indicado
        public void Eliminar(int id)
        {
            // quita de la lista los libros con ese id
            _libros.RemoveAll(l => l.Id == id);
        }
    }
}
