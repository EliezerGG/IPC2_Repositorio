# EjemploMvcCsharp — MVC con C# (ASP.NET Core) + front end vanilla

La misma lista de tareas, pero ahora **el back end está en C# con ASP.NET Core**.
El **Modelo** y el **Controlador** viven en el servidor (C#); la **Vista** es un
front end de HTML/CSS/JavaScript vanilla que consume la API por HTTP.

Así usamos C# de verdad y seguimos **sin Razor** (que se ve en la Unidad 7).
Los comentarios están en minúsculas, sin tildes y sin "ñ".

## Arquitectura (quién es quién en MVC)

| Parte MVC        | Dónde vive        | Archivo(s) |
|------------------|-------------------|------------|
| **Modelo**       | Servidor (C#)     | `Models/Tarea.cs`, `Data/RepositorioTareas.cs` |
| **Controlador**  | Servidor (C#)     | `Controllers/TareasController.cs` |
| **Vista**        | Navegador (vanilla) | `wwwroot/index.html`, `wwwroot/app.js`, `wwwroot/estilos.css` |
| Configuración    | Servidor (C#)     | `Program.cs` |

El navegador (la Vista) pide datos a la API; el Controlador de C# los procesa con
ayuda del Modelo y responde en JSON; la Vista dibuja el resultado.

## La API (lo que atiende el controlador de C#)

| Método | Ruta                        | Qué hace |
|--------|-----------------------------|----------|
| GET    | `/api/tareas`               | Devuelve todas las tareas |
| POST   | `/api/tareas`               | Agrega una tarea (envía `{ "texto": "..." }`) |
| PUT    | `/api/tareas/{id}/alternar` | Marca o desmarca la tarea |
| DELETE | `/api/tareas/{id}`          | Elimina la tarea |

## Cómo ejecutarlo

Desde la carpeta del proyecto:

```bash
dotnet run
```

Luego abre en el navegador la dirección que muestra la consola (por ejemplo
`http://localhost:5000`). Verás la lista; puedes agregar, marcar y borrar tareas.
Cada acción viaja a la API de C# y vuelve.

## Cómo fluye una acción (ejemplo: marcar una tarea)

1. Haces clic en el texto de la tarea → la **Vista** (JavaScript) lo detecta.
2. La Vista hace un `fetch` con `PUT` a `/api/tareas/{id}/alternar`.
3. El **Controlador** de C# recibe la petición y le pide al **Modelo**
   (`RepositorioTareas`) que alterne la tarea.
4. El Controlador responde; la Vista vuelve a pedir la lista y la redibuja.

Este es exactamente el ciclo cliente–servidor de la Sesión 1: petición y respuesta.

## Relación con lo que sigue

- Aquí la Vista es JavaScript vanilla. En la **Unidad 7** esa Vista se escribirá
  con **Razor** (`.cshtml`) del lado del servidor; el Modelo y el Controlador de C#
  seguirán siendo iguales.
- En la **Sesión 2** de esta unidad construiremos una app MVC paso a paso.

## Nota

En este entorno no había `dotnet` para compilar, así que la lógica de los
endpoints se verificó reproduciéndola con un servidor equivalente y probando
cada operación (GET, POST, PUT, DELETE). El código C# no pasó por el compilador,
pero está escrito para correr con `dotnet run`.
