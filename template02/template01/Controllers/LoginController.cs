//using Senado.Convocatoria.Models;
//using Senado.Convocatoria.Utilidades;
using System;
using System.Linq;
using System.Web.Mvc;


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

            return View();
        }
        public ActionResult Principal()
        {

            return View();
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