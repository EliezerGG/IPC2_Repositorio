using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploMVC.Data
{
    public class RepositorioTareas
    {
        private readonly List<Tarea> _tareas = new(){
            new Tarea { Id = 1, Texto = "Aprender MVC", Hecha = false },
            new Tarea { Id = 2, Texto = "Aprender Blazor", Hecha = false }
        }

        // guarda el siguiente id disponible para una tarea nueva
        private int _siguienteId = 3;

        // devuelve todas las tareas
        public List<Tarea> ObtenerTodas()
        {
            // entrega la lista completa
            return _tareas;
        }

        // agrega una tarea nueva con el texto recibido y la devuelve
        public Tarea Agregar(string texto)
        {
            // crea la tarea con el id actual
            var tarea = new Tarea { Id = _siguienteId, Texto = texto, Hecha = false };
            // aumenta el id para la proxima tarea
            _siguienteId++;
            // agrega la tarea a la lista
            _tareas.Add(tarea);
            // devuelve la tarea recien creada
            return tarea;
        }

        // cambia una tarea de hecha a no hecha; devuelve true si la encontro
        public bool Alternar(int id)
        {
            // busca la tarea por su id
            var tarea = _tareas.FirstOrDefault(t => t.Id == id);
            // si no existe, avisa que no se pudo
            if (tarea == null) return false;
            // invierte el estado de hecha
            tarea.Hecha = !tarea.Hecha;
            // avisa que si se logro
            return true;
        }

        // elimina la tarea con el id indicado; devuelve true si la encontro
        public bool Eliminar(int id)
        {
            // busca la tarea por su id
            var tarea = _tareas.FirstOrDefault(t => t.Id == id);
            // si no existe, avisa que no se pudo
            if (tarea == null) return false;
            // quita la tarea de la lista
            _tareas.Remove(tarea);
            // avisa que si se logro
            return true;
        }
    }
}