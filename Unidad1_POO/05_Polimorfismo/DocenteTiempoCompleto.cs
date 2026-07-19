// ============================================================
//  IPC2 — Unidad 1: POO en C#
//  Tema 1.4.3.3 — Polimorfismo
// ============================================================

class DocenteTiempoCompleto : Empleado
{
    private const double SUELDO_BASE = 8500;

    public DocenteTiempoCompleto(string nombre) : base(nombre) { }

    public override double CalcularSueldo() => SUELDO_BASE;
}
