# Cómo leer los diagramas (explicación sencilla)

Este documento explica, con palabras del día a día, qué significan los dos
diagramas del ejemplo del catálogo de videojuegos. No necesitas saber
programación para entenderlo.

---

## Primero, una idea general

El programa hace algo muy parecido a lo que haría una persona en una tienda:

1. Va a buscar un cuaderno con la lista de videojuegos.
2. Ordena esa información para poder usarla.
3. Escoge solo algunos juegos.
4. Guarda esa selección en un cuaderno nuevo.

Los dos diagramas cuentan esa misma historia, pero de dos maneras distintas:

- El **diagrama de clases** es como los **moldes o formularios**: describe qué
  forma tiene cada cosa (un juego, el catálogo, el programa).
- El **diagrama de secuencia** es como el **guion de una obra**: describe el
  orden en que pasan las cosas, paso por paso.

---

## El diagrama de secuencia

### La comparación

Imagina a un **encargado de tienda** que tiene tres ayudantes. El encargado no
hace todo solo: le pide cosas a cada ayudante y ellos le responden.

- **Program : Main()** → es el **encargado**. Es quien da las órdenes.
- **File** → es el ayudante del **archivero**: sabe buscar y guardar papeles
  (archivos) en el cajón.
- **JsonSerializer** → es el **traductor**: convierte un texto largo y difícil
  de usar en información ordenada, y también al revés.
- **catalogo : Catalogo** → es la **carpeta ya ordenada** con la lista de
  juegos, lista para consultarse.

Cada uno tiene una **línea vertical punteada** hacia abajo. Esa línea significa
"esta persona está presente durante todo el proceso, esperando por si la
necesitan".

### Las flechas

- Una **flecha con línea llena** es una **orden o petición**: "por favor, haz
  esto".
- Una **flecha con línea punteada** es la **respuesta que regresa**: "aquí
  tienes el resultado".

El tiempo avanza de **arriba hacia abajo**: lo que está más arriba pasa primero.

### Qué pasa en cada paso (leyendo de arriba hacia abajo)

1. **El encargado le pide al archivero el cuaderno.**
   "Tráeme lo que está escrito en el archivo *catalogo.json*." En el diagrama:
   *ReadAllText("catalogo.json")*.

2. **El archivero le entrega el texto.**
   Le devuelve un montón de texto tal cual está escrito. Todavía es solo texto,
   aún no está ordenado. En el diagrama: *texto: string*.

3. **El encargado le pasa ese texto al traductor.**
   "Convierte este texto en información que yo pueda usar de verdad." En el
   diagrama: *Deserialize(texto)*.

4. **El traductor le devuelve la carpeta ordenada.**
   Ahora el encargado ya tiene el catálogo organizado, con cada juego separado y
   listo para consultar. En el diagrama: *catalogo (objeto)*.

5. **El encargado revisa la carpeta juego por juego.**
   Va leyendo cada videojuego y lo muestra en pantalla. En el diagrama:
   *recorrer Videojuegos (foreach → mostrar)*. Por eso esta flecha apunta hacia
   la carpeta: el encargado está consultando la información que hay dentro.

6. **El encargado hace un trabajo por su cuenta.**
   Escoge solo los juegos que son para varios jugadores y los ordena del mejor
   calificado al peor. Esta flecha es especial: **sale y regresa al mismo
   encargado** (es de color naranja y forma un pequeño gancho). Eso significa
   que **lo hace él mismo**, sin pedírselo a nadie. En el diagrama:
   *LINQ Where + OrderByDescending → multijugador*.

7. **El encargado le pasa esa selección al traductor otra vez.**
   Pero ahora al revés: "convierte esta lista de juegos de vuelta a texto, y que
   quede ordenado y fácil de leer." En el diagrama:
   *Serialize(multijugador, WriteIndented)*.

8. **El traductor le devuelve el texto listo.**
   Ya tiene la selección convertida en texto. En el diagrama:
   *jsonSalida: string*.

9. **El encargado le pide al archivero que lo guarde.**
   "Guarda este texto en un cuaderno nuevo llamado *multijugador.json*." En el
   diagrama: *WriteAllText("multijugador.json", jsonSalida)*.

### La idea que hay que llevarse

El encargado (el programa) **nunca trabaja solo**: le pide al archivero que
busque y guarde archivos, y al traductor que convierta entre "texto" e
"información ordenada". Todo ocurre en orden, de arriba hacia abajo.

---

## El diagrama de clases

### La comparación

Un diagrama de clases es como enseñar los **moldes o formularios en blanco** que
usa el programa. Un molde no es el pastel; es la forma que tendrá el pastel.
Aquí hay tres moldes:

- **Videojuego** → el formulario de **un solo juego**.
- **Catalogo** → el formulario del **catálogo completo** de la tienda.
- **Program** → el **trabajador** que llena y usa esos formularios.

### Cómo se lee cada caja

Cada caja tiene el **nombre arriba** y, debajo, una lista de sus **campos**
(los datos que guarda). Por ejemplo, el molde **Videojuego** tiene casillas
para: nombre del juego (*Titulo*), género, año, precio, si es para varios
jugadores (*Multijugador*), su calificación y las plataformas donde se juega.

En **Videojuego** hay además una línea que separa los datos de una acción al
final (*ToString*). Esa acción es simplemente "una forma de escribir el juego
como un texto bonito para mostrarlo". No te preocupes por el detalle: lo
importante es notar que un molde puede guardar **datos** y también tener
**acciones**.

El signo **+** que aparece antes de cada campo solo significa que ese dato está
"a la vista" y se puede usar libremente. Puedes ignorarlo para entender la idea
general.

### Las flechas entre las cajas

- **La flecha con el rombo (de Catalogo hacia Videojuego).**
  Significa "**el catálogo está formado por juegos**". Junto a la flecha ves un
  **1** de un lado y **0..\*** del otro: se lee como "un catálogo contiene de
  cero a muchos videojuegos". Es como decir que **una carpeta contiene muchas
  hojas**: la carpeta es una sola, pero adentro puede haber muchas hojas.

- **La flecha punteada que dice "usa" (de Program hacia Catalogo).**
  Significa "**el trabajador usa el catálogo**". El programa trabaja con el
  catálogo, pero el catálogo no es parte del programa; solo lo utiliza para hacer
  su tarea.

### La nota naranja

Abajo a la izquierda hay una nota que recuerda algo importante: el programa se
apoya en dos ayudantes (los mismos del diagrama de secuencia) para convertir
información y para leer y guardar archivos. Es la conexión entre los dos
diagramas.

### La idea que hay que llevarse

El diagrama de clases te dice **qué forma tienen las cosas** (un juego, el
catálogo) y **cómo se relacionan** (el catálogo está hecho de muchos juegos, y
el programa usa el catálogo). No dice en qué orden pasan las cosas; para eso
está el diagrama de secuencia.

---

## En una frase

- **Diagrama de clases** = las **piezas** y cómo encajan (los moldes).
- **Diagrama de secuencia** = la **película** de lo que hace el programa, paso a
  paso, de arriba hacia abajo.