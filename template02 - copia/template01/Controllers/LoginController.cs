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
                _listasocios =  serv.BuscarUsuario(usuario, contraseña, cadena);
            
                if (_listasocios.Count > 0)
                {
                    //crear session 
                    respuesta = "1";
                    entidd = _listasocios.FirstOrDefault();
                    Session["idUsuario"] = entidd.idusuario;
                    Session["nombre"] = entidd.nombre;
                    Session["vtipo"] = entidd.vtipo;
                    Session["apellidoP"] = entidd.apellidoP;
                    Session["apellidoM"] = entidd.apellidoM;
                    Session["usuario"] = entidd.usuario;
                    RedirectToAction("Principal", "Login");
                }
                else {
                    respuesta = "0";
                }


            }
            catch (Exception ex)
            {

            }            
            return Json(respuesta, JsonRequestBehavior.AllowGet);


        }


        //[HttpPost]
        //public ActionResult Index(PaginaInicio datos)
        //{
        //    try
        //    {
        //        CargaSesionConvocatoria();
        //        datos.EsConvocatoriaCerrada = EsConvocatoriaCerrada();
        //        datos.EsConvocatoriaPausada = datos.EsConvocatoriaCerrada ? false : EsConvocatoriaPausada();
        //        datos.TextoHorario = GeneraMensajeConvocatoriaPausada();

        //        return View(datos);
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.MensajeUsuario = MensajeUsuario.GeneraHtmlMensaje(ex.GetBaseException().Message, ex);
        //        return View(datos);
        //    }
        //}

        //public ActionResult Sesion()
        //{
        //    try
        //    {
        //        CargaSesionConvocatoria();
        //        ViewBag.EsConvocatoriaCerrada = EsConvocatoriaCerrada();
        //        ViewBag.EsConvocatoriaPausada = ViewBag.EsConvocatoriaCerrada ? false : EsConvocatoriaPausada();

        //        System.Web.HttpContext.Current.Session["usuarioAutenticado"] = null;

        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.MensajeUsuario = MensajeUsuario.GeneraHtmlMensaje(ex.GetBaseException().Message, ex);
        //        return View();
        //    }

        //}

        //[HttpPost]
        //public ActionResult Sesion(FormCollection datos)
        //{

        //    try
        //    {
        //        CargaSesionConvocatoria();
        //        ViewBag.EsConvocatoriaCerrada = EsConvocatoriaCerrada();
        //        ViewBag.EsConvocatoriaPausada = ViewBag.EsConvocatoriaCerrada ? false : EsConvocatoriaPausada();


        //        Service.Login.LoginService servicio = new Service.Login.LoginService();
        //        var usuario = servicio.ValidaUsuarioAcceso(datos["usuario"], datos["contraseña"]);
        //        System.Web.HttpContext.Current.Session["usuarioAutenticado"] = usuario;

        //        string accionSiguiente = servicio.ObtenSiguienteAccionLogin(usuario.EstatusActual, datos["usuario"]);
        //        if (accionSiguiente == null)
        //            return RedirectToAction("Index", "Principal", new { Area = "Home" });
        //        else
        //            return RedirectToAction(accionSiguiente, "Principal", new { Area = "Registro" });
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.MensajeUsuario = MensajeUsuario.GeneraHtmlMensaje(ex.GetBaseException().Message, ex);
        //        return View();
        //    }
        //}

    }
}