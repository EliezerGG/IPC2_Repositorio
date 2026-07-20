# Comandos usados — 03. Troncales y Ramas

Secuencia **exacta** de comandos Git ejecutados para construir el historial de
`demo-repo-ramas/`. Demuestra un flujo completo de ramas: trabajo en `main`,
creación de una rama de trabajo, commits en esa rama, regreso a `main`, `merge`
y etiquetado (`tag`).

## Inicialización y primeros commits en main

```bash
git init -b main                                    # Crea el repositorio con la rama principal "main"
git config user.name "Auxiliar IPC2"                # Define el nombre del autor (solo en este repo)
git config user.email "auxiliar.ipc2@usac.edu.gt"   # Define el correo del autor (solo en este repo)

# (se crea Program.cs)
git add Program.cs
git commit -m "Commit inicial en main"              # Primer commit en la rama main

# (se edita Program.cs agregando el menú)
git add Program.cs
git commit -m "Agrega menú principal en main"       # Segundo commit en main
```

## Creación de la rama de trabajo

```bash
git checkout -b feature/nueva-funcion   # Crea la rama "feature/nueva-funcion" Y se cambia a ella (-b = crear)
```

## Commits dentro de la rama feature/nueva-funcion

```bash
# (se crea Estudiante.cs)
git add Estudiante.cs
git commit -m "Agrega clase Estudiante"                        # Commit 1 en la rama

# (se edita Estudiante.cs agregando la nota y el método Aprobado)
git add Estudiante.cs
git commit -m "Agrega nota y método Aprobado a Estudiante"     # Commit 2 en la rama

# (se edita Program.cs para usar la clase Estudiante)
git add Program.cs
git commit -m "Usa clase Estudiante desde el menú principal"   # Commit 3 en la rama
```

## Regreso a main y fusión (merge)

```bash
git checkout main                                              # Vuelve a la rama principal
git merge --no-ff feature/nueva-funcion \
    -m "Merge de feature/nueva-funcion a main"                # Fusiona la rama en main creando un commit de merge
```

> **`--no-ff`** (no fast-forward): fuerza la creación de un commit de merge
> aunque Git pudiera avanzar en línea recta. Así el árbol muestra claramente
> que hubo una rama que se fusionó (ideal para enseñar el concepto).

## Etiquetar la versión

```bash
git tag -a v1.0 -m "Version 1.0 - gestión de estudiantes con soporte de notas"   # Crea una etiqueta anotada v1.0 sobre el último commit
```

> **`-a`** crea un *tag anotado* (guarda autor, fecha y mensaje). Es el tipo
> recomendado para marcar versiones de entrega.

## Verificación del historial

```bash
git log --graph --oneline --all --decorate   # Muestra el árbol con la rama, el merge y el tag
git branch                                    # Lista las ramas locales (la actual con *)
git tag                                       # Lista las etiquetas existentes
git show v1.0                                 # Muestra a qué commit apunta el tag v1.0
```

## Comandos útiles para explorar en clase

```bash
git log --graph --oneline --all              # Árbol compacto de todo el historial
git checkout feature/nueva-funcion           # Cambiar a la rama para ver sus archivos
git checkout main                            # Regresar a main
git diff main feature/nueva-funcion          # Ver diferencias entre ramas (si aún no se fusionara)
```
