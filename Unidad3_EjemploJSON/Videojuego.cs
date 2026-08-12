using System.Collections.Generic;

namespace EjemploJSON
{
    // Modelo que refleja cada objeto del arreglo "videojuegos" del JSON.
    // Las propiedades tienen el mismo nombre que las claves (System.Text.Json
    // las empareja automáticamente si activamos PropertyNameCaseInsensitive).
    public class Videojuego
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Anio { get; set; }
        public double Precio { get; set; }
        public bool Multijugador { get; set; }

        // Puede venir como null en el JSON (juego aún sin calificar),
        // por eso el tipo es double? (double que admite valor nulo).
        public double? Calificacion { get; set; }

        // Un arreglo JSON [ ] se mapea a una lista de C#.
        public List<string> Plataformas { get; set; }

        public override string ToString()
        {
            string precio = Precio == 0 ? "Gratis" : $"Q{Precio:0.00}";
            string calif = Calificacion.HasValue ? Calificacion.Value.ToString("0.0") : "sin calificar";
            string modo = Multijugador ? "Multijugador" : "Un jugador";
            string plataformas = string.Join(", ", Plataformas);
            return $"[{Id}] {Titulo} ({Anio}) — {Genero} — {precio} — {modo} — Calif: {calif} — {plataformas}";
        }
    }
}
