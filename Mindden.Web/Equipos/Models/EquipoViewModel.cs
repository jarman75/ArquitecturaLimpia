using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mindden.Web.Equipos.Models
{
    public class EquipoViewModel
    {
        [Required(ErrorMessage = "Nombre requerido")]
        public string NombrEquipo { get; set; }

        [Required(ErrorMessage = "Ubicacion requerida")]
        public string Ubicacion { get; set; }

        [Required(ErrorMessage = "Cliente requerido")]
        public string Cliente { get; set; }
    }
}