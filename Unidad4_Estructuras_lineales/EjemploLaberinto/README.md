# EjemploLaberinto — XML + TDA + Graphviz + menú de consola

Versión "laberinto" del ejemplo. Un laberinto se guarda en XML, se carga en un
TDA propio (`ListaCeldas`) y se dibuja con Graphviz como una **cuadrícula de
cuadros pegados** (sin separación entre celdas).

## Qué cambió respecto a la versión "matriz"

- Cada celda ya no tiene un `valor` numérico, sino un **`tipo`**:
  `pared`, `camino`, `entrada` o `salida`.
- El gráfico ya **no** usa nodos-círculo con aristas (que dejan huecos). Ahora
  usa una **etiqueta tipo tabla HTML** de Graphviz con `CELLSPACING="0"`, de modo
  que los cuadros quedan pegados y forman el mapa. Se renderiza con el motor `dot`.

## Archivos

- `laberinto.xml` — el laberinto de ejemplo (5x7) con un camino de la entrada a la salida.
- `Celda.cs` — una celda: fila, columna y `tipo` (con `EsPared`, `EsCamino`, etc.).
- `ListaCeldas.cs` — TDA lista enlazada de celdas (implementación propia).
- `Laberinto.cs` — dimensiones + las celdas en el TDA; dibujo en consola.
- `ProcesadorXml.cs` — carga y guarda el laberinto en XML (XDocument).
- `GeneradorGraphviz.cs` — arma el `.dot` con la tabla HTML (cuadrícula).
- `Program.cs` — el menú de consola.
- `laberinto_ejemplo.png` — muestra ya renderizada del gráfico.

## Cómo ejecutarlo

```bash
dotnet run
```

La opción 4 necesita **Graphviz** instalado (macOS: `brew install graphviz`).
Si no está, el programa igual crea `laberinto.dot` y muestra el comando manual.

## El menú

```
1. Cargar laberinto desde XML
2. Mostrar laberinto en consola       (# pared, . camino, E entrada, S salida)
3. Consultar el tipo de una celda
4. Generar gráfico Graphviz           (crea laberinto.dot y laberinto.png)
5. Guardar laberinto en XML
0. Salir
```

## Cómo se dibuja la cuadrícula (sin separación)

En `GeneradorGraphviz` se construye una tabla HTML de Graphviz:

- `CELLSPACING="0"` → elimina el espacio entre celdas: quedan **pegadas**.
- `CELLBORDER="1"` → una línea fina entre cuadros para distinguirlos (puedes
  ponerla en `"0"` si los quieres totalmente sin línea).
- Cada `<TD>` se colorea con `BGCOLOR` según el tipo:
  pared = azul oscuro, camino = blanco, entrada = verde (E), salida = naranja (S).

El laberinto de ejemplo se ve así en consola:

```
# # # # # # #
E . . # . . S
# # . # . # #
# . . . . # #
# # # # # # #
```

...y como cuadrícula de colores en `laberinto_ejemplo.png`.

## Diferencia con ChapinWarriors (a propósito)

ChapinWarriors posiciona nodos con el motor `neato`. Aquí se usa una tabla HTML
con `dot`: es otra técnica válida para dibujar cuadrículas, más sencilla cuando
el objetivo es un mapa de cuadros pegados. La idea es parecerse, no ser idéntico.

## Ideas para extenderlo (opcional)

- Marcar en el gráfico el **camino solución** de la entrada a la salida (por
  ejemplo con BFS sobre las celdas de tipo camino), pintándolo de otro color.
- Permitir editar celdas desde el menú y volver a guardar el XML.
