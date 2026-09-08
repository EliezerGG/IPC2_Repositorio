// este archivo es la vista del lado del navegador.
// pide los datos a la api de c# y dibuja las tareas en la pagina.
// la logica de verdad (modelo y controlador) esta en el servidor, en c#.

// direccion de la api que responde el servidor de c#
const API = "/api/tareas";

// referencia al campo de texto
const entrada = document.getElementById("entrada");
// referencia al boton de agregar
const boton = document.getElementById("boton-agregar");
// referencia a la lista donde se dibujan las tareas
const lista = document.getElementById("lista-tareas");

// pide las tareas a la api (peticion get) y las dibuja
async function cargarTareas() {
    // hace la peticion get a la api
    const respuesta = await fetch(API);
    // convierte la respuesta json en un arreglo de tareas
    const tareas = await respuesta.json();
    // dibuja las tareas recibidas
    mostrarTareas(tareas);
}

// dibuja en la pagina la lista de tareas recibida
function mostrarTareas(tareas) {
    // borra lo que habia antes en la lista
    lista.innerHTML = "";
    // recorre cada tarea para crear su elemento visual
    tareas.forEach(function (tarea) {
        // crea el li de la tarea
        const li = document.createElement("li");
        // si la tarea esta hecha, le agrega la clase para tacharla
        if (tarea.hecha) li.classList.add("hecha");

        // crea el texto de la tarea
        const span = document.createElement("span");
        // coloca el texto de la tarea
        span.textContent = tarea.texto;
        // marca el span como texto
        span.classList.add("texto");
        // al hacer clic en el texto, pide a la api alternar la tarea
        span.addEventListener("click", function () { alternarTarea(tarea.id); });

        // crea el boton para borrar la tarea
        const borrar = document.createElement("button");
        // coloca una equis como contenido
        borrar.textContent = "x";
        // marca el boton como borrar
        borrar.classList.add("borrar");
        // al hacer clic, pide a la api eliminar la tarea
        borrar.addEventListener("click", function () { eliminarTarea(tarea.id); });

        // mete el texto y el boton dentro del li
        li.appendChild(span);
        li.appendChild(borrar);
        // mete el li dentro de la lista
        lista.appendChild(li);
    });
}

// envia a la api una tarea nueva (peticion post con json)
async function agregarTarea(texto) {
    // hace la peticion post con el texto en el cuerpo
    await fetch(API, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ texto: texto })
    });
    // vuelve a cargar las tareas para ver el cambio
    cargarTareas();
}

// pide a la api alternar una tarea (peticion put)
async function alternarTarea(id) {
    // hace la peticion put a la ruta de alternar
    await fetch(API + "/" + id + "/alternar", { method: "PUT" });
    // recarga la lista
    cargarTareas();
}

// pide a la api eliminar una tarea (peticion delete)
async function eliminarTarea(id) {
    // hace la peticion delete a la ruta de la tarea
    await fetch(API + "/" + id, { method: "DELETE" });
    // recarga la lista
    cargarTareas();
}

// cuando se hace clic en agregar, manda el texto a la api
boton.addEventListener("click", function () {
    // toma el texto sin espacios de los lados
    const texto = entrada.value.trim();
    // si hay texto, lo agrega y limpia el campo
    if (texto !== "") {
        agregarTarea(texto);
        entrada.value = "";
    }
});

// al cargar la pagina, pide las tareas por primera vez
cargarTareas();
