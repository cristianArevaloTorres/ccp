using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using YCP_DATA;

namespace template01.Controllers
{
    public class RegistrarseController : BaseController
    {
        // GET: Registrarse
        public ActionResult Index()
        {


            //YCPdata ACCIONES = new YCPdata();
            //string cadena = "";
            //cadena = WebConfigurationManager.ConnectionStrings["YCP_BD"].ConnectionString;
            //ACCIONES.IformacionUsuarios("coach", cadena);
            return View();
        }
        public ActionResult preregistro()
        {
            return View();
        }
        public JsonResult Registrar(string vtipo, string nombre, string apellidop ,string apellidom, string correo, string usuario, string vrazon, string edad,string pass)
        {
            int edadParam = 0;
            edadParam = Convert.ToInt32(edad);
            YCPdata ACCIONES = new YCPdata();
            string cadena = "";
         string   vmensaje = $@"<html>
                  <center><h1><strong>Bienvenido a:</strong></h1></center>
                    <center><h3><strong>Tu Couch Personal</strong></h3></center>
                            <br>
                            <br>
                            <br>
                    <p><center>
                    Usted ha concluido satisfactoriamente el procedimiento electrónico de Pre-registro.
                    <p>Este mensaje es el acuse de la recepción de su informacion para la cual obtendra beneficios adicionales en caso de que usted quiera adquirir </p>
                    <p>una membresia.</p>   
                    <br>
                    <br>
                    <p>el preregistro no lo compromete a comprar la membresia unicamente a gozar de descuentos en caso de que quiera adquirirla</p>   
                    </center></p>                    
                    <br>


                    
                <br/><p><h5>Este es un correo automático, sin embargo si tiene dudas podra responderlo sin ningun problema y en breve un especialista le atendera </h5></p>
                    <br>                 
                </ html > ";


            EnviaCorreo(correo, vmensaje, "Bienvenido Pre-registro exitoso");
            cadena = WebConfigurationManager.ConnectionStrings["YCP_BD"].ConnectionString;
           ACCIONES.guardarusuarios01(cadena, vtipo, nombre, apellidop, apellidom, correo, usuario, vrazon, edad, pass);
            return new JsonResult();
        }
        public ActionResult registrocoach()
        {
            return View();
        }
        public ActionResult registronutirologo()
        {
            return View();
        }
    }
}