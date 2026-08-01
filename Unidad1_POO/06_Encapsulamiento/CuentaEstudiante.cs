
class CuentaEstudiante
{
    // Campo PRIVADO: nadie fuera de esta clase puede tocarlo directamente
    private double _saldoBeca;

    public string Nombre { get; private set; }  // se puede leer, pero solo esta clase lo modifica

    // Property con validación — la puerta controlada hacia _saldoBeca
    public double SaldoBeca
    {
        get { return _saldoBeca; }
        private set
        {
            if (value >= 0)
                _saldoBeca = value;
            else
                Console.WriteLine("Error: el saldo no puede ser negativo.");
        }
    }

    public CuentaEstudiante(string nombre, double saldoInicial)
    {
        Nombre    = nombre;
        SaldoBeca = saldoInicial;
    }

    // Los métodos son la única forma de modificar el saldo desde afuera
    public void Depositar(double monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("El monto a depositar debe ser positivo.");
            return;
        }
        SaldoBeca = SaldoBeca + monto;
    }

    public bool RetirarParaColegiatura(double monto)
    {
        if (monto > SaldoBeca)
        {
            Console.WriteLine($"Fondos insuficientes: saldo actual Q{SaldoBeca:F2}.");
            return false;
        }
        SaldoBeca = SaldoBeca - monto;
        return true;
    }
}
