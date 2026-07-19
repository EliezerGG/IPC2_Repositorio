# Unidad 1 — Parte 2: Programación Orientada a Objetos
### IPC2 · Segundo Semestre 2026 · ECYS · USAC

Ejemplos prácticos para acompañar la sesión de laboratorio. Cada carpeta es un
mini-proyecto de consola independiente y ejecutable, con las clases separadas
en archivos individuales (convención estándar de C#).

## Contenido

| Carpeta | Tema | Archivos de clase |
|---|---|---|
| `01_Clases_Objetos` | 1.4.1 — Concepto de clase, objeto, constructor | `Estudiante.cs` |
| `02_Metodos_Atributos` | 1.4.2 — Atributos, métodos, retorno, sobrecarga | `Curso.cs` |
| `03_Herencia` | 1.4.3.1 — `:`, `base()`, `virtual`/`override` | `Persona.cs`, `EstudianteH.cs`, `Docente.cs` |
| `04_Abstraccion` | 1.4.3.2 — `abstract class`, métodos abstractos | `FiguraGeometrica.cs`, `Rectangulo.cs`, `Circulo.cs` |
| `05_Polimorfismo` | 1.4.3.3 — Un mismo mensaje, comportamiento distinto | `Empleado.cs`, `DocenteTiempoCompleto.cs`, `AuxiliarPorHoras.cs` |
| `06_Encapsulamiento` | 1.4.3.4 — Campos privados, properties con validación | `CuentaEstudiante.cs` |

Cada `Program.cs` incluye al final un comentario `// TODO:` con un mini-ejercicio
para resolver en clase o de tarea corta.

## Cómo abrir en Rider

**Opción A — abrir cada uno por separado:**
```
File → Open → seleccionar la carpeta del tema (ej. 03_Herencia)
```

**Opción B — agruparlos en una sola Solución:**
1. Creá una Solución vacía en Rider (New Solution)
2. Click derecho en la solución → Add → Existing Project → seleccioná cada `.csproj`

## Cómo correr desde terminal

```bash
cd 03_Herencia
dotnet run
```

Repetir `cd` + `dotnet run` para cada carpeta.

## Progresión sugerida

Los temas están ordenados para construir sobre el anterior:
1. **Clases y Objetos** → qué es una instancia
2. **Métodos y Atributos** → cómo se comporta y qué datos guarda
3. **Herencia** → reutilizar y extender una clase
4. **Abstracción** → definir un contrato sin implementarlo
5. **Polimorfismo** → un mensaje, múltiples comportamientos reales
6. **Encapsulamiento** → proteger el estado interno del objeto
