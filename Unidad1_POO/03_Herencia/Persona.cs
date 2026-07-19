// ============================================================
//  IPC2 — Unidad 1: POO en C#
//  Tema 1.4.3.1 — Herencia
// ============================================================
//  La herencia permite que una clase (hija) reutilice atributos
//  y métodos de otra clase (padre), y los extienda o modifique.
// ============================================================

class Persona
{
    public string Nombre { get; set; }
    public int    Edad   { get; set; }

    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad   = edad;
    }

    // 'virtual' permite que las clases hijas puedan sobreescribir este método
    public virtual void Presentarse()
    {
        Console.WriteLine($"Hola, soy {Nombre} y tengo {Edad} años.");
    }
}
