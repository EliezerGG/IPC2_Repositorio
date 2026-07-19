# Unidad 1 — Parte 1: Fundamentos de C#
### IPC2 · Segundo Semestre 2026 · ECYS · USAC

Ejemplos prácticos para acompañar la sesión de laboratorio. Cada carpeta es un
mini-proyecto de consola independiente y ejecutable.

## Contenido

| Carpeta | Tema del programa |
|---|---|
| `01_Variables_Expresiones` | Tipado explícito, `var`, constantes, expresiones aritméticas |
| `02_Condicionales` | `if/else`, operador ternario, `switch` expression, `switch` clásico |
| `03_Funciones` | Funciones con retorno, `void`, sobrecarga, parámetros opcionales |
| `04_Iteracion` | `for`, `foreach`, `while`, `do-while`, ciclos anidados |
| `05_Strings` | Métodos de `string`, `Split`, conversión de tipos, `StringBuilder` |

Cada `Program.cs` incluye al final un comentario `// TODO:` con un mini-ejercicio
para que el estudiante lo resuelva en clase o de tarea corta.

## Cómo abrir en Rider

**Opción A — abrir cada uno por separado:**
```
File → Open → seleccionar la carpeta del tema (ej. 01_Variables_Expresiones)
```

**Opción B — crear una Solución que los agrupe a todos:**
1. Creá una carpeta `Unidad1_Fundamentos.sln` vacía en Rider (New Solution)
2. Click derecho en la solución → Add → Existing Project → seleccioná cada `.csproj`

## Cómo correr desde terminal

```bash
cd 01_Variables_Expresiones
dotnet run
```

Repetir `cd` + `dotnet run` para cada carpeta.
