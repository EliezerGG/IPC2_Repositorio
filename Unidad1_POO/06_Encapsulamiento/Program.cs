// ============================================================
//  IPC2 — Unidad 1: POO en C#
//  Tema 1.4.3.4 — Encapsulamiento (Program.cs)
// ============================================================

CuentaEstudiante cuenta = new CuentaEstudiante("Carlos Lima", 500.0);

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

// --- Ejercicio para el estudiante ---
// TODO: Agregá una property "Bloqueada" (bool, con setter privado) a
// CuentaEstudiante. Si Bloqueada es true, Depositar() y
// RetirarParaColegiatura() deben rechazar la operación. Agregá un
// método BloquearCuenta() que la active.
