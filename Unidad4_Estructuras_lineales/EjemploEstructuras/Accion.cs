namespace EjemploEstructuras
{
    // Objeto para la PILA: una acción que el usuario puede deshacer.
    public class Accion
    {
        public string Descripcion { get; set; }
        public Accion(string descripcion) { Descripcion = descripcion; }
        public override string ToString() => Descripcion;
    }
}
