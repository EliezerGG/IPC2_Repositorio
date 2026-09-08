using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploMVC.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public bool Hecha { get; set; }
    }
}