using ExtensionMethods;
//using Senado.Convocatoria.Areas.AsignacionValidador.Models;
//using Senado.Convocatoria.Service.AsignaValidador;
//using Senado.Convocatoria.Service.InformacionAspirantes;
//using Senado.Convocatoria.Utilidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace template01.Areas.Validador.Controllers
{
    public class ValidadorController : BaseController
    {
        public static class RenderHelper
        {
            public static string PartialView(BaseController controller, string viewName, object model)
            {
                controller.ViewData.Model = model;

                using (var sw = new System.IO.StringWriter())
                {
                    ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                    ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);

                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);

                    return sw.GetStringBuilder().ToString();
                }
            }
        }

        public partial class Estatus
        {
            public virtual string vdescripcion { get; set; }
            public virtual string idStatus { get; set; }
        }
        //public ActionResult Index(int idUsuario = 0)
        //{
        //    List<UsuariosEnt> _lstAspirantesReturn = new List<UsuariosEnt>();
        //    List<UsuariosModel> _lstValidador = new List<UsuariosModel>();
        //    InfoAspirantesService AsignaService = new InfoAspirantesService();
        //    try
        //    {
        //        if (!CargaSesion())
        //            return RedirectToAction("Sesion", "Login", new { Area = "" });
        //        Service.Entidades.UsuarioSesion usuario = ObtenInfoSesion();
        //        Service.Entidades.ConvocatoriaSesion convocatoria = ObtenConvocatoriaInfoSesion();
        //        ViewBag.Nombre = usuario.Nombre;
        //        _lstAspirantesReturn = AsignaService.ObtenerAspirantesEstatus("asignado", usuario.IdUsuario, convocatoria.IdConvocatoria);
        //        _lstValidador = AsignarModel(_lstAspirantesReturn);
        //        ViewBag.lista = _lstValidador;

        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return View("");
        //}
        //public JsonResult obtieneObservaciones(string idAspirante = "0")
        //{
        //    List<UsuariosEnt> _lstAspirantesReturn = new List<UsuariosEnt>();
        //    List<UsuariosModel> _lstValidador = new List<UsuariosModel>();
        //    InfoAspirantesService AsignaService = new InfoAspirantesService();
        //    string observaciones = "";
        //    try
        //    {

        //        Service.Entidades.ConvocatoriaSesion convocatoria = ObtenConvocatoriaInfoSesion();


        //        _lstAspirantesReturn = AsignaService.ObtenerObservacion(Convert.ToInt32(idAspirante), convocatoria.IdConvocatoria);
        //        if (_lstAspirantesReturn.Count > 0)
        //        {
        //            observaciones = _lstAspirantesReturn.FirstOrDefault().vEstatusActual;
        //        }


        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return Json(observaciones, JsonRequestBehavior.AllowGet);

        //}

        //public JsonResult _estatus(string estatus)
        //{

        //    List<Estatus> _lstestatus = new List<Estatus>();
        //    _lstestatus = generarEstatus(estatus);
        //    IEnumerable<SelectListItem> items = _lstestatus.Select(c => new SelectListItem
        //    {
        //        Value = c.idStatus,
        //        Text = c.vdescripcion
        //    });
        //    ViewBag.estatus = items;
        //    return Json(items.ToJSON(), JsonRequestBehavior.AllowGet);

        //}
        //// GET: Trafico/AjustesBitacora
        //public List<Estatus> generarEstatus(string estatus)
        //{

        //    List<Estatus> _lstestatus = new List<Estatus>();
        //    Estatus ent = new Estatus();
        //    if (estatus == "asignado" || estatus == "reasignado")
        //    {
        //        ent = new Estatus();
        //        ent.idStatus = "enproceso";
        //        ent.vdescripcion = "En proceso";
        //        _lstestatus.Add(ent);
        //    }
        //    if (estatus == "rechazado")
        //    {
        //        ent = new Estatus();
        //        ent.idStatus = "reasignado";
        //        ent.vdescripcion = "Reasignado";
        //        _lstestatus.Add(ent);
        //    }
        //    if (estatus == "enproceso")
        //    {
        //        ent = new Estatus();
        //        ent.idStatus = "aprobado";
        //        ent.vdescripcion = "Aprobado";
        //        _lstestatus.Add(ent);
        //        ent = new Estatus();
        //        ent.idStatus = "rechazado";
        //        ent.vdescripcion = "Rechazado";
        //        _lstestatus.Add(ent);
        //    }





        //    return _lstestatus;

        //}
        //public PartialViewResult _listAspirantes(string estatus = "asignado", int idUsuario = 0)
        //{
        //    Service.Entidades.UsuarioSesion usuario = ObtenInfoSesion();
        //    Service.Entidades.ConvocatoriaSesion convocatoria = ObtenConvocatoriaInfoSesion();

        //    List<UsuariosModel> _lstValidador = new List<UsuariosModel>();
        //    InfoAspirantesService AsignaService = new InfoAspirantesService();
        //    int totalRechazados = AsignaService.ObtenerTotalesUsuarios("rechazado", convocatoria.IdConvocatoria, usuario.IdUsuario);
        //    int totalAsignados = AsignaService.ObtenerTotalesUsuarios("asignado", convocatoria.IdConvocatoria, usuario.IdUsuario);
        //    int totalReAsignados = AsignaService.ObtenerTotalesUsuarios("reasignado", convocatoria.IdConvocatoria, usuario.IdUsuario);
        //    int totalEnproceso = AsignaService.ObtenerTotalesUsuarios("enproceso", convocatoria.IdConvocatoria, usuario.IdUsuario);
        //    int totalFinalizados = AsignaService.ObtenerTotalesUsuarios("aprobado", convocatoria.IdConvocatoria, usuario.IdUsuario);
        //    List<UsuariosEnt> _lstAspirantesReturn = new List<UsuariosEnt>();
        //    try
        //    {
        //        //  if (!CargaSesion())
        //        //    return RedirectToAction("Index", "Login", new { Area = "" });              
        //        ViewBag.ActRechazados = GenerarClase(estatus, "rechazado");
        //        ViewBag.ActAsignados = GenerarClase(estatus, "asignado");
        //        ViewBag.ActReAsignados = GenerarClase(estatus, "reasignado");
        //        ViewBag.ActEnproceso = GenerarClase(estatus, "enproceso");
        //        ViewBag.ActFinalizados = GenerarClase(estatus, "aprobado");
        //        ViewBag.totalRechazados = totalRechazados;
        //        ViewBag.totalAsignados = totalAsignados;
        //        ViewBag.totalReAsignados = totalReAsignados;
        //        ViewBag.totalEnproceso = totalEnproceso;
        //        ViewBag.totalFinalizados = totalFinalizados;
        //        _lstAspirantesReturn = AsignaService.ObtenerAspirantesEstatus(estatus, usuario.IdUsuario, convocatoria.IdConvocatoria);
        //        _lstValidador = AsignarModel(_lstAspirantesReturn);
        //        ViewBag.estatus = estatus;
        //    }
        //    catch (Exception)
        //    {

        //        //throw;
        //    }

        //    return PartialView("_listAspirantes", _lstValidador);
        //}

        //private string GenerarClase(string estatus, string estatusComp)
        //{
        //    string clase = "";
        //    if (estatus == estatusComp)
        //    {
        //        clase = "active";
        //    }

        //    return clase;

        //}

        //private List<UsuariosModel> AsignarModel(List<UsuariosEnt> valores)
        //{
        //    List<UsuariosModel> _lstUser = new List<UsuariosModel>();
        //    valores.ToList().ForEach(x => _lstUser.Add(new UsuariosModel
        //    {
        //        vNombre = x.vNombre,
        //        vApellidoMaterno = x.vApellidoMaterno,
        //        vApellidoPaterno = x.vApellidoPaterno,
        //        idUsuario = x.idUsuario,
        //        total = x.total,
        //        correo = x.correo,
        //        vValorAgrupador = x.vValorAgrupador
        //    }));
        //    return _lstUser;
        //}







        //public JsonResult guardarestatus(string idAspirante = "0", string idValidador = "0", string idAdministrador = "0", string estatus = "", string observaciones = "")
        //{
        //    Service.Entidades.UsuarioSesion usuario = ObtenInfoSesion();
        //    DateTime fechaActual = new Service.Comun.ServidorSevice().ObtenFechaHora();

        //    InfoAspirantesService AsignaService = new InfoAspirantesService();
        //    List<UsuariosModel> _lstValidador = new List<UsuariosModel>();
        //    List<UsuariosEnt> EntServInfoAsp = AsignaService.ObtenerInfoValidador(Convert.ToInt32(idAspirante));

        //    string fecha_actual = fechaActual.ToString("ddMMyyyy");
        //    estatus = estatus.Trim();
        //    string estatusMensaje = "";

        //    if (estatus == "aprobado" || estatus == "rechazado")
        //    {
        //        estatusMensaje = ObtenEstatusCorreo(estatus);

        //        string mensajeFinal = "";
        //        if (!EsConvocatoriaCerrada() && estatus.Trim() == "rechazado")
        //        {
        //            var convocatoriaSesion = ObtenConvocatoriaInfoSesion();
        //            mensajeFinal = "Para Subsanar la inconsistencia presentada ingrese nuevamente a la plataforma y corrija las observaciones mencionadas, para lo cual tendrá hasta el "
        //                + FechaAuxiliar.ObtenTextoFormalConHora(convocatoriaSesion.FehaHoraFin) + " horas tiempo del Centro de México.";
        //        }

        //        string mensaje = $@"<html>
        //          <center><img src='http://www.senado.gob.mx/64/images/logo_2018.png' height='150'  width='150'></center>
        //                    <br>
        //                    <br>
        //                    <br>
        //            <p><center>
        //            Por medio de la presente le informamos que su Registro para la {System.Configuration.ConfigurationManager.AppSettings["NombreConvocatoriaLargo"]} 
        //            ha sido validada generando el siguiente estatus: </center></p>
        //            <br>
        //            <p><center>Estatus de su Registro es el siguiente:<strong> {estatusMensaje.ToUpper()}</strong>   </center>  </p>  	                 
        //            <br>
        //            <br>                    
        //            <p><strong>Observaciones:</strong> {observaciones}.</p>
        //            <br>
        //            <p><center>Folio: <strong>{idAspirante}{fecha_actual}</strong></center></p>
        //            <p><center>Nombre: <strong> {EntServInfoAsp.FirstOrDefault().vNombre.ToUpper()} {EntServInfoAsp.FirstOrDefault().vApellidoPaterno.ToUpper()} {EntServInfoAsp.FirstOrDefault().vApellidoMaterno.ToUpper()} </strong></center></p>
        //            <p><center>Con correo electrónico: <strong> {EntServInfoAsp.FirstOrDefault().correo}</strong></center></p>

                     
        //                <br>
                 
        //            <br />
        //            <br />
        //            <p>{mensajeFinal}</p>
        //        </ html > ";
        //        EnviaCorreo(EntServInfoAsp.FirstOrDefault().correo, mensaje, "Acuse Convocatoria");
        //    }

        //    Service.Entidades.ConvocatoriaSesion convocatoria = ObtenConvocatoriaInfoSesion();
        //    var repsuesta = AsignaService.RegistraEstatus(Convert.ToInt32(idAspirante), convocatoria.IdConvocatoria, usuario.IdUsuario, Convert.ToInt32(idAdministrador), estatus.Trim(), observaciones);
        //    return Json(repsuesta, JsonRequestBehavior.AllowGet);

        //}

        //private string ObtenEstatusCorreo(string estatus)
        //{
        //    string estatusMensaje = "";

        //    if (estatus == "rechazado")
        //    {
        //        estatusMensaje = ConfigurationManager.AppSettings["CorreoRechEstatus"];
        //    }

        //    if (estatus == "aprobado")
        //    {
        //        estatusMensaje = "registro exitoso";
        //    }

        //    return estatusMensaje;
        //}

    }
}