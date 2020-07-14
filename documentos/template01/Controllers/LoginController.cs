//using Senado.Convocatoria.Models;
//using Senado.Convocatoria.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using YCP_DATA;

namespace template01.Controllers
{
    public class LoginController : BaseController
    {
        //private string GeneraMensajeConvocatoriaPausada()
        //{
        //    //var convocatoria = ObtenConvocatoriaInfoSesion();            
        //    //if (convocatoria.HorarioTexto?.Contains("@horario@") == true) {
        //    //    if (convocatoria.HoraApertura.HasValue && convocatoria.HoraCerrado.HasValue)
        //    //        return convocatoria.HorarioTexto.Replace("@horario@", $"{convocatoria.HoraApertura.Value.ToString("hh\\:mm")} a {convocatoria.HoraCerrado.Value.ToString("hh\\:mm")}");
        //    //    else
        //    //        return convocatoria.HorarioTexto.Replace("@horario@", "00:00 a 23:59");
        //    //}
        //    //else return convocatoria.HorarioTexto;

        //}
        public ActionResult Login()
        {
            Session["idUsuario"] = null;
            Session["nombre"] = null;
            Session["vtipo"] = null;
            Session["apellidoP"] = null;
            Session["apellidoM"] = null;
            Session["usuario"] = null;
            return View();
        }
        
        public JsonResult ValidarUser(string usuario = "", string contraseña= "")
        {
            string respuesta = "0";
            try
            {
                string cadena = WebConfigurationManager.ConnectionStrings["YCP_BD"].ConnectionString;
                loginData serv = new loginData();
                List<usuariosInfo2> _listasocios = new List<YCP_DATA.usuariosInfo2>();
                List<Models.usuariosInfo2> _listasociosvista = new List<Models.usuariosInfo2>();
                usuariosInfo2 entidd = new usuariosInfo2();
                //metodo para llenar la ssesion 
             //   _listasocios =  serv.BuscarUsuario(usuario, contraseña, cadena);
                respuesta = "1";
             
                Session["idUsuario"] = 101;
                Session["nombre"] = "Usuario";
                Session["vtipo"] = "tipo";
                Session["apellidoP"] = "de";
                Session["apellidoM"] = "prueba";
                Session["usuario"] = "arturo.castillo";
                Session["area"] = "areaejemplo";
                RedirectToAction("Principal", "Login");
                if (_listasocios.Count > 0)
                {
                    //crear session 
                //    respuesta = "1";
                //    //   entidd = 0;//_listasocios.FirstOrDefault();
                //    Session["idUsuario"] = 101;
                //    Session["nombre"] = "Usuario";
                //    Session["vtipo"] = "tipo";
                //    Session["apellidoP"] = "de";
                //    Session["apellidoM"] = "prueba";
                //    Session["usuario"] = "arturo.castillo";
                //    RedirectToAction("Principal", "Login");
                }
                else {
                    respuesta = "1";
                }


            }
            catch (Exception ex)
            {

            }            
            return Json(respuesta, JsonRequestBehavior.AllowGet);


        }



    }
}