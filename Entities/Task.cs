using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Task
    {
        public int id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string nombre { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }
        [Display(Name = "Fecha Creacion")]
        [Required(ErrorMessage = "La fecha de creacion es requerido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime fechaCreacion { get; set; }

        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [Display(Name = "Fecha Vencimiento")]
        [Required(ErrorMessage = "La fecha de Vencimiento es requerido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime fechaVencimiento { get; set; }
        [Display(Name = "Usuario")]
        public User user { get; set; }
    }
}
