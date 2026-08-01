

abstract class FiguraGeometrica
{
    public string Color { get; set; }

    // El constructor puede ser 'protected': solo lo usan las clases hijas
    protected FiguraGeometrica(string color)
    {
        Color = color;
    }

    // Métodos abstractos: sin cuerpo — cada figura los implementa distinto
    public abstract double CalcularArea();
    public abstract double CalcularPerimetro();

    // Método concreto: código compartido, disponible para todas las hijas
    public void MostrarInfo()
    {
        Console.WriteLine($"Figura {Color,-8} | Área: {CalcularArea(),7:F2} | Perímetro: {CalcularPerimetro(),7:F2}");
    }
}
