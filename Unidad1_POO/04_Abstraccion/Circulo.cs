// ============================================================
//  IPC2 — Unidad 1: POO en C#
//  Tema 1.4.3.2 — Abstracción
// ============================================================

class Circulo : FiguraGeometrica
{
    public double Radio { get; set; }

    public Circulo(string color, double radio)
        : base(color)
    {
        Radio = radio;
    }

    public override double CalcularArea()      => Math.PI * Radio * Radio;
    public override double CalcularPerimetro() => 2 * Math.PI * Radio;
}
