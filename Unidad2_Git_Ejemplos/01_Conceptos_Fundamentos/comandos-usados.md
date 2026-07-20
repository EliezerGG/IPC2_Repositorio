# Comandos usados — 01. Conceptos y Fundamentos

Secuencia **exacta** de comandos Git ejecutados para construir el historial de
`demo-repo/`. Cada bloque corresponde a un paso; el comentario `#` explica qué
hace cada comando.

> Nota: entre cada `git commit` se editó el archivo `Program.cs` para simular la
> evolución del proyecto (agregar funciones, corregir un bug).

## Inicialización

```bash
git init -b main                 # Crea un repositorio Git nuevo con la rama principal llamada "main"
git config user.name "Auxiliar IPC2"           # Define el nombre del autor de los commits (solo en este repo)
git config user.email "auxiliar.ipc2@usac.edu.gt"   # Define el correo del autor de los commits (solo en este repo)
```

## Commit 1 — Commit inicial

```bash
# (se crean los archivos Program.cs y README.md)
git add Program.cs README.md     # Agrega ambos archivos al "staging area" (área de preparación)
git commit -m "Commit inicial"   # Guarda una foto (snapshot) del proyecto con ese mensaje
```

## Commit 2 — Agrega función sumar

```bash
# (se edita Program.cs para agregar el método Sumar)
git add Program.cs                       # Prepara los cambios de Program.cs para el próximo commit
git commit -m "Agrega función sumar"     # Registra el cambio en el historial
```

## Commit 3 — Agrega función validar nota

```bash
# (se edita Program.cs para agregar el método ValidarNota, que trae un bug intencional)
git add Program.cs                             # Prepara los cambios
git commit -m "Agrega función validar nota"    # Registra el nuevo método en el historial
```

## Commit 4 — Corrige bug en validación

```bash
# (se edita Program.cs: se cambia "< 100" por "<= 100" para aceptar la nota máxima)
git add Program.cs                          # Prepara la corrección
git commit -m "Corrige bug en validación"   # Registra el fix en el historial
```

## Verificación del historial

```bash
git log --graph --oneline --all --decorate   # Muestra el árbol de commits en una línea por commit
git log                                       # Muestra el historial completo con autor, fecha y mensaje
git status                                    # Muestra el estado actual (archivos modificados / limpios)
```

## Comandos útiles para explorar en clase

```bash
git show HEAD          # Muestra el último commit y qué líneas cambió
git diff HEAD~1 HEAD   # Compara el último commit contra el anterior
git log --oneline      # Lista compacta de todos los commits
```
