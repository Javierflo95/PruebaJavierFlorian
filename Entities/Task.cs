using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Task
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public string fechaCreacion { get; set; }
        public string descripcion { get; set; }
        public string fechaVencimiento { get; set; }
        public User user { get; set; }
    }
}
