# EjemploArbol — Árbol Binario de Búsqueda (ABB) con Graphviz

Ejemplo de un **árbol binario de búsqueda** en C#, con un caso realista, todas
sus operaciones (búsqueda, inserción, eliminación, recorridos) y la opción de
**graficarlo con Graphviz**. Los comentarios del código están en minúsculas y
sin tildes, y casi todas las líneas están comentadas.

## Enunciado (caso realista)

Una tienda maneja el **inventario** de sus productos. Cada producto tiene un
**código único**. Se necesita agregar productos, buscarlos y quitarlos de forma
rápida, y también listarlos ordenados por código. Un ABB resuelve esto: ordena
por código, así cada operación baja por un solo camino en lugar de revisar todo
el inventario.

En este ejemplo, cada nodo guarda un `Producto` (código, nombre, precio) y el
árbol se ordena por el `Codigo`.

## Otros lugares realistas donde se usa un árbol

- **Sistema de archivos:** carpetas que contienen carpetas y archivos.
- **Índice de una base de datos:** para buscar registros por su clave sin leer
  toda la tabla.
- **Directorio / agenda:** contactos ordenados por número o por nombre.
- **Autocompletado:** sugerir palabras a partir de las primeras letras.
- **Árbol de decisiones:** clasificar según respuestas (sí/no).
- **Organigrama:** jefes y subordinados de una empresa.

## Archivos

- `Producto.cs` — el objeto que guarda cada nodo (código, nombre, precio).
- `ArbolBinarioBusqueda.cs` — el ABB: insertar, buscar, eliminar, recorridos y
  generación del `.dot` para Graphviz. El nodo es una clase interna.
- `Program.cs` — el menú de consola y el enunciado.
- `arbol_ejemplo.png` — muestra ya renderizada del árbol.

## Cómo ejecutarlo

```bash
dotnet run
```

La opción 6 (graficar) necesita **Graphviz** instalado (macOS:
`brew install graphviz`). Si no está, el programa igual crea `arbol.dot` y te
muestra el comando para generar el PNG a mano.

## El menú

```
1. Cargar productos de ejemplo      → inserta 7 productos
2. Insertar un producto             → pide codigo, nombre y precio
3. Buscar un producto por codigo    → usa Buscar
4. Eliminar un producto por codigo  → usa Eliminar (3 casos)
5. Recorridos                       → inorden, preorden, posorden
6. Graficar el arbol (Graphviz)     → crea arbol.dot y arbol.png
0. Salir
```

## Salida esperada (con los datos de ejemplo)

```
Inorden  (ordenado): 20  30  40  50  60  70  80
Preorden (raiz 1ro): 50  30  20  40  70  60  80
Posorden (raiz fin): 20  40  30  60  80  70  50
```

Al eliminar el código 30 (un nodo con dos hijos), su lugar lo toma el sucesor
(40), y el inorden queda: `20  40  50  60  70  80`.

## Qué método hace qué

| Operación   | Método                         | Idea |
|-------------|--------------------------------|------|
| Inserción   | `Insertar(Producto)`           | baja por la regla de orden y crea una hoja |
| Búsqueda    | `Buscar(int codigo)`           | baja por un solo camino comparando códigos |
| Eliminación | `Eliminar(int codigo)`         | 3 casos: hoja, un hijo, dos hijos (sucesor) |
| Recorridos  | `RecorridoInorden/Preorden/Posorden()` | visitan todos los nodos en distinto orden |
| Graficar    | `GenerarDot()`                 | arma el texto Graphviz del árbol |
