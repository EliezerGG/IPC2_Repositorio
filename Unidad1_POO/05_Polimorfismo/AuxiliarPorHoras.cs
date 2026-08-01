

class AuxiliarPorHoras : Empleado
{
    private const double PAGO_POR_HORA = 45;
    public int HorasTrabajadas { get; set; }

    public AuxiliarPorHoras(string nombre, int horasTrabajadas) : base(nombre)
    {
        HorasTrabajadas = horasTrabajadas;
    }

    public override double CalcularSueldo() => HorasTrabajadas * PAGO_POR_HORA;
}
