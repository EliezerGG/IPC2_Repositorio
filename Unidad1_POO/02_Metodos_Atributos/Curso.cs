

class Curso
{
    // Atributos — el estado del objeto
    public string Nombre;
    public string Codigo;
    public int    Creditos;

    // Atributo que cambia con el tiempo (lista simulada de notas)
    private List<double> _notas = new List<double>();

    public Curso(string nombre, string codigo, int creditos)
    {
        Nombre   = nombre;
        Codigo   = codigo;
        Creditos = creditos;
    }

    // Método sin retorno (void): modifica el estado del objeto
    public void RegistrarNota(double nota)
    {
        _notas.Add(nota);
    }

    // Método con retorno: calcula y devuelve un resultado
    public double CalcularPromedio()
    {
        if (_notas.Count == 0) return 0;

        double suma = 0;
        foreach (double n in _notas) suma += n;
        return suma / _notas.Count;
    }

    // Sobrecarga: mismo nombre "MostrarInfo", distintos parámetros
    public void MostrarInfo()
    {
        Console.WriteLine($"[{Codigo}] {Nombre} — {Creditos} créditos");
    }

    public void MostrarInfo(bool incluirPromedio)
    {
        MostrarInfo(); // reutiliza la versión sin parámetros
        if (incluirPromedio)
            Console.WriteLine($"   Promedio actual: {CalcularPromedio():F2}");
    }
}
