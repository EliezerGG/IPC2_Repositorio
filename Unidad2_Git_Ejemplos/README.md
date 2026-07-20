# Unidad 2 — Manejo de Versiones (Git)

Material **demostrativo** para el instructor/auxiliar del curso **IPC2** —
Introducción a la Programación y Computación 2, Universidad de San Carlos de
Guatemala (USAC).

Estos **no** son ejercicios para resolver: son repositorios Git **reales y
funcionales**, con historial ya construido mediante comandos `git` reales,
listos para mostrar en clase en vivo o para que el estudiante los explore.

> Cada `demo-repo*/` contiene un `.git/` real. El instructor puede hacer `cd` a
> la carpeta y ejecutar comandos Git durante la clase (`git log`, `git show`,
> `git checkout`, etc.).

## Contenido

| Carpeta | Qué demuestra | Comando clave para explorarlo en clase |
|---|---|---|
| `01_Conceptos_Fundamentos/demo-repo/` | Flujo básico: `git init`, `add`, `commit` incrementales. Historial lineal de 4 commits que muestra la evolución de un mini proyecto C# (calculadora de notas) incluyendo la corrección de un bug. | `git log --graph --oneline --all --decorate` |
| `02_Configuracion_Software/` | Configuración de Git y del entorno: `.gitignore` real y comentado para C#/.NET, y comandos de `git config --global` + conexión con un remoto (`remote add`, `push -u`, `clone`). *(No es un repo, es material de referencia.)* | `cat .gitignore` &nbsp;·&nbsp; `git config --global --list` |
| `03_Troncales_Ramas/demo-repo-ramas/` | Flujo con ramas: commits en `main`, rama `feature/nueva-funcion` con `checkout -b`, 3 commits en la rama, regreso a `main`, `merge --no-ff` y `tag v1.0`. | `git log --graph --oneline --all --decorate` |

## Cómo usar este material en clase

1. **Ver el árbol sin abrir Git:** cada carpeta de repo incluye
   `historial-visual.txt` con la salida ya capturada de
   `git log --graph --oneline --all --decorate`.
2. **Demostración en vivo:** `cd` a `demo-repo/` o `demo-repo-ramas/` y ejecuta
   los comandos Git directamente.
3. **Reproducir el historial:** cada repo trae un `comandos-usados.md` con la
   secuencia **exacta** de comandos usados para construirlo, con un comentario
   por comando.

## Recorrido sugerido

```text
01_Conceptos_Fundamentos   →  ¿Qué es un commit? ¿Cómo evoluciona un proyecto?
02_Configuracion_Software  →  ¿Cómo dejo Git listo y lo conecto a GitHub?
03_Troncales_Ramas         →  ¿Cómo trabajo con ramas, fusiono y etiqueto versiones?
```

## Nota técnica

Los repositorios se construyeron con una identidad local de demostración
(`Auxiliar IPC2 <auxiliar.ipc2@usac.edu.gt>`), configurada por-repo con
`git config user.name/user.email`, para que los commits sean reproducibles sin
depender de la configuración global de cada máquina.
