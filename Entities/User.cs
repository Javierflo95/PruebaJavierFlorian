using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public int id { get; set; }
        [Display(Name = "Nombre de Usuario")]
        [Required(ErrorMessage = "La fecha de creacion es requerido")]
        public string userName { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string nombre { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string apellido { get; set; }
        [Display(Name = "Edad")]
        public int edad { get; set; }
        [Display(Name = "Estado")]
        public bool estado { get; set; }
        [Display(Name = "Contraseña")]
        public string password { get; set; }
        [Display(Name = "Cerar Tarea")]
        public bool crearTarea { get; set; }
        public List<Task> listTask { get; set; }
    }
}
