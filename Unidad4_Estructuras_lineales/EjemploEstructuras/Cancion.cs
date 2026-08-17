namespace EjemploEstructuras
{
    // Objeto para la LISTA SIMPLE: una canción de una playlist.
    public class Cancion
    {
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public int DuracionSegundos { get; set; }
        public Cancion(string titulo, string artista, int duracionSegundos)
        {
            Titulo = titulo; Artista = artista; DuracionSegundos = duracionSegundos;
        }
        public override string ToString()
        {
            int min = DuracionSegundos / 60;
            int seg = DuracionSegundos % 60;
            return $"{Titulo} — {Artista} ({min}:{seg:D2})";
        }
    }
}
