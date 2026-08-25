namespace EjemploArbol
{
    // clase que representa un producto del inventario de la tienda
    public class Producto
    {
        // codigo unico que identifica al producto (es la clave del arbol)
        public int Codigo { get; set; }

        // nombre del producto
        public string Nombre { get; set; }

        // precio del producto en quetzales
        public double Precio { get; set; }

        // constructor: recibe los tres datos del producto
        public Producto(int codigo, string nombre, double precio)
        {
            Codigo = codigo;   // guarda el codigo recibido
            Nombre = nombre;   // guarda el nombre recibido
            Precio = precio;   // guarda el precio recibido
        }

        // devuelve el producto como texto legible
        public override string ToString()
        {
            // arma una linea con codigo, nombre y precio con dos decimales
            return $"[{Codigo}] {Nombre} - Q{Precio:0.00}";
        }
    }
}
