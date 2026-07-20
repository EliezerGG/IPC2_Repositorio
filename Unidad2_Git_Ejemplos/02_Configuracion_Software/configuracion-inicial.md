# 02. Configuración inicial de Git y conexión con un remoto

Guía de los comandos que se ejecutan **una sola vez por computadora** (o por
proyecto) para dejar Git listo, y de cómo conectar un repositorio local con uno
remoto (GitHub / GitLab).

---

## 1. Configuración global (una vez por computadora)

`--global` guarda la configuración en tu usuario del sistema; aplica a **todos**
tus repositorios. (Sin `--global`, aplicaría solo al repo actual → `--local`.)

```bash
git config --global user.name "Tu Nombre Completo"
#   Nombre que quedará registrado como autor en cada commit.

git config --global user.email "tucorreo@ejemplo.com"
#   Correo del autor. Debe coincidir con el de GitHub/GitLab para que
#   te reconozca las contribuciones.

git config --global init.defaultBranch main
#   Hace que "git init" cree la rama principal con el nombre "main"
#   (en vez del antiguo "master").
```

Verificar la configuración:

```bash
git config --global --list        # Lista toda tu configuración global
git config user.name              # Muestra un valor específico
```

---

## 2. Conectar un repositorio LOCAL con uno REMOTO

Escenario: ya tienes un proyecto con commits locales y creaste un repositorio
vacío en GitHub.

```bash
git remote add origin https://github.com/usuario/mi-repo.git
#   Registra el remoto y le pone el apodo "origin" (nombre estándar).
#   origin = la URL a la que empujarás (push) y de la que jalarás (pull).

git branch -M main
#   Renombra la rama actual a "main" por si acaso (-M = forzar renombre).

git push -u origin main
#   Sube (push) los commits de la rama "main" al remoto "origin".
#   -u  (--set-upstream): vincula tu "main" local con "origin/main",
#       para que después baste con escribir "git push" o "git pull".
```

Ver / quitar remotos:

```bash
git remote -v                     # Lista los remotos configurados y sus URLs
git remote remove origin          # Elimina el remoto llamado "origin"
```

---

## 3. Clonar un repositorio existente

Escenario: el proyecto ya está en el remoto y quieres una copia local.

```bash
git clone https://github.com/usuario/mi-repo.git
#   Descarga TODO el repositorio (historial completo) y crea una carpeta
#   "mi-repo" con el remoto "origin" ya configurado automáticamente.

git clone https://github.com/usuario/mi-repo.git mi-carpeta
#   Igual que arriba pero clona dentro de una carpeta llamada "mi-carpeta".
```

---

## 4. Flujo diario básico (después de conectar el remoto)

```bash
git pull            # Baja los cambios del remoto y los fusiona en tu rama actual
git add .           # Prepara TODOS los cambios (respetando .gitignore)
git commit -m "..." # Guarda un snapshot local con un mensaje descriptivo
git push            # Sube tus commits al remoto (ya vinculado con -u)
```

---

## 5. El archivo `.gitignore`

En esta misma carpeta encontrarás un **`.gitignore` real y comentado** para
proyectos C#/.NET. Se coloca en la raíz del repositorio **antes** del primer
`git add`, para que Git nunca versione carpetas generadas como `bin/` u `obj/`.
