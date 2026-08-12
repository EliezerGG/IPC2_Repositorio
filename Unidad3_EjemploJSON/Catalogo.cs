using System.Collections.Generic;

namespace EjemploJSON
{
    // Refleja el OBJETO raíz del JSON: tiene metadatos (tienda, moneda)
    // y un arreglo de videojuegos. Así se mapea un objeto que contiene
    // a su vez un arreglo de objetos (estructura anidada).
    public class Catalogo
    {
        public string Tienda { get; set; }
        public string Moneda { get; set; }
        public List<Videojuego> Videojuegos { get; set; }
    }
}
