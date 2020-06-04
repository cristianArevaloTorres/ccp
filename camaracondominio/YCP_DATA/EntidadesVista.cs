using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YCP_DATA
{
    public class asesoriausuarios7
    {      
        public int idusuario { get; set; }
        public int idusuarionutco { get; set; }
        public int idregistro { get; set; }      
        public string vpregunta { get; set; }     
        public string vrespuesta { get; set; }
        public int idpregunta { get; set; }
        public int idrespuesta { get; set; }
        public string fecharegistro { get; set; }
        public string vtipocouch { get; set; }
        public string nombreCompleto { get; set; }
        

    }
    public class avances8
    {
        public int peso { get; set; }
        public int grasa { get; set; }
        public int musculo { get; set; }
        public int idusuario { get; set; }     

    }
    public class tareas9
    {
        public int idusuario { get; set; }
        public string vdecripciontarea { get; set; }
        public string vestatus { get; set; }
        public string tarea { get; set; }
        public string tiempotarea { get; set; }
        public string vigenciaI { get; set; }
        public string vigenciafinal { get; set; }
        public bool bcompletada { get; set; }  

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
    public class consultacliente
    {
        public int idusuario { get; set; }
        public string vtipo { get; set; }
        public string nombre { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string correo { get; set; }
        public string usuario { get; set; }
        public string vrazon { get; set; }
        public string vigenciaini { get; set; }
        public string vigenciafin { get; set; }
        public int diasrest { get; set; }
        public string registro { get; set; }

        public string anual { get; set; }
        public string mensual { get; set; }
        public int edad { get; set; }

    }
    public class recetas10
    {
        public int idreceta { get; set; }
        public string descripcion { get; set; }    
    }
    public class recetasAlimentos11
    {
        public int idreceta { get; set; }
        public int idalimentos { get; set; }
        public string descripcion { get; set; }
        public int idRegistro { get; set; }
        

    }

    public class Alimentos12
    {      
        public int idalimentos { get; set; }
        public string descripcion { get; set; }
    }

    public class menu3
    {
        public int idmenu { get; set; }
        public string ruta { get; set; }
        public string descricpion{ get; set; }
    }
    public class menuUsuarios4
    {
        public int idmenu { get; set; }
        public int idusuario { get; set; }
        public string descricpionrol { get; set; }
    }
    public class recetasUsuario5
    {
        public int idUsuario { get; set; }
        public int idcomida { get; set; }
 
        public int idAlimentoReceta { get; set; }
        public string Vdescripcion { get; set; }
     
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
    public class usuariossociosdet16
    {
        public int idUsuario { get; set; }
        public string comentario { get; set; }

        public string fecha { get; set; }
        public int calificacion { get; set; }
     

    }
    public class comidastipo6
    {
        public int idcomida { get; set; }
        public string descricpcion { get; set; }

    }

    public class PAGOS133
    {
        public int IDUSUARIO { get; set; }
        public string descricpcion { get; set; }
        public string BACTIVO { get; set; }
        public string VIGENCIAi { get; set; }
        public string VIGENCIAf { get; set; }
        public string BANUAL { get; set; }
        public string BMENSUAL { get; set; }

    } 

}