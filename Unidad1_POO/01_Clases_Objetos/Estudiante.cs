

class Estudiante
{
    // Atributos: los datos que cada objeto va a almacenar
    public string Nombre;
    public int    Carne;
    public string Carrera;

    // Constructor: se ejecuta automáticamente al crear el objeto con 'new'
    public Estudiante(string nombre, int carne, string carrera)
    {
        Nombre  = nombre;
        Carne   = carne;
        Carrera = carrera;
    }

    // Método: comportamiento que el objeto puede ejecutar
    public void Presentarse()
    {
        Console.WriteLine($"Soy {Nombre}, carné {Carne}, estudio {Carrera}.");
    }
}
