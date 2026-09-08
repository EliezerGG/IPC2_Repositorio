// vista: se encarga de mostrar las tareas en la pagina.
// no tiene logica de negocio; solo dibuja y avisa de los clics.
class Vista {
    // constructor: guarda las referencias a los elementos del html
    constructor() {
        // el campo de texto donde se escribe una tarea
        this.entrada = document.getElementById("entrada");
        // el boton para agregar una tarea
        this.boton = document.getElementById("boton-agregar");
        // la lista donde se muestran las tareas
        this.lista = document.getElementById("lista-tareas");
    }

    // dibuja en la pagina la lista de tareas que recibe
    mostrarTareas(tareas) {
        // borra lo que habia dibujado antes en la lista
        this.lista.innerHTML = "";
        // recorre cada tarea para crear su elemento visual
        tareas.forEach((tarea) => {
            // crea el elemento li de la tarea
            const li = document.createElement("li");
            // guarda el id dentro del elemento para ubicarlo despues
            li.dataset.id = tarea.id;
            // si la tarea esta hecha, le agrega una clase para tacharla
            if (tarea.hecha) {
                li.classList.add("hecha");
            }

            // crea el texto de la tarea
            const span = document.createElement("span");
            // coloca el texto de la tarea dentro del span
            span.textContent = tarea.texto;
            // marca el span como texto para saber que al hacer clic se alterna
            span.classList.add("texto");

            // crea el boton para borrar la tarea
            const borrar = document.createElement("button");
            // coloca una equis como contenido del boton
            borrar.textContent = "x";
            // marca el boton como borrar para reconocerlo al hacer clic
            borrar.classList.add("borrar");

            // mete el texto dentro del li
            li.appendChild(span);
            // mete el boton borrar dentro del li
            li.appendChild(borrar);
            // mete el li dentro de la lista de la pagina
            this.lista.appendChild(li);
        });
    }

    // registra que hacer cuando el usuario agrega una tarea
    alAgregar(manejador) {
        // cuando se hace clic en el boton agregar
        this.boton.addEventListener("click", () => {
            // toma el texto escrito y le quita los espacios de los lados
            const texto = this.entrada.value.trim();
            // solo si hay texto escrito
            if (texto !== "") {
                // llama al manejador que dio el controlador, con el texto
                manejador(texto);
                // limpia el campo de texto para la proxima
                this.entrada.value = "";
            }
        });
    }

    // registra que hacer cuando el usuario hace clic dentro de la lista
    alClicEnLista(alAlternar, alEliminar) {
        // un solo listener en la lista (esto se llama delegacion de eventos)
        this.lista.addEventListener("click", (evento) => {
            // busca el li mas cercano al lugar donde se hizo clic
            const li = evento.target.closest("li");
            // si el clic no fue sobre una tarea, no hace nada
            if (!li) {
                return;
            }
            // recupera el id de la tarea (viene como texto y se pasa a numero)
            const id = Number(li.dataset.id);
            // si el clic fue en el boton borrar, avisa que hay que eliminar
            if (evento.target.classList.contains("borrar")) {
                alEliminar(id);
            // si el clic fue en el texto, avisa que hay que alternar
            } else if (evento.target.classList.contains("texto")) {
                alAlternar(id);
            }
        });
    }
}
