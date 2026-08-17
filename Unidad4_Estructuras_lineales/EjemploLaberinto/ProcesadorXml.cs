using System.Xml.Linq;

namespace EjemploLaberinto
{
    // Lee y escribe el laberinto en XML usando XDocument (Unidad 3).
    public class ProcesadorXml
    {
        public Laberinto CargarDesdeXml(string ruta)
        {
            XDocument doc = XDocument.Load(ruta);
            XElement raiz = doc.Root;

            int filas = (int)raiz.Attribute("filas");
            int columnas = (int)raiz.Attribute("columnas");

            Laberinto laberinto = new Laberinto(filas, columnas);

            foreach (XElement e in raiz.Elements("celda"))
            {
                int fila = (int)e.Attribute("fila");
                int col = (int)e.Attribute("columna");
                string tipo = (string)e.Attribute("tipo");
                laberinto.Celdas.Insertar(new Celda(fila, col, tipo));
            }

            return laberinto;
        }

        public void GuardarEnXml(Laberinto laberinto, string ruta)
        {
            XElement raiz = new XElement("laberinto",
                new XAttribute("filas", laberinto.Filas),
                new XAttribute("columnas", laberinto.Columnas));

            foreach (Celda c in laberinto.Celdas)
            {
                raiz.Add(new XElement("celda",
                    new XAttribute("fila", c.Fila),
                    new XAttribute("columna", c.Columna),
                    new XAttribute("tipo", c.Tipo)));
            }

            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                raiz);
            doc.Save(ruta);
        }
    }
}
