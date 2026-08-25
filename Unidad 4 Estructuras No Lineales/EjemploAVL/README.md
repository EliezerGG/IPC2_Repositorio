# EjemploAVL — Árbol AVL (auto-balanceado) con Graphviz

Ejemplo de un **árbol AVL** en C#: un árbol binario de búsqueda que se mantiene
balanceado solo, usando el factor de balance y rotaciones. Incluye búsqueda,
inserción, eliminación, recorridos y la opción de **graficarlo con Graphviz**.
Los comentarios están en minúsculas y sin tildes, y casi todas las líneas están
comentadas.

## Enunciado (caso realista)

Un sistema de soporte crea **tickets con números consecutivos** (1, 2, 3, …). Se
necesita buscar, agregar y cerrar tickets rápido, y listarlos en orden. Si se
guardaran en un ABB normal, como los números llegan en orden creciente, el árbol
se convertiría en una **línea** y buscar sería lento. Un **AVL** evita eso: se
reequilibra solo con rotaciones tras cada inserción o eliminación.

Cada nodo guarda un `Ticket` (número, asunto, prioridad) y el árbol se ordena por
el `Numero`.

## Por qué AVL y no un ABB normal

Los datos de ejemplo se insertan **en orden creciente** (10, 20, 30, …, 70). En
un ABB normal eso produce una línea de altura 7. En el AVL, gracias a las
rotaciones, el resultado queda balanceado con **raíz 40** y altura **3**:

```
            40
          /    \
        20      60
       /  \    /  \
      10  30  50  70
```

## Archivos

- `Ticket.cs` — el objeto que guarda cada nodo (número, asunto, prioridad).
- `ArbolAVL.cs` — el AVL: insertar, buscar, eliminar, recorridos, rotaciones y
  generación del `.dot`. El nodo es una clase interna y guarda su **altura**.
- `Program.cs` — el menú de consola y el enunciado.
- `avl_ejemplo.png` — muestra ya renderizada del árbol (con el factor de balance).

## Cómo ejecutarlo

```bash
dotnet run
```

La opción 6 (graficar) necesita **Graphviz** (macOS: `brew install graphviz`).
Si no está, el programa igual crea `avl.dot` y muestra el comando manual.

## El menú

```
1. Cargar tickets de ejemplo (en orden 10..70)  → demuestra el balanceo
2. Insertar un ticket                            → usa Insertar (rebalancea)
3. Buscar un ticket por numero                   → usa Buscar
4. Cerrar (eliminar) un ticket por numero        → usa Eliminar (rebalancea)
5. Recorridos                                    → inorden, preorden, posorden
6. Graficar el arbol (Graphviz)                  → crea avl.dot y avl.png
0. Salir
```

## Cómo funciona el balanceo (resumen)

- Cada nodo guarda su **altura**. El **factor de balance** de un nodo es
  `altura(izquierda) − altura(derecha)`; debe ser −1, 0 o +1.
- Tras insertar o eliminar, al volver por la recursión se llama a `Balancear`,
  que revisa el factor y aplica la rotación necesaria:
  - **LL** (pesado izquierda, en línea): rotación simple a la derecha.
  - **RR** (pesado derecha, en línea): rotación simple a la izquierda.
  - **LR** (zigzag izq-der): rotación izquierda del hijo y luego derecha.
  - **RL** (zigzag der-izq): rotación derecha del hijo y luego izquierda.

## Métodos principales

| Operación   | Método                          | Nota |
|-------------|---------------------------------|------|
| Inserción   | `Insertar(Ticket)`              | inserta y luego `Balancear` |
| Búsqueda    | `Buscar(int numero)`            | baja por un solo camino |
| Eliminación | `Eliminar(int numero)`          | 3 casos + `Balancear` al volver |
| Rotaciones  | `RotarDerecha` / `RotarIzquierda` | corrigen el desbalance |
| Recorridos  | `RecorridoInorden/Preorden/Posorden()` | inorden sale ordenado |
| Graficar    | `GenerarDot()`                  | muestra el factor de balance por nodo |
