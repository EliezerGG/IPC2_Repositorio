// ============================================================
//  IPC2 — Unidad 1: POO en C#
//  Tema 1.4.3.1 — Herencia (Program.cs)
// ============================================================

Console.WriteLine("=== Herencia: EstudianteH y Docente heredan de Persona ===\n");

EstudianteH est = new EstudianteH("Carlos Lima", 22, 202300001, "Ing. Sistemas");
Docente     doc = new Docente("Ing. Fernando Paz", 40, "IPC2");

est.Presentarse();
Console.WriteLine("---");
doc.Presentarse();

Console.WriteLine("\n=== Ambos SON un Persona (relación es-un) ===");
Persona p1 = est;   // una variable de tipo Persona puede guardar un EstudianteH
Persona p2 = doc;   // ...o un Docente
Console.WriteLine($"p1 es de tipo: {p1.GetType().Name}");
Console.WriteLine($"p2 es de tipo: {p2.GetType().Name}");

// --- Ejercicio para el estudiante ---
// TODO: Crea una nueva clase "Auxiliar" que también herede de Persona,
// con un atributo extra "HorasSemanales". Sobreescribí Presentarse()
// para que además muestre las horas semanales que trabaja.
