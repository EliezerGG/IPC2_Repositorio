using System;
using System.Collections.Generic;
using System.Xml;

namespace EjemploXML
{
    // Punto de entrada: junta la lectura, el recorrido, la consulta LINQ
    // y la escritura, con manejo de errores (try-catch).
    class Program
    {
        static void Main(string[] args)
        {
            const string entrada = "estudiantes.xml";
            const string salida = "aprobados.xml";

            try
            {   
                // ---------- LECTURA ----------
                LectorXml lector = new LectorXml(entrada);
                Console.WriteLine($"Curso: {lector.Curso}");
                Console.WriteLine();

                List<Estudiante> estudiantes = lector.LeerEstudiantes();

                Console.WriteLine("=== Todos los estudiantes ===");
                foreach (Estudiante est in estudiantes)
                {
                    Console.WriteLine(est);
                }
                Console.WriteLine();

                // ---------- CONSULTA LINQ ----------
                Console.WriteLine("=== Aprobados (ordenados por nota) ===");
                foreach (string nombre in lector.NombresAprobados())
                {
                    Console.WriteLine($"  - {nombre}");
                }
                Console.WriteLine();

                // ---------- ESCRITURA ----------
                EscritorXml escritor = new EscritorXml();
                escritor.GuardarAprobados(estudiantes, salida);
                Console.WriteLine($"Archivo '{salida}' generado con los aprobados.");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine($"Error: no se encontró el archivo '{entrada}'.");
            }
            catch (XmlException ex)
            {
                Console.WriteLine($"Error: el XML está mal formado. {ex.Message}");
            }
        }
    }
}
