using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Task
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public User user { get; set; }
    }
}
