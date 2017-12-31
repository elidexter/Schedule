using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concert.Models
{
    public class Programacion
    {
        public long PgrId { get; set; }
        public long SalaId { get; set; }
        public String Encargado { get; set; }
        public String Contacto { get; set; }
        public DateTime From { get; set; }
        public DateTime Hasta { get; set; }
        public String EventoNombre { get; set; }
    }
}