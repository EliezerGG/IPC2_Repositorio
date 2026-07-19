// ============================================================
//  IPC2 — Unidad 1: Fundamentos de C#
//  Tema 1.3.3 — Funciones
// ============================================================
//  Objetivo: declarar funciones con parámetros y valor de
//  retorno, funciones void, y sobrecarga de funciones.
// ============================================================

Console.WriteLine("=== Uso de funciones ===\n");

double p1 = CalcularPromedio(85, 90, 78);
double p2 = CalcularPromedio(60, 55, 70);

MostrarResultado("Carlos Lima", p1);
MostrarResultado("Ana García",  p2);

Console.WriteLine("\n=== Sobrecarga de funciones (Overloading) ===");
Console.WriteLine($"Suma de 2 números: {Sumar(4, 5)}");
Console.WriteLine($"Suma de 3 números: {Sumar(4, 5, 6)}");
Console.WriteLine($"Suma de decimales: {Sumar(4.5, 5.25)}");

Console.WriteLine("\n=== Función con parámetro opcional ===");
Console.WriteLine(GenerarSaludo("Carlos"));
Console.WriteLine(GenerarSaludo("Ana", "Buenas tardes"));


// ── FUNCIONES ────────────────────────────────────────────────

// Función con retorno (double) y 3 parámetros
static double CalcularPromedio(double nota1, double nota2, double nota3)
{
    return (nota1 + nota2 + nota3) / 3.0;
}

// Función void: no retorna valor, solo ejecuta una acción
static void MostrarResultado(string nombre, double promedio)
{
    string estado = promedio >= 61 ? "Aprobado" : "Reprobado";
    Console.WriteLine($"{nombre,-15} | Promedio: {promedio,6:F2} | {estado}");
}

// Sobrecarga: mismo nombre, distinta cantidad/tipo de parámetros
static int Sumar(int a, int b) => a + b;
static int Sumar(int a, int b, int c) => a + b + c;
static double Sumar(double a, double b) => a + b;

// Parámetro opcional: si no se pasa, usa el valor por defecto
static string GenerarSaludo(string nombre, string saludo = "Hola")
{
    return $"{saludo}, {nombre}. Bienvenido a IPC2.";
}

// --- Ejercicio para el estudiante ---
// TODO: Crear una función "EsPar(int numero)" que retorne bool,
// y otra "ClasificarNota(double nota)" que retorne un string
// usando switch expression ("Excelente", "Bueno", "Regular", "Malo").
