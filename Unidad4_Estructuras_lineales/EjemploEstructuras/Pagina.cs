namespace EjemploEstructuras
{
    // Objeto para la LISTA DOBLE: una página visitada en el navegador.
    public class Pagina
    {
        public string Url { get; set; }
        public Pagina(string url) { Url = url; }
        public override string ToString() => Url;
    }
}
