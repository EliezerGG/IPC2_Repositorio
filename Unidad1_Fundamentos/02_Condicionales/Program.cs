// ============================================================
//  IPC2 — Unidad 1: Fundamentos de C#
//  Tema 1.3.2 — Ejecución Condicional
// ============================================================
//  Objetivo: usar if/else, operador ternario y switch
//  expressions para tomar decisiones según datos de entrada.
// ============================================================

double promedio = 72.5;

Console.WriteLine("=== if / else if / else ===");
if (promedio >= 90)
{
    Console.WriteLine("Calificación: Excelente");
}
else if (promedio >= 75)
{
    Console.WriteLine("Calificación: Muy Bueno");
}
else if (promedio >= 61)
{
    Console.WriteLine("Calificación: Aprobado");
}
else
{
    Console.WriteLine("Calificación: Reprobado");
}

// --- Operador ternario: forma corta de un if/else simple ---
string estado = promedio >= 61 ? "Aprobado" : "Reprobado";
Console.WriteLine($"\n=== Operador ternario ===\nEstado: {estado}");

// --- Switch expression (más moderno y expresivo que switch clásico) ---
string letra = promedio switch
{
    >= 90 => "A",
    >= 80 => "B",
    >= 70 => "C",
    >= 61 => "D",
    _     => "F"          // _ = caso por defecto (default)
};
Console.WriteLine($"\n=== Switch expression ===\nLetra asignada: {letra}");

// --- Switch clásico (por si se necesita ejecutar varias sentencias) ---
Console.WriteLine("\n=== Switch clásico ===");
int diaLaboratorio = 2; // 1=Lunes, 2=Martes, ...
switch (diaLaboratorio)
{
    case 1:
        Console.WriteLine("Hoy es Lunes — clase magistral");
        break;
    case 2:
        Console.WriteLine("Hoy es Martes — laboratorio IPC2");
        break;
    default:
        Console.WriteLine("No hay actividad programada");
        break;
}

// --- Operadores lógicos combinados ---
bool asistio  = true;
bool aprobado = promedio >= 61;

if (asistio && aprobado)
{
    Console.WriteLine("\nEl estudiante tiene derecho a evaluación final.");
}
else if (!asistio || !aprobado)
{
    Console.WriteLine("\nEl estudiante NO tiene derecho a evaluación final.");
}

// --- Ejercicio para el estudiante ---
// TODO: Dado un carné (int), determinar con un switch expression
// si el año de ingreso (primeros 4 dígitos) es 2023, 2024, 2025 o 2026.
