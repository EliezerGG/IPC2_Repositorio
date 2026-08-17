namespace EjemploEstructuras
{
    // Objeto para la LISTA CIRCULAR: un jugador en un juego por turnos.
    public class Jugador
    {
        public string Nombre { get; set; }
        public Jugador(string nombre) { Nombre = nombre; }
        public override string ToString() => Nombre;
    }
}
