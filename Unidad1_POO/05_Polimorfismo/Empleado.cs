// ============================================================
//  IPC2 — Unidad 1: POO en C#
//  Tema 1.4.3.3 — Polimorfismo
// ============================================================
//  Polimorfismo = "muchas formas". Un mismo mensaje
//  (CalcularSueldo) produce un comportamiento DISTINTO según
//  el tipo real del objeto — aunque todos se traten como
//  Empleado desde afuera.
// ============================================================

abstract class Empleado
{
    public string Nombre { get; set; }

    protected Empleado(string nombre)
    {
        Nombre = nombre;
    }

    public abstract double CalcularSueldo();

    public void MostrarSueldo()
    {
        Console.WriteLine($"{Nombre,-20} | Sueldo: Q{CalcularSueldo(),8:F2}");
    }
}
