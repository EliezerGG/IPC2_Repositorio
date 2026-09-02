# EjemploWeb — Página HTML + CSS comentada

Una página web completa (la de un taller) que usa los conceptos de la Unidad 5.
Cada línea del código está **comentada** para explicar qué hace, y los comentarios
están en **minúsculas, sin tildes y sin "ñ"**.

## Archivos

- `index.html` — la estructura y el contenido de la página.
- `estilos.css` — la hoja de estilos externa (colores, tipografía, tablas, formulario).
- `imagen.jpg` — una imagen de ejemplo para la sección de información.
- `preview.png` — una captura de cómo se ve la página ya renderizada.

## Cómo verlo

Abre `index.html` con cualquier navegador (doble clic). El navegador leerá el
HTML, aplicará el `estilos.css` (conectado con `<link>`) y mostrará el resultado.

## Qué conceptos de la unidad usa

Estructura básica
- `<!DOCTYPE html>`, `<html>`, `<head>` y `<body>`.
- Etiquetas semánticas de HTML5: `<header>`, `<nav>`, `<main>`, `<section>`, `<footer>`.

Componentes
- Párrafos y títulos: `<h1>`, `<h2>`, `<p>`, `<strong>`, `<em>`.
- Atributos: `href`, `src`, `alt`, `id`, `class`, `for`.
- Imagen: `<img>`.
- Listas: `<ul>` con `<li>`.
- Tabla: `<table>`, `<tr>`, `<th>`, `<td>`.
- Formulario: `<form>`, `<label>`, `<input>`, `<select>`, `<option>`, `<button>`.
- Tipos de input: `text`, `email`, `password`, `number`.
- Atributos de input: `type`, `name`, `id`, `placeholder`, `required`, `min`, `max`.

CSS
- Conexión externa con `<link rel="stylesheet" href="estilos.css">`.
- Variables CSS declaradas en `:root` y usadas con `var(--nombre)`.
- Sintaxis `selector { propiedad: valor; }`.
- Selectores: por etiqueta (`body`, `h2`, `table`), por clase (`.cabecera`, `.menu`),
  universal (`*`), descendiente (`.menu a`), agrupado (`th, td`) y pseudo-clase
  (`a:hover`, `button:hover`).
- Nociones del modelo de caja: `margin`, `padding`, `border`, `border-radius`,
  `box-sizing`, y un poco de `flexbox` (`display: flex`).

## Ideas para practicar

- Cambia el valor de `--color-principal` en `:root` y observa cómo cambia toda la página.
- Agrega una nueva sección con otra tabla o una lista ordenada (`<ol>`).
- Agrega más tipos de input (por ejemplo `date`, `checkbox` o `radio`).
