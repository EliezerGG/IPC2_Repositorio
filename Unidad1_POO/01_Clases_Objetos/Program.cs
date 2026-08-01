

Console.WriteLine("=== La clase Estudiante es el molde ===\n");

// Cada 'new' crea un OBJETO distinto — una instancia de la clase
Estudiante e1 = new Estudiante("Juanito Pancho",  202300001, "Ing. en Ciencias y Sistemas");
Estudiante e2 = new Estudiante("Ana García",   202300002, "Ing. en Ciencias y Sistemas");
Estudiante e3 = new Estudiante("Luis Ramírez", 202300003, "Ing. Industrial");

// Cada objeto tiene SUS PROPIOS valores, aunque comparten la misma clase
e1.Presentarse();
e2.Presentarse();
e3.Presentarse();

Console.WriteLine("\n=== Cada objeto es independiente ===");
Console.WriteLine($"¿e1 y e2 son el mismo objeto? {ReferenceEquals(e1, e2)}");
Console.WriteLine($"Carné de e1: {e1.Carne}  |  Carné de e2: {e2.Carne}");

// --- Arreglo de objetos: varias instancias de la misma clase ---
Console.WriteLine("\n=== Arreglo de objetos ===");
Estudiante[] grupo = { e1, e2, e3 };
foreach (Estudiante e in grupo)
{
    e.Presentarse();
}

