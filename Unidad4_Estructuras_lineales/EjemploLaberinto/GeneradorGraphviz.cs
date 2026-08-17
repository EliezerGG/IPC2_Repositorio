using System.IO;
using System.Text;

namespace EjemploLaberinto
{
    // Genera el .dot del laberinto como una CUADRÍCULA de cuadros pegados,
    // usando una etiqueta tipo tabla HTML de Graphviz.
    // La clave es CELLSPACING="0": elimina la separación entre celdas, así
    // los cuadros quedan juntos formando el mapa (distinto a nodos con aristas).
    public class GeneradorGraphviz
    {
        private const int Lado = 34; // tamaño de cada cuadro en píxeles

        public string GenerarDot(Laberinto lab)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("digraph Laberinto {");
            sb.AppendLine("  bgcolor=\"white\";");
            sb.AppendLine("  node [shape=plaintext];");
            sb.AppendLine();
            sb.AppendLine("  mapa [label=<");
            sb.AppendLine("    <TABLE BORDER=\"0\" CELLBORDER=\"1\" CELLSPACING=\"0\" COLOR=\"#B0B0B0\">");

            for (int f = 1; f <= lab.Filas; f++)
            {
                sb.Append("      <TR>");
                for (int c = 1; c <= lab.Columnas; c++)
                {
                    Celda celda = lab.CeldaEn(f, c);
                    string color = ColorDe(celda);
                    string contenido = ContenidoDe(celda);
                    sb.Append($"<TD BGCOLOR=\"{color}\" WIDTH=\"{Lado}\" HEIGHT=\"{Lado}\" FIXEDSIZE=\"TRUE\">{contenido}</TD>");
                }
                sb.AppendLine("</TR>");
            }

            sb.AppendLine("    </TABLE>");
            sb.AppendLine("  >];");
            sb.AppendLine("}");
            return sb.ToString();
        }

        public void GuardarDot(Laberinto lab, string ruta)
        {
            File.WriteAllText(ruta, GenerarDot(lab));
        }

        // Color de fondo de cada cuadro según el tipo de celda.
        private string ColorDe(Celda c)
        {
            if (c.EsPared) return "#1B4F72";    // azul oscuro
            if (c.EsEntrada) return "#1E8449";  // verde
            if (c.EsSalida) return "#E87722";   // naranja
            return "#FFFFFF";                    // camino: blanco
        }

        // La entrada y la salida muestran una letra; lo demás va vacío.
        private string ContenidoDe(Celda c)
        {
            if (c.EsEntrada) return "<FONT COLOR=\"white\"><B>E</B></FONT>";
            if (c.EsSalida) return "<FONT COLOR=\"white\"><B>S</B></FONT>";
            return " ";
        }
    }
}
