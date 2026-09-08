// controlador: conecta el modelo con la vista.
// escucha lo que hace el usuario y mantiene todo sincronizado.
class Controlador {
    // constructor: recibe el modelo y la vista ya creados
    constructor(modelo, vista) {
        // guarda el modelo (los datos)
        this.modelo = modelo;
        // guarda la vista (lo que se ve)
        this.vista = vista;

        // le dice a la vista que hacer cuando se agrega una tarea
        this.vista.alAgregar((texto) => this.agregar(texto));
        // le dice a la vista que hacer con los clics en la lista
        this.vista.alClicEnLista(
            // que hacer al alternar una tarea
            (id) => this.alternar(id),
            // que hacer al eliminar una tarea
            (id) => this.eliminar(id)
        );

        // dibuja las tareas iniciales al arrancar la aplicacion
        this.refrescar();
    }

    // agrega una tarea y vuelve a dibujar
    agregar(texto) {
        // pide al modelo que agregue la tarea
        this.modelo.agregar(texto);
        // actualiza lo que se ve en la pagina
        this.refrescar();
    }

    // alterna una tarea (hecha / no hecha) y vuelve a dibujar
    alternar(id) {
        // pide al modelo que cambie el estado de la tarea
        this.modelo.alternar(id);
        // actualiza lo que se ve en la pagina
        this.refrescar();
    }

    // elimina una tarea y vuelve a dibujar
    eliminar(id) {
        // pide al modelo que elimine la tarea
        this.modelo.eliminar(id);
        // actualiza lo que se ve en la pagina
        this.refrescar();
    }

    // toma las tareas del modelo y le pide a la vista que las muestre
    refrescar() {
        // le pasa las tareas actuales del modelo a la vista
        this.vista.mostrarTareas(this.modelo.tareas);
    }
}
