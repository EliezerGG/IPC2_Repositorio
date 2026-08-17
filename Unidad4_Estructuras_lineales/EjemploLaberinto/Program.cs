using System;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace EjemploLaberinto
{
    // Menú de consola: integra lectura/escritura XML, el TDA ListaCeldas
    // y la generación de un gráfico Graphviz (cuadrícula), sobre un laberinto.
    class Program
    {
        static Laberinto laberinto = null;
        const string ArchivoEntrada = "laberinto.xml";
        const string ArchivoSalidaXml = "laberinto_guardado.xml";
        const string ArchivoDot = "laberinto.dot";

        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1": Cargar(); break;
                    case "2": Mostrar(); break;
                    case "3": ConsultarCelda(); break;
                    case "4": GenerarGrafico(); break;
                    case "5": Guardar(); break;
                    case "0": salir = true; Console.WriteLine("¡Hasta luego!"); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
                Console.WriteLine();
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("===== MENÚ LABERINTO =====");
            Console.WriteLine("1. Cargar laberinto desde XML");
            Console.WriteLine("2. Mostrar laberinto en consola");
            Console.WriteLine("3. Consultar el tipo de una celda");
            Console.WriteLine("4. Generar gráfico Graphviz (cuadrícula)");
            Console.WriteLine("5. Guardar laberinto en XML");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");
        }

        static void Cargar()
        {
            try
            {
                ProcesadorXml procesador = new ProcesadorXml();
                laberinto = procesador.CargarDesdeXml(ArchivoEntrada);
                Console.WriteLine($"Laberinto cargado: {laberinto.Filas} x {laberinto.Columnas} " +
                                  $"({laberinto.Celdas.Cantidad} celdas).");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"No se encontró el archivo '{ArchivoEntrada}'.");
            }
            catch (XmlException ex)
            {
                Console.WriteLine($"El XML está mal formado: {ex.Message}");
            }
        }

        static void Mostrar()
        {
            if (!HayLaberinto()) return;
            Console.WriteLine("Leyenda:  # pared   . camino   E entrada   S salida");
            Console.WriteLine();
            Console.WriteLine(laberinto.ComoTexto());
        }

        static void ConsultarCelda()
        {
            if (!HayLaberinto()) return;
            Console.Write("Fila: ");
            int fila = LeerEntero();
            Console.Write("Columna: ");
            int col = LeerEntero();

            Celda c = laberinto.Celdas.Buscar(fila, col);
            if (c == null)
            {
                Console.WriteLine("Esa celda no existe en el laberinto.");
            }
            else
            {
                Console.WriteLine($"Celda ({fila},{col}) es de tipo: {c.Tipo}");
            }
        }

        static void GenerarGrafico()
        {
            if (!HayLaberinto()) return;
            GeneradorGraphviz generador = new GeneradorGraphviz();
            generador.GuardarDot(laberinto, ArchivoDot);
            Console.WriteLine($"Archivo '{ArchivoDot}' generado.");

            // La etiqueta es una tabla HTML: se renderiza con el motor 'dot'.
            try
            {
                Process proceso = new Process();
                proceso.StartInfo.FileName = "dot";
                proceso.StartInfo.Arguments = $"-Tpng {ArchivoDot} -o laberinto.png";
                proceso.StartInfo.UseShellExecute = false;
                proceso.Start();
                proceso.WaitForExit();
                Console.WriteLine("Imagen 'laberinto.png' generada con Graphviz.");
            }
            catch
            {
                Console.WriteLine("No se pudo ejecutar Graphviz automáticamente.");
                Console.WriteLine($"Genera la imagen a mano con:  dot -Tpng {ArchivoDot} -o laberinto.png");
            }
        }

        static void Guardar()
        {
            if (!HayLaberinto()) return;
            ProcesadorXml procesador = new ProcesadorXml();
            procesador.GuardarEnXml(laberinto, ArchivoSalidaXml);
            Console.WriteLine($"Laberinto guardado en '{ArchivoSalidaXml}'.");
        }

        // --- Utilidades ---
        static bool HayLaberinto()
        {
            if (laberinto == null)
            {
                Console.WriteLine("Primero carga un laberinto (opción 1).");
                return false;
            }
            return true;
        }

        static int LeerEntero()
        {
            int valor;
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Ingresa un número válido: ");
            }
            return valor;
        }
    }
}
