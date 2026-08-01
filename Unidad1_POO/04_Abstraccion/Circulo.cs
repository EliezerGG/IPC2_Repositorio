
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
