using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace EjemploXML
{
    // Se encarga de LEER el archivo XML y convertirlo en objetos Estudiante.
    // Demuestra: XDocument.Load, navegación del árbol y consultas LINQ.
    public class LectorXml
    {
        private readonly XDocument _doc;

        public LectorXml(string ruta)
        {
            // Carga el archivo desde disco y arma el árbol en memoria.
            _doc = XDocument.Load(ruta);
        }

        // Recorre el árbol y crea un Estudiante por cada elemento <estudiante>.
        public List<Estudiante> LeerEstudiantes()
        {
            List<Estudiante> lista = new List<Estudiante>();

            // .Root es <estudiantes>; .Elements("estudiante") son sus hijos directos.
            foreach (XElement e in _doc.Root.Elements("estudiante"))
            {
                Estudiante est = new Estudiante
                {
                    // Atributo id="..."  → se lee con .Attribute(...)
                    Id = (int)e.Attribute("id"),
                    // Elementos hijos → se leen con .Element(...)
                    Nombre = e.Element("nombre").Value,
                    Carnet = e.Element("carnet").Value,
                    // El cast (double) convierte el texto "85" al número 85.
                    Nota = (double)e.Element("nota")
                };
                lista.Add(est);
            }

            return lista;
        }

        // Ejemplo de consulta LINQ directamente sobre el árbol XML:
        // devuelve solo los nombres de quienes aprobaron (nota >= 61).
        public IEnumerable<string> NombresAprobados()
        {
            return from e in _doc.Descendants("estudiante")
                   where (double)e.Element("nota") >= 61
                   orderby (double)e.Element("nota") descending
                   select e.Element("nombre").Value;
        }

        // Metadato leído de un atributo del elemento raíz.
        public string Curso => _doc.Root.Attribute("curso")?.Value ?? "(desconocido)";
    }
}
