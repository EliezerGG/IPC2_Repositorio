namespace EjemploMvcCsharp.Models
{
    // modelo: representa una tarea de la lista.
    // es una clase simple con los datos; no tiene logica de interfaz.
    public class Tarea
    {
        // identificador unico de la tarea (la clave)
        public int Id { get; set; }
        // el texto o descripcion de la tarea
        public string Texto { get; set; }
        // indica si la tarea ya esta hecha
        public bool Hecha { get; set; }
    }
}
