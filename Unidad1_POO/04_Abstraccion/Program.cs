
Console.WriteLine("=== FiguraGeometrica es abstracta: no se puede instanciar ===");
// FiguraGeometrica f = new FiguraGeometrica("Rojo");  //  Esto NO compila

Rectangulo r = new Rectangulo("Rojo",  5, 3);
Circulo    c = new Circulo("Azul", 4);

r.MostrarInfo();
c.MostrarInfo();

Console.WriteLine("\n=== Cada figura implementa CalcularArea() a su manera ===");
Console.WriteLine($"Área del rectángulo: {r.CalcularArea():F2}");
Console.WriteLine($"Área del círculo:    {c.CalcularArea():F2}");
