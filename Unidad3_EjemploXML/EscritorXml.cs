using System.Collections.Generic;
using System.Xml.Linq;

namespace EjemploXML
{
    // Se encarga de CREAR y GUARDAR un nuevo archivo XML desde código.
    // Demuestra: construcción del árbol con XElement / XAttribute y .Save().
    public class EscritorXml
    {
        // Genera un XML solo con los estudiantes aprobados y lo guarda en 'ruta'.
        public void GuardarAprobados(List<Estudiante> estudiantes, string ruta)
        {
            XElement raiz = new XElement("aprobados");

            foreach (Estudiante est in estudiantes)
            {
                if (!est.Aprobado)
                {
                    continue;
                }

                // Cada estudiante se arma anidando XElement y XAttribute.
                XElement nodo = new XElement("estudiante",
                    new XAttribute("id", est.Id),
                    new XElement("nombre", est.Nombre),
                    new XElement("carnet", est.Carnet),
                    new XElement("nota", est.Nota)
                );

                raiz.Add(nodo);
            }

            // Envolvemos en un XDocument para incluir el prólogo <?xml ...?>.
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                raiz
            );

            doc.Save(ruta);
        }
    }
}
