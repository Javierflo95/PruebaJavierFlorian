using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string userName { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string apellido { get; set; }
        public int edad { get; set; }
        public bool estado { get; set; }
        public string password { get; set; }
        public bool crearTarea { get; set; }
        public List<Task> listTask { get; set; }
    }
}
