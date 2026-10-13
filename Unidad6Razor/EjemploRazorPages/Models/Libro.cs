namespace EjemploRazorPages.Models
{
    // modelo: representa un libro del catalogo
    public class Libro
    {
        // identificador unico del libro
        public int Id { get; set; }
        // titulo del libro
        public string Titulo { get; set; }
        // autor del libro
        public string Autor { get; set; }
        // indica si el libro esta disponible (no prestado)
        public bool Disponible { get; set; }
    }
}
