namespace EjemploEstructuras
{
    // Objeto para la COLA: un turno de atención con número y cliente.
    public class Turno
    {
        public int Numero { get; set; }
        public string Cliente { get; set; }
        public Turno(int numero, string cliente) { Numero = numero; Cliente = cliente; }
        public override string ToString() => $"Turno #{Numero} - {Cliente}";
    }
}
