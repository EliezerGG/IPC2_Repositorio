namespace EjemploAVL
{
    // clase que representa un ticket de soporte
    public class Ticket
    {
        // numero unico del ticket (es la clave del arbol)
        public int Numero { get; set; }

        // asunto o descripcion corta del ticket
        public string Asunto { get; set; }

        // prioridad del ticket (alta, media, baja)
        public string Prioridad { get; set; }

        // constructor: recibe los tres datos del ticket
        public Ticket(int numero, string asunto, string prioridad)
        {
            Numero = numero;         // guarda el numero recibido
            Asunto = asunto;         // guarda el asunto recibido
            Prioridad = prioridad;   // guarda la prioridad recibida
        }

        // devuelve el ticket como texto legible
        public override string ToString()
        {
            // arma una linea con numero, asunto y prioridad
            return $"#{Numero} - {Asunto} (prioridad: {Prioridad})";
        }
    }
}
