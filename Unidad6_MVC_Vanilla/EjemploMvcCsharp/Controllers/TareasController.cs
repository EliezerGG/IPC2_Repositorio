using Microsoft.AspNetCore.Mvc;
using EjemploMvcCsharp.Data;

namespace EjemploMvcCsharp.Controllers
{
    // controlador: recibe las peticiones http y coordina el trabajo.
    // el primer atributo marca la clase como un controlador de api
    // (activa validaciones y otras ayudas utiles).
    [ApiController]
    // el segundo atributo fija la ruta base: todo cuelga de /api/tareas
    [Route("api/tareas")]
    public class TareasController : ControllerBase
    {
        // referencia al repositorio (los datos del modelo)
        private readonly RepositorioTareas _repositorio;

        // el repositorio llega por inyeccion de dependencias
        public TareasController(RepositorioTareas repositorio)
        {
            // guarda el repositorio recibido
            _repositorio = repositorio;
        }

        // get /api/tareas -> devuelve todas las tareas en formato json
        [HttpGet]
        public IActionResult ObtenerTareas()
        {
            // pide las tareas al repositorio y responde con codigo 200 (ok)
            return Ok(_repositorio.ObtenerTodas());
        }

        // post /api/tareas -> agrega una tarea nueva (el texto viene en el cuerpo)
        [HttpPost]
        public IActionResult AgregarTarea([FromBody] NuevaTarea entrada)
        {
            // si no llego texto valido, responde error 400 (bad request)
            if (entrada == null || string.IsNullOrWhiteSpace(entrada.Texto))
                return BadRequest("el texto es obligatorio");
            // pide al repositorio que agregue la tarea
            var tarea = _repositorio.Agregar(entrada.Texto);
            // responde con la tarea creada
            return Ok(tarea);
        }

        // put /api/tareas/5/alternar -> marca o desmarca la tarea con ese id
        [HttpPut("{id}/alternar")]
        public IActionResult AlternarTarea(int id)
        {
            // pide al repositorio que alterne la tarea
            var ok = _repositorio.Alternar(id);
            // si no existe, responde 404 (not found)
            if (!ok) return NotFound();
            // responde que salio bien
            return Ok();
        }

        // delete /api/tareas/5 -> elimina la tarea con ese id
        [HttpDelete("{id}")]
        public IActionResult EliminarTarea(int id)
        {
            // pide al repositorio que elimine la tarea
            var ok = _repositorio.Eliminar(id);
            // si no existe, responde 404 (not found)
            if (!ok) return NotFound();
            // responde que salio bien
            return Ok();
        }
    }

    // clase auxiliar para recibir el texto de una tarea nueva desde el json
    public class NuevaTarea
    {
        // el texto que envia el navegador
        public string Texto { get; set; }
    }
}
