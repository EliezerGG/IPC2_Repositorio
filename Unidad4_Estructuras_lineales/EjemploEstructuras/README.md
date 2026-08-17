# EjemploEstructuras — las 5 estructuras lineales, cada una con un objeto distinto

Proyecto de consola en C# que demuestra las cinco estructuras lineales de la
Sesión 1. Cada una está **implementada a mano** (sin `List<T>` ni arreglos) y
guarda **un objeto diferente**, en un caso de uso donde esa estructura es la
elección natural.

## Qué estructura guarda qué objeto (y por qué)

| Estructura            | Objeto que guarda | Caso de uso            | Por qué esa estructura |
|-----------------------|-------------------|------------------------|------------------------|
| Pila (LIFO)           | `Accion`          | Deshacer (undo)        | La última acción es la primera en deshacerse |
| Cola (FIFO)           | `Turno`           | Turnos de atención     | Se atiende en orden de llegada |
| Lista simple          | `Cancion`         | Playlist               | Se recorre en un solo sentido |
| Lista doble           | `Pagina`          | Historial del navegador| Se va adelante y atrás |
| Lista circular        | `Jugador`         | Turnos rotativos       | El turno vuelve al primero, sin fin |

## Archivos

Objetos: `Accion.cs`, `Turno.cs`, `Cancion.cs`, `Pagina.cs`, `Jugador.cs`
Estructuras (TDAs): `PilaAcciones.cs`, `ColaTurnos.cs`, `ListaCanciones.cs`,
`ListaPaginas.cs`, `ListaCircularJugadores.cs`
Programa: `Program.cs` (menú de consola)

## Cómo ejecutarlo

```bash
dotnet run
```

Aparece un menú con una opción por estructura; cada una corre una pequeña
demostración.

## Detalle de cada estructura

- **PilaAcciones** — `Apilar` (push) y `Desapilar` (pop) por la cima. Demuestra
  el "deshacer": lo último que se hizo es lo primero que se deshace.
- **ColaTurnos** — `Encolar` por el final, `Desencolar` por el frente. Demuestra
  la atención en orden de llegada.
- **ListaCanciones** — lista simple con `Insertar` al final y recorrido con
  `foreach` (implementa `IEnumerable<Cancion>`).
- **ListaPaginas** — lista doble con dos recorridos: `EnOrden` (adelante) y
  `EnReversa` (atrás, usando el puntero al anterior).
- **ListaCircularJugadores** — lista circular; el método `Rotar(pasos)` recorre
  en ciclo, así que puede dar más turnos que jugadores.

## Salida esperada (resumen)

```
PILA:  cima = "Insertar imagen"; se deshace esa y luego "Poner en negrita".
COLA:  atiende a Ana, luego a Luis; queda María en el frente.
SIMPLE: 1. Amanecer  2. Bucle Infinito  3. Nodo Perdido
DOBLE:  adelante usac → classroom → github ;  atrás github → classroom → usac
CIRCULAR (7 turnos): Ana, Luis, María, Ana, Luis, María, Ana
```

## Nota importante sobre los TDAs

Cada estructura tiene su **propio nodo interno** y es **específica de su tipo**
(por ejemplo, `PilaAcciones` guarda `Accion`, no un tipo genérico). Esto sigue
la restricción del curso: no se usan colecciones nativas ni TDAs genéricos
(`Lista<T>`); cada TDA se implementa a la medida del objeto que guarda.
