// ============================================================
//  IPC2 — Unidad 1: Fundamentos de C#
//  Tema 1.3.1 — Variables, Expresiones y Sentencias
// ============================================================
//  Objetivo: declarar variables de distintos tipos, construir
//  expresiones aritméticas y mostrar resultados con
//  interpolación de cadenas.
// ============================================================

Console.WriteLine("=== Registro de un estudiante ===\n");

// --- Tipado explícito ---
string nombre   = "Fulanito de tal";
int    carne    = 202300001;
double nota1    = 85.5;
double nota2    = 90.0;
double nota3    = 78.5;
bool   asistio  = true;
char   seccion  = 'P';

// --- Inferencia de tipo con 'var' ---
var curso    = "IPC2";
var creditos = 6;

// --- Sentencia (expresión aritmética) ---
double promedio = (nota1 + nota2 + nota3) / 3;

// --- Constante: valor que nunca cambia durante la ejecución ---
const double NOTA_MINIMA_APROBACION = 61.0;

// --- Mostrar resultados con interpolación ---
Console.WriteLine($"Nombre:    {nombre}");
Console.WriteLine($"Carné:     {carne}");
Console.WriteLine($"Curso:     {curso} (Sección {seccion}) — {creditos} créditos");
Console.WriteLine($"Notas:     {nota1}, {nota2}, {nota3}");
Console.WriteLine($"Promedio:  {promedio:F2}");
Console.WriteLine($"Asistió:   {asistio}");
Console.WriteLine($"Nota mínima para aprobar: {NOTA_MINIMA_APROBACION}");

// --- Expresiones aritméticas adicionales ---
int    a = 10, b = 3;
Console.WriteLine("\n=== Operadores aritméticos ===");
Console.WriteLine($"{a} + {b} = {a + b}");
Console.WriteLine($"{a} - {b} = {a - b}");
Console.WriteLine($"{a} * {b} = {a * b}");
Console.WriteLine($"{a} / {b} = {a / b}   (división entera)");
Console.WriteLine($"{a} % {b} = {a % b}   (módulo/residuo)");
Console.WriteLine($"(double){a} / {b} = {(double)a / b:F4}   (con conversión a double)");

// --- Ejercicio para el estudiante (descomentar y completar) ---
// TODO: Declarar 3 variables con tus propios datos personales
// (nombre, carné, promedio) y mostrarlas con interpolación.
