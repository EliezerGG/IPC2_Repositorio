namespace EjemploLaberinto
{
    // Una celda del laberinto: su posición (1-based) y su tipo.
    // tipo ∈ { pared, camino, entrada, salida }.
    public class Celda
    {
        public int Fila { get; set; }
        public int Columna { get; set; }
        public string Tipo { get; set; }

        public Celda(int fila, int columna, string tipo)
        {
            Fila = fila;
            Columna = columna;
            Tipo = tipo;
        }

        public bool EsPared => Tipo == "pared";
        public bool EsCamino => Tipo == "camino";
        public bool EsEntrada => Tipo == "entrada";
        public bool EsSalida => Tipo == "salida";

        // Símbolo para mostrar el laberinto en la consola.
        public char Simbolo()
        {
            if (EsPared) return '#';
            if (EsEntrada) return 'E';
            if (EsSalida) return 'S';
            return '.'; // camino
        }
    }
}
