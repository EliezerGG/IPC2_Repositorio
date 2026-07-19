// ============================================================
//  IPC2 — Unidad 1: POO en C#
//  Tema 1.4.2 — Métodos y Atributos (Program.cs)
// ============================================================

Curso ipc2 = new Curso("Intro. Programación 2", "0771", 6);

Console.WriteLine("=== Sobrecarga de MostrarInfo() ===");
ipc2.MostrarInfo();              // versión sin parámetros
ipc2.MostrarInfo(true);          // versión con parámetro bool

Console.WriteLine("\n=== Métodos que modifican y consultan el estado ===");
ipc2.RegistrarNota(85.5);
ipc2.RegistrarNota(90.0);
ipc2.RegistrarNota(78.0);

Console.WriteLine($"Promedio tras registrar 3 notas: {ipc2.CalcularPromedio():F2}");
ipc2.MostrarInfo(true);

// --- Ejercicio para el estudiante ---
// TODO: Agregá un método "EstaAprobado()" a la clase Curso que retorne
// bool (true si CalcularPromedio() >= 61). Luego sobrecargá
// "RegistrarNota" para que también acepte un arreglo de notas
// (double[] notas) y las registre todas de una vez.
