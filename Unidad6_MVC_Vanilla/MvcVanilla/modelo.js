// modelo: guarda los datos y la logica de las tareas.
// no sabe nada de html; solo maneja la informacion.
class Modelo {
    // constructor: prepara los datos iniciales
    constructor() {
        // arreglo donde se guardan todas las tareas
        this.tareas = [
            // cada tarea tiene un id, un texto y si esta hecha
            { id: 1, texto: "Estudiar el patron MVC", hecha: false },
            // una segunda tarea de ejemplo, ya marcada como hecha
            { id: 2, texto: "Repasar C#", hecha: true }
        ];
        // guarda el siguiente id disponible para una tarea nueva
        this.siguienteId = 3;
    }

    // agrega una tarea nueva con el texto recibido
    agregar(texto) {
        // crea el objeto de la tarea con el id actual
        const tarea = { id: this.siguienteId, texto: texto, hecha: false };
        // mete la tarea al final del arreglo
        this.tareas.push(tarea);
        // aumenta el id para la proxima tarea
        this.siguienteId++;
    }

    // elimina la tarea que tenga el id indicado
    eliminar(id) {
        // se queda solo con las tareas cuyo id es distinto al borrado
        this.tareas = this.tareas.filter(function (t) {
            // devuelve true para conservar la tarea
            return t.id !== id;
        });
    }

    // cambia una tarea de hecha a no hecha (o al reves)
    alternar(id) {
        // recorre todas las tareas buscando la del id
        this.tareas.forEach(function (t) {
            // si es la tarea buscada, invierte su estado
            if (t.id === id) {
                // hecha pasa a lo contrario de lo que era
                t.hecha = !t.hecha;
            }
        });
    }
}
