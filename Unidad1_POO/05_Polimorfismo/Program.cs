// ============================================================
//  IPC2 — Unidad 1: POO en C#
//  Tema 1.4.3.3 — Polimorfismo (Program.cs)
// ============================================================

Console.WriteLine("=== Un arreglo de Empleado — tipos reales distintos ===\n");

// El arreglo es de tipo Empleado, pero cada elemento es de un tipo REAL distinto
Empleado[] planilla = {
    new DocenteTiempoCompleto("Ing. Fernando Paz"),
    new AuxiliarPorHoras("Carlos Lima", 80),
    new AuxiliarPorHoras("Ana García", 60),
    new DocenteTiempoCompleto("Inga. Marta Solís"),
};

// El mismo método MostrarSueldo() ejecuta CalcularSueldo() distinto
// según el tipo real de cada objeto — esto ES polimorfismo.
foreach (Empleado emp in planilla)
{
    emp.MostrarSueldo();
}

Console.WriteLine("\n=== Total de la planilla (sin importar el tipo de cada uno) ===");
double total = 0;
foreach (Empleado emp in planilla)
{
    total += emp.CalcularSueldo();
}
Console.WriteLine($"Total: Q{total:F2}");

// --- Ejercicio para el estudiante ---
// TODO: Crea una clase "DocenteMedioTiempo : Empleado" cuyo sueldo sea
// la mitad del SUELDO_BASE de tiempo completo (Q4,250.00). Agregala
// al arreglo "planilla" y verificá que el total se recalcule bien.
