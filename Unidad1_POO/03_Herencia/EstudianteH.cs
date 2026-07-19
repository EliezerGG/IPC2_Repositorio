// ============================================================
//  IPC2 — Unidad 1: POO en C#
//  Tema 1.4.3.1 — Herencia
// ============================================================

class EstudianteH : Persona   // ':' indica herencia — EstudianteH ES-UN Persona
{
    public int    Carne   { get; set; }
    public string Carrera { get; set; }

    // base(...) llama al constructor de la clase padre (Persona)
    public EstudianteH(string nombre, int edad, int carne, string carrera)
        : base(nombre, edad)
    {
        Carne   = carne;
        Carrera = carrera;
    }

    // 'override' reemplaza el comportamiento heredado de Persona
    public override void Presentarse()
    {
        base.Presentarse();   // reutiliza la versión del padre
        Console.WriteLine($"Estudio {Carrera}, carné {Carne}.");
    }
}
