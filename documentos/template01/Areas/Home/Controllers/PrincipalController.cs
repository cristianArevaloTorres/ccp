using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Senado.Convocatoria;


namespace template01.Areas.Home.Controllers
{
    public class PrincipalController : BaseController
    {
        // GET: Home/Principal

        public static string idiomaSitio { get; set; }

        
        //public ActionResult Index(string lang)
        //{
        //    try
        //    {
        //        if (!CargaSesion())
        //            return RedirectToAction("Sesion", "Login", new { Area = "" });

        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.MensajeUsuario = MensajeUsuario.GeneraHtmlMensaje(ex.GetBaseException().Message, ex);
        //    }
        //        return View();
        //}
        //public JsonResult ObtieneVentanaTiempo(int idAspirante = 0)
        //{

        //    Service.Entidades.UsuarioSesion sesion = ObtenInfoSesion();
        //    //verificar que solo se muestre para los aspirantes 
        //    Service.Entidades.ConvocatoriaSesion info = new Service.Entidades.ConvocatoriaSesion();
        //    info = ObtenConvocatoriaInfoSesion();
        //    int diferencia = 2;
        //    if (sesion.IdPerfiles.Count() == 1 && sesion.IdPerfiles[0] == 4)
        //    {
        //        DateTime fechaActual = new Service.Comun.ServidorSevice().ObtenFechaHora();
        //        var respuesta = info.FehaHoraFin - fechaActual;   //una vez q es aspirante verificar que unicamente se muestre en el ultimo dia.
        //        diferencia = Convert.ToInt32(respuesta.TotalDays);
        //    }
          
        //    string fechafin = info.FehaHoraFin.ToString("yyyy/MM/dd HH:mm:ss");
        //    //para que solo se muestre el ultimo dia 
        //    if (diferencia > 1)
        //    {
        //        fechafin = "0001/01/01";
        //    }


        //    return Json(fechafin.ToJSON(), JsonRequestBehavior.AllowGet);

        //}

        //public PartialViewResult Menu()
        //{
        //    try
        //    {
        //        Service.Entidades.UsuarioSesion sesion = ObtenInfoSesion();
        //        return PartialView("_MenuPrincipal", sesion.MenuElementos);
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.MensajeUsuario = MensajeUsuario.GeneraHtmlMensaje(ex.GetBaseException().Message, ex);
        //    }
        //    return PartialView("_MenuPrincipal");
        //}

        //public ActionResult EstablecerIdioma(string idioma)
        //{

        //    return RedirectToAction("Index");
        //}

        ////20180913 
        //public PartialViewResult Notificaciones()
        //{


        //    return PartialView("_DropNotification");
        //}

    }
}