
Console.WriteLine("=== Herencia: EstudianteH y Docente heredan de Persona ===\n");

EstudianteH est = new EstudianteH("Juanito Pancho", 22, 202300001, "Ing. Sistemas");
Docente     doc = new Docente("Ing. Pancho Guitierrez", 40, "IPC2");

est.Presentarse();
Console.WriteLine("---");
doc.Presentarse();

Console.WriteLine("\n=== Ambos SON un Persona (relación es-un) ===");
Persona p1 = est;   // una variable de tipo Persona puede guardar un EstudianteH
Persona p2 = doc;   // ...o un Docente
Console.WriteLine($"p1 es de tipo: {p1.GetType().Name}");
Console.WriteLine($"p2 es de tipo: {p2.GetType().Name}");

