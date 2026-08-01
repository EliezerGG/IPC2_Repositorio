# EjemploXML — Unidad 3: Procesamiento de datos XML

Proyecto de consola en C# que muestra cómo **leer, consultar y escribir** XML
con `XDocument` (LINQ to XML), usando el mismo caso de las diapositivas.

## Archivos

- `estudiantes.xml` — datos de ejemplo (5 estudiantes con id, nombre, carnet y nota).
- `Estudiante.cs` — clase modelo (Unidad 1: POO), con la propiedad `Aprobado`.
- `LectorXml.cs` — carga el XML, recorre el árbol y consulta con LINQ.
- `EscritorXml.cs` — construye un XML nuevo y lo guarda con `.Save()`.
- `Program.cs` — junta todo, con manejo de errores (`try-catch`).
- `EjemploXML.csproj` — proyecto .NET; copia el XML junto al ejecutable.

## Cómo ejecutarlo

Desde la carpeta del proyecto:

```bash
dotnet run
```

En **JetBrains Rider**: abre la carpeta como solución y pulsa Run.
En **VS Code**: abre la *carpeta* (no un solo archivo) y usa `dotnet run`.

## Qué hace el programa

1. **Lee** `estudiantes.xml` con `XDocument.Load()`.
2. **Recorre** cada `<estudiante>` y lo convierte en un objeto `Estudiante`.
3. **Consulta con LINQ** los aprobados (nota >= 61), ordenados por nota.
4. **Escribe** un archivo nuevo `aprobados.xml` solo con los aprobados.

## Salida esperada

```
Curso: IPC2

=== Todos los estudiantes ===
[1] Ana Pérez (carnet 202100179) — Nota: 85 → APROBADO
[2] Luis Gómez (carnet 202045512) — Nota: 58 → REPROBADO
[3] María López (carnet 201931044) — Nota: 91 → APROBADO
[4] Juanito Ramírez (carnet 202167890) — Nota: 47 → REPROBADO
[5] Sofía Castillo (carnet 202088123) — Nota: 73 → APROBADO

=== Aprobados (ordenados por nota) ===
  - María López
  - Ana Pérez
  - Sofía Castillo

Archivo 'aprobados.xml' generado con los aprobados.
```

## Conceptos que ilustra (mapa con las diapositivas)

| Concepto                | Dónde en el código                          |
|-------------------------|---------------------------------------------|
| `XDocument.Load()`      | `LectorXml` (constructor)                   |
| Navegar el árbol        | `.Root`, `.Elements()`, `.Element()`        |
| Leer atributo           | `(int)e.Attribute("id")`                    |
| Convertir tipo          | `(double)e.Element("nota")`                 |
| Consulta LINQ           | `LectorXml.NombresAprobados()`              |
| Construir y guardar XML | `EscritorXml.GuardarAprobados()` + `.Save()`|
| Manejo de errores       | `try-catch` en `Program.cs`                 |
