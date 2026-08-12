# EjemploJSON — Unidad 3: Procesamiento de datos JSON

Proyecto de consola en C# que muestra cómo **leer, consultar y escribir** JSON
con `System.Text.Json`. El ejemplo es un **catálogo de videojuegos** de una
tienda ficticia (Pixel Store).

## Archivos

- `catalogo.json` — datos de ejemplo: un objeto con metadatos y un arreglo de videojuegos.
- `Videojuego.cs` — clase modelo de cada juego (una clase por archivo).
- `Catalogo.cs` — clase que refleja el objeto raíz (tienda + arreglo de juegos).
- `Program.cs` — lee, filtra con LINQ y escribe un JSON nuevo, con manejo de errores.
- `EjemploJSON.csproj` — proyecto .NET; copia el JSON junto al ejecutable.

## Por qué este ejemplo es útil

El `catalogo.json` incluye a propósito **todos los tipos de datos** vistos en clase:

- Texto (`"titulo"`), número entero (`"anio"`), número decimal (`"precio"`)
- Booleano (`"multijugador"`)
- `null` (el juego con `"calificacion": null` aún no está calificado)
- Objeto raíz `{ }` que contiene un arreglo `[ ]` de objetos (estructura anidada)
- Arreglo de textos (`"plataformas"`)

## Cómo ejecutarlo

Desde la carpeta del proyecto:

```bash
dotnet run
```

En **JetBrains Rider**: abre la carpeta como solución y pulsa Run.
En **VS Code**: abre la *carpeta* (no un solo archivo) y usa `dotnet run`.

## Qué hace el programa

1. **Lee** `catalogo.json` con `File.ReadAllText` y lo convierte en objetos con `JsonSerializer.Deserialize`.
2. **Muestra** todos los videojuegos con su información.
3. **Filtra con LINQ** los juegos multijugador, ordenados por calificación.
4. **Escribe** un archivo nuevo `multijugador.json` con formato legible (`WriteIndented`).

## Salida esperada

```
Tienda: Pixel Store  (moneda: GTQ)

=== Todos los videojuegos ===
[1] The Legend of Códigos (2021) — Aventura — Q249.99 — Un jugador — Calif: 9.2 — PC, Switch
[2] Galaxia Infinita (2023) — Estrategia — Q179.50 — Multijugador — Calif: 8.7 — PC, PlayStation, Xbox
[3] Carreras Neón (2019) — Carreras — Q99.99 — Multijugador — Calif: 7.4 — PC
[4] Reinos de Piedra (2024) — RPG — Q320.00 — Un jugador — Calif: sin calificar — PC, PlayStation
[5] Arena de Bloques (2022) — Battle Royale — Gratis — Multijugador — Calif: 8.1 — PC, Switch, Xbox, Mobile

=== Multijugador, ordenados por calificación ===
  - Galaxia Infinita
  - Arena de Bloques
  - Carreras Neón

Archivo 'multijugador.json' generado con 3 juegos.
```

## Conceptos que ilustra (mapa con las diapositivas)

| Concepto                        | Dónde en el código                                  |
|---------------------------------|-----------------------------------------------------|
| Leer archivo como texto         | `File.ReadAllText(entrada)`                         |
| Deserializar (texto → objeto)   | `JsonSerializer.Deserialize<Catalogo>(texto, ...)`  |
| Emparejar claves y propiedades  | `PropertyNameCaseInsensitive = true`                |
| Tipo que admite null            | `double? Calificacion`                              |
| Arreglo JSON → lista de C#      | `List<string> Plataformas`                          |
| Consulta con LINQ               | `.Where(...).OrderByDescending(...)`                |
| Serializar (objeto → texto)     | `JsonSerializer.Serialize(lista, ...)`              |
| JSON legible con sangría        | `WriteIndented = true`                              |
| Escribir texto en archivo       | `File.WriteAllText(salida, jsonSalida)`             |
| Manejo de errores               | `try-catch` (FileNotFoundException, JsonException)  |
