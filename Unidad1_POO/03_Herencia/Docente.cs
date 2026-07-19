// ============================================================
//  IPC2 — Unidad 1: POO en C#
//  Tema 1.4.3.1 — Herencia
// ============================================================

class Docente : Persona
{
    public string CursoQueImparte { get; set; }

    public Docente(string nombre, int edad, string cursoQueImparte)
        : base(nombre, edad)
    {
        CursoQueImparte = cursoQueImparte;
    }

    public override void Presentarse()
    {
        base.Presentarse();
        Console.WriteLine($"Imparto el curso {CursoQueImparte}.");
    }
}
