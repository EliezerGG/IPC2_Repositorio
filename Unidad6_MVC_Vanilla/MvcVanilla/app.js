// app: crea las tres partes del mvc y arranca la aplicacion.
// se ejecuta cuando la pagina termina de cargar.
window.addEventListener("DOMContentLoaded", () => {
    // crea el modelo (los datos y su logica)
    const modelo = new Modelo();
    // crea la vista (lo que se ve en la pantalla)
    const vista = new Vista();
    // crea el controlador y le entrega el modelo y la vista
    new Controlador(modelo, vista);
});
