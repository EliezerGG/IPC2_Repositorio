===========================================

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
