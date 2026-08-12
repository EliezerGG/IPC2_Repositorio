using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace EjemploJSON
{
    // Punto de entrada: lee el catálogo desde JSON, lo muestra, filtra con
    // LINQ y guarda un JSON nuevo con formato legible. Todo con manejo de errores.
    class Program
    {
        static void Main(string[] args)
        {
            const string entrada = "catalogo.json";
            const string salida = "multijugador.json";

            // Opciones de lectura: empareja claves aunque difieran las mayúsculas
            // (JSON usa "titulo", la propiedad de C# se llama Titulo).
            JsonSerializerOptions opcionesLectura = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // Opciones de escritura: WriteIndented = true hace que el JSON salga
            // con sangría y saltos de línea, legible para las personas.
            JsonSerializerOptions opcionesEscritura = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            try
            {
                // ---------- LECTURA ----------
                // Paso 1: traer todo el contenido del archivo como texto.
                string texto = File.ReadAllText(entrada);

                // Paso 2: convertir ese texto en un objeto Catalogo.
                Catalogo catalogo = JsonSerializer.Deserialize<Catalogo>(texto, opcionesLectura);

                Console.WriteLine($"Tienda: {catalogo.Tienda}  (moneda: {catalogo.Moneda})");
                Console.WriteLine();

                Console.WriteLine("=== Todos los videojuegos ===");
                foreach (Videojuego juego in catalogo.Videojuegos)
                {
                    Console.WriteLine(juego);
                }
                Console.WriteLine();

                // ---------- CONSULTA LINQ ----------
                Console.WriteLine("=== Multijugador, ordenados por calificación ===");
                List<Videojuego> multijugador = catalogo.Videojuegos
                    .Where(j => j.Multijugador)
                    .OrderByDescending(j => j.Calificacion ?? 0)
                    .ToList();

                foreach (Videojuego juego in multijugador)
                {
                    Console.WriteLine($"  - {juego.Titulo}");
                }
                Console.WriteLine();

                // ---------- ESCRITURA ----------
                // Paso 1: convertir la lista filtrada en texto JSON con formato.
                string jsonSalida = JsonSerializer.Serialize(multijugador, opcionesEscritura);

                // Paso 2: escribir ese texto en un archivo nuevo.
                File.WriteAllText(salida, jsonSalida);

                Console.WriteLine($"Archivo '{salida}' generado con {multijugador.Count} juegos.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: no se encontró el archivo '{entrada}'.");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error: el JSON está mal formado. {ex.Message}");
            }
        }
    }
}
