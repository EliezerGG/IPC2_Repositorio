using System.Text;

namespace EjemploLaberinto
{
    // El laberinto guarda sus dimensiones y sus celdas dentro del TDA propio.
    public class Laberinto
    {
        public int Filas { get; set; }
        public int Columnas { get; set; }
        public ListaCeldas Celdas { get; set; }

        public Laberinto(int filas, int columnas)
        {
            Filas = filas;
            Columnas = columnas;
            Celdas = new ListaCeldas();
        }

        // Devuelve la celda en (fila, columna). Si no existe, se asume pared.
        public Celda CeldaEn(int fila, int columna)
        {
            Celda c = Celdas.Buscar(fila, columna);
            return c ?? new Celda(fila, columna, "pared");
        }

        // Dibuja el laberinto en texto: # pared, . camino, E entrada, S salida.
        public string ComoTexto()
        {
            StringBuilder sb = new StringBuilder();
            for (int f = 1; f <= Filas; f++)
            {
                for (int c = 1; c <= Columnas; c++)
                {
                    sb.Append(CeldaEn(f, c).Simbolo());
                    sb.Append(' ');
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}