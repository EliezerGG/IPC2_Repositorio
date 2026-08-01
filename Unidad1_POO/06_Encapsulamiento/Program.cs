

CuentaEstudiante cuenta = new CuentaEstudiante("Juanito Pancho", 500.0);

Console.WriteLine($"Estudiante: {cuenta.Nombre}");
Console.WriteLine($"Saldo inicial: Q{cuenta.SaldoBeca:F2}\n");

// cuenta._saldoBeca = -1000;   // ❌ Esto NO compila: el campo es privado

cuenta.Depositar(250);
Console.WriteLine($"Saldo tras depósito: Q{cuenta.SaldoBeca:F2}");

bool exito = cuenta.RetirarParaColegiatura(600);
Console.WriteLine($"¿Retiro de Q600 exitoso? {exito}");
Console.WriteLine($"Saldo actual: Q{cuenta.SaldoBeca:F2}");

bool exito2 = cuenta.RetirarParaColegiatura(1000);
Console.WriteLine($"¿Retiro de Q1000 exitoso? {exito2}");

Console.WriteLine("\n=== Por qué importa el encapsulamiento ===");
Console.WriteLine("El saldo SOLO puede cambiar a través de Depositar()");
Console.WriteLine("y RetirarParaColegiatura() — nunca queda en un estado inválido.");

