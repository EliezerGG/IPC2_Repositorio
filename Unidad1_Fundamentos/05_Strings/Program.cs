

string texto = "  Introducción a la Programación 2  ";

Console.WriteLine("=== Métodos básicos de string ===");
Console.WriteLine($"Original:   '{texto}'");
Console.WriteLine($"Trim():     '{texto.Trim()}'");
Console.WriteLine($"ToUpper():  '{texto.ToUpper()}'");
Console.WriteLine($"ToLower():  '{texto.ToLower()}'");
Console.WriteLine($"Length:      {texto.Length}");
Console.WriteLine($"Contains(\"Programación\"): {texto.Contains("Programación")}");
Console.WriteLine($"Replace(): '{texto.Replace("2", "II")}'");

// --- Substring: extraer una parte del texto ---
string curso = texto.Trim();
string abreviatura = curso.Substring(0, 12);  // (inicio, longitud)
Console.WriteLine($"\nSubstring(0, 12): '{abreviatura}'");

// --- Concatenación vs Interpolación ---
string nombre = "Juan";
string apellido = "Alvarado";
string completoConcat = nombre + " " + apellido;                 // concatenación
string completoInterp = $"{nombre} {apellido}";                  // interpolación (preferida)
Console.WriteLine($"\nConcatenado:   {completoConcat}");
Console.WriteLine($"Interpolado:   {completoInterp}");

// --- Split: separar un string en partes (muy usado con CSV) ---
Console.WriteLine("\n=== Split — procesando una línea tipo CSV ===");
string lineaCsv = "Juanito Pancho,202300001,88.5";
string[] partes = lineaCsv.Split(',');

string  nombreEst = partes[0];
int     carneEst  = int.Parse(partes[1]);      // conversión string -> int
double  notaEst   = double.Parse(partes[2]);   // conversión string -> double

Console.WriteLine($"Nombre: {nombreEst}");
Console.WriteLine($"Carné:  {carneEst}");
Console.WriteLine($"Nota:   {notaEst:F1}");

// --- Conversión número -> string ---
int    edad = 22;
string edadTexto = edad.ToString();
Console.WriteLine($"\nedad.ToString() = '{edadTexto}' (tipo: string)");

// --- StringBuilder — útil cuando se concatena dentro de un ciclo ---
Console.WriteLine("\n=== StringBuilder — construir texto en un ciclo ===");
var sb = new System.Text.StringBuilder();
string[] temas = { "Variables", "Condicionales", "Funciones", "Iteración", "Strings" };
foreach (string tema in temas)
{
    sb.Append(tema).Append(" | ");
}
Console.WriteLine(sb.ToString());

