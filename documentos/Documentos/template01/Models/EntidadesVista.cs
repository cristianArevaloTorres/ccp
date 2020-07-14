using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace template01.Models
{

    public class DocumentosAdjuntar
    {


        public int nDocumentoAdjuntado { get; set; }
        public int idRegistro { get; set; }
        public int bProcesado { get; set; }
        public string vNombreDocumento { get; set; }
        public string vTipoExtension { get; set; }
        public string dtFechaCarga { get; set; }
        public string vTipoDocumento { get; set; }
    }


    public class usuarios1
    {
        public int idusuario { get; set; }
        public int idsistema { get; set; }
        public string vusuario { get; set; }
        public string contraseña { get; set; }    
    }
    public class usuariosInfo2
    {
        public int idusuario { get; set; }
        public string vtipo { get; set; }
        public string nombre { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string correo { get; set; }
        public string usuario { get; set; }
        public string vrazon { get; set; }
        public int edad { get; set; }

    }

    public class usuariossocios17
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; }

        public string nosbres { get; set; }
        public string ap { get; set; }
        public string am { get; set; }
        public int edad { get; set; }
        public string descripcion { get; set; }

    }



}