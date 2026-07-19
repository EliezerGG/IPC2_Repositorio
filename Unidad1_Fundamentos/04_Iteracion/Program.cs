// ============================================================
//  IPC2 — Unidad 1: Fundamentos de C#
//  Tema 1.3.4 — Iteración
// ============================================================
//  Objetivo: recorrer datos con for, while, do-while y foreach.
// ============================================================

string[] estudiantes = { "Carlos", "Ana", "María", "Luis", "Pedro" };
double[] notas       = { 85.0, 55.0, 91.5, 70.0, 40.0 };

// --- for: cuando se conoce la cantidad de iteraciones ---
Console.WriteLine("=== FOR — recorrido por índice ===");
for (int i = 0; i < estudiantes.Length; i++)
{
    Console.WriteLine($"{i + 1}. {estudiantes[i],-10} — Nota: {notas[i]}");
}

// --- foreach: cuando solo interesa el valor, no el índice ---
Console.WriteLine("\n=== FOREACH — recorrido directo ===");
double suma = 0;
foreach (double nota in notas)
{
    suma += nota;
}
double promedioGeneral = suma / notas.Length;
Console.WriteLine($"Promedio general del grupo: {promedioGeneral:F2}");

// --- while: se repite mientras la condición sea verdadera ---
Console.WriteLine("\n=== WHILE — contador manual ===");
int aprobados = 0;
int j = 0;
while (j < notas.Length)
{
    if (notas[j] >= 61)
        aprobados++;
    j++;
}
Console.WriteLine($"Estudiantes aprobados: {aprobados} de {notas.Length}");

// --- do-while: se ejecuta AL MENOS una vez ---
Console.WriteLine("\n=== DO-WHILE — validación de menú ===");
int intento = 0;
int opcion;
do
{
    intento++;
    opcion = intento; // simulación: en un caso real vendría de Console.ReadLine()
    Console.WriteLine($"Intento #{intento} — opción simulada: {opcion}");
} while (intento < 3);

// --- Ciclos anidados: tabla de resultados ---
Console.WriteLine("\n=== Ciclo anidado — tabla de multiplicar ===");
for (int fila = 1; fila <= 3; fila++)
{
    for (int columna = 1; columna <= 5; columna++)
    {
        Console.Write($"{fila * columna,4}");
    }
    Console.WriteLine();
}

// --- Ejercicio para el estudiante ---
// TODO: Usando un for, recorrer el arreglo "notas" e imprimir
// solamente las notas reprobadas (menores a 61), junto con el
// nombre del estudiante correspondiente (usa el mismo índice).
