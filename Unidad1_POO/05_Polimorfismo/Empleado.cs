

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
