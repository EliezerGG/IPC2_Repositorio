// ============================================================
//  IPC2 — Unidad 1: POO en C#
//  Tema 1.4.3.2 — Abstracción
// ============================================================

class Rectangulo : FiguraGeometrica
{
    public double Ancho { get; set; }
    public double Alto  { get; set; }

    public Rectangulo(string color, double ancho, double alto)
        : base(color)
    {
        Ancho = ancho;
        Alto  = alto;
    }

    // Cumple el "contrato" heredado — implementación obligatoria
    public override double CalcularArea()      => Ancho * Alto;
    public override double CalcularPerimetro() => 2 * (Ancho + Alto);
}
