# EjemploMVC (Vanilla) — el patrón MVC con HTML, CSS y JavaScript

Una pequeña **lista de tareas** que implementa el patrón **Modelo–Vista–Controlador**
usando solo HTML, CSS y JavaScript (sin frameworks y sin Razor). Sirve para
**ver el patrón MVC en acción** antes de usarlo en ASP.NET Core.

Los comentarios del código están en minúsculas, sin tildes y sin "ñ", y casi
todas las líneas están comentadas.

## Cómo ejecutarlo

Abre `index.html` con cualquier navegador (doble clic). Puedes:
- Escribir una tarea y presionar **Agregar**.
- Hacer clic en el **texto** de una tarea para marcarla como hecha (se tacha).
- Hacer clic en la **x** para borrarla.

## Las tres partes (una por archivo)

| Parte           | Archivo           | Responsabilidad |
|-----------------|-------------------|-----------------|
| **Modelo**      | `modelo.js`       | Guarda las tareas y su lógica (agregar, eliminar, alternar). No sabe de HTML. |
| **Vista**       | `vista.js`        | Dibuja las tareas en la página y avisa de los clics. No tiene lógica de negocio. |
| **Controlador** | `controlador.js`  | Conecta modelo y vista: escucha al usuario, actualiza el modelo y manda redibujar. |
| (arranque)      | `app.js`          | Crea las tres partes y las une. |
| (estructura)    | `index.html`      | El HTML con el campo, el botón y la lista vacía. |
| (estilo)        | `estilos.css`     | Los colores y el diseño. |

## Cómo fluye una acción (ejemplo: agregar una tarea)

1. El usuario escribe y hace clic en **Agregar** → la **Vista** detecta el clic.
2. La Vista llama al **Controlador**, que le pide al **Modelo** que agregue la tarea.
3. El Controlador manda **refrescar**: le pasa las tareas del Modelo a la Vista.
4. La **Vista** vuelve a dibujar la lista. El usuario ve el cambio.

Fíjate en la separación: la Vista nunca cambia los datos directamente y el
Modelo nunca toca el HTML. Todo pasa por el Controlador.

## Cómo se relaciona con ASP.NET Core MVC (Unidad 6 y 7)

El patrón es **el mismo** que usa ASP.NET Core MVC; solo cambia dónde corre cada parte:

| En este ejemplo (navegador) | En ASP.NET Core MVC (servidor) |
|-----------------------------|--------------------------------|
| `Modelo` en JavaScript      | Clases de modelo en **C#**     |
| `Controlador` en JavaScript | Controladores en **C#**        |
| `Vista` que arma el DOM      | Vistas **Razor** (`.cshtml`)   |

Aquí todo corre en el navegador para poder **ver el patrón** sin instalar nada.
En la Unidad 7 se verá cómo la Vista se escribe con Razor del lado del servidor.

## Ideas para practicar

- Agrega un contador de tareas pendientes (una función más en el modelo y la vista).
- Agrega un botón para borrar todas las tareas hechas.
- Cambia el tema de colores modificando las variables en `:root` del CSS.
