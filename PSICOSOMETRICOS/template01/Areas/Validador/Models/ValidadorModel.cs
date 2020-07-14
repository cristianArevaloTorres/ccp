using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senado.Convocatoria.Areas.Validador.Models
{
    public class ValidadorModel
    {

        [Display(Name = "vApellidoMaterno")]
        public string vApellidoMaterno { get; set; }

        [Display(Name = "vApellidoPaterno")]
        public string vApellidoPaterno { get; set; }

        [Display(Name = "vNombre")]
        public string vNombre { get; set; }

        [Display(Name = "idPerfil")]
        public int idPerfil { get; set; }


        [Display(Name = "idUsuario")]
        public int idUsuario { get; set; }
    }
}