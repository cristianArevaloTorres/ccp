using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Dropbox.Api;
using template01.Models;
using DropBoxServiciosAccionesApi;


namespace template01.Areas.Consultas.Controllers
{
    public class EstatusController : BaseController
    {
      

    

      
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Index()
        //{
        //    //Service.Entidades.AspiranteEstatusModel estauts = new Service.Entidades.AspiranteEstatusModel();
        //    //try
        //    //{

        //    //    if (!CargaSesion())
        //    //        return RedirectToAction("Sesion", "Login", new { Area = "" });

        //    //    Service.Entidades.UsuarioSesion usuario = ObtenInfoSesion();
        //    //    Service.InformacionAspirantes.InfoAspirantesService servicio = new Service.InformacionAspirantes.InfoAspirantesService();
        //    //    estauts = servicio.ObtenAspiranteEstatusActuales(usuario.IdUsuario);

        //    //    var sesion = ObtenInfoSesion();
        //    //    sesion.EstatusActual = estauts.EstatusAspiranteCodigo;
        //    //    Session["usuarioAutenticado"] = sesion;

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    ViewBag.MensajeUsuario = MensajeUsuario.GeneraHtmlMensaje(ex.GetBaseException().Message, ex);
        //    //}
        // //   return View(estauts);
        //    return View();
        //}

        //private bool SePuedeModificar()
        //{
        //    int idPerfilAspirante = System.Configuration.ConfigurationManager.AppSettings["IdPerfilRegistro"].ToIntSafe();

        //    var usuario = ObtenInfoSesion();
        //    return !usuario.IdPerfiles.Contains(idPerfilAspirante);
        //}

        //public ActionResult obtenerInfoAspirante()
        //{
        //    CargaSesion();

        //    Service.Entidades.UsuarioSesion usuario = ObtenInfoSesion();
        //    DateTime Hoy = DateTime.Today;
        //    InfoAspirantesService AsignaService = new InfoAspirantesService();
        //    List<UsuariosEnt> EntServInfoAsp = new List<UsuariosEnt>();
        //    EntServInfoAsp = AsignaService.ObtenerInfoValidador(Convert.ToInt32(usuario.IdUsuario));



        //    try
        //    {
        //        ViewBag.nombre = usuario.Nombre + " " + usuario.ApellidoPaterno + " " + usuario.ApellidoMaterno;
        //        ViewBag.correo = usuario.Usuario;
        //        ViewBag.estatus = EntServInfoAsp.FirstOrDefault().vEstatusActual;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //    return View("");
        //}




        //public void DescargarDocumento(int idAspirante, int idtipoDocumento, int idTipoSeccion)
        //{
        //    Descargar(idAspirante, idtipoDocumento, idTipoSeccion);
        //}

        //private void Descargar(int idAspirante, int idtipoDocumento, int idSeccion)
        //{
        //    IntegradorPreguntasporConvocatoria integradorDocumentos = new IntegradorPreguntasporConvocatoria();
        //    ConsultarPreguntasConvocatoria consultarPreguntasConvocatoria = new ConsultarPreguntasConvocatoria();
        //    ValoresEntradaConvocatoriaConfig valoresEntrada = new ValoresEntradaConvocatoriaConfig();

        //    try
        //    {
        //        Service.Entidades.UsuarioSesion usuario = ObtenInfoSesion();
        //        valoresEntrada.idConvocatoria = ObtenConvocatoriaInfoSesion().IdConvocatoria;
        //        valoresEntrada.idTipoDocumento = idtipoDocumento;
        //        valoresEntrada.idUsuario = idAspirante;
        //        valoresEntrada.idSeccion = idSeccion;

        //        integradorDocumentos = consultarPreguntasConvocatoria.ObtenerDocumentoConvocatoria(valoresEntrada);


        //        integradorDocumentos.getConfiguracionPreguntasConvocatoria.FirstOrDefault()
        //                            .GetConfiguracionDocumentos.ForEach(doc => DescargarDocumento(doc.byDocumentoAdjuntar, doc.vNombreDocumento));

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //private FileStreamResult DescargarDocumento(Byte[] vnombrePDF, string vnombreArchivo)
        //{
        //    try
        //    {

        //        MemoryStream ms = new MemoryStream(vnombrePDF, 0, 0, true, true);
        //        Response.AddHeader("content-disposition", "attachment;filename= " + vnombreArchivo + "");
        //        Response.Buffer = true;
        //        Response.Clear();
        //        Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
        //        Response.OutputStream.Flush();
        //        Response.End();

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return new FileStreamResult(Response.OutputStream, "application/pdf");
        //}

        //public ActionResult obtenerInfoPregunta()
        //{
        //    CargaSesion();

        //    ConsultarPreguntasConvocatoria consultarPreguntasConvocatoria = new ConsultarPreguntasConvocatoria();
        //    ValoresEntradaConvocatoriaConfig valoresEntradaConvocatoria = new ValoresEntradaConvocatoriaConfig();
        //    valoresEntradaConvocatoria.idConvocatoria = 1;
        //    valoresEntradaConvocatoria.idUsuario = 19;
        //    IntegradorPreguntasporConvocatoria preguntasporConvocatoria = new IntegradorPreguntasporConvocatoria();
        //    List<PreguntasConvocatoria> preguntas = new List<PreguntasConvocatoria>();
        //    try
        //    {
        //        Service.Entidades.UsuarioSesion usuario = ObtenInfoSesion();
        //        ViewBag.nombre = usuario.Nombre + " " + usuario.ApellidoPaterno + " " + usuario.ApellidoMaterno;

        //        valoresEntradaConvocatoria.idUsuario = usuario.IdUsuario;
        //        valoresEntradaConvocatoria.idConvocatoria = ObtenConvocatoriaInfoSesion().IdConvocatoria;

        //        preguntasporConvocatoria = consultarPreguntasConvocatoria.convocatoriaAux(valoresEntradaConvocatoria);

        //        preguntasporConvocatoria.getConfiguracionPreguntasConvocatoria
        //                              .ToList().ForEach(car => car.GetPreguntasporConvocatoria.ToList()
        //                                      .ForEach(cargar => preguntas.Add(new PreguntasConvocatoria
        //                                      {
        //                                          idTipoConvocatoria = cargar.idTipoSeccion,
        //                                          bRequiereDocumento = cargar.bRequiereDocumento,
        //                                          idTipoSeccion = cargar.idTipoSeccion,
        //                                          vNombreSeccion = cargar.vNombreSeccion,
        //                                          vTextoPregunta = cargar.vTextoPregunta,
        //                                          vValorRespuestaDescripcion = cargar.vValorRespuestaDescripcion,
        //                                          vTipoRespuesta = cargar.vTipoRespuesta,
        //                                          idConfiguracion = cargar.idConfiguracion,
        //                                          idTipoPregunta = cargar.idTipoPregunta,
        //                                          idUsuario = usuario.IdUsuario,
        //                                          vValorRespuesta = cargar.vValorRespuesta
        //                                      })));


        //        preguntasporConvocatoria.getConfiguracionPreguntasConvocatoria
        //                                .ToList().ForEach(car => car.GetConfiguracionDocumentos.ToList()
        //                                        .ForEach(doc => preguntas.ForEach(reg => reg.DocumentosAdjuntar.Add(new PreguntasConvocatoria.ConfiguracionDocumentosAdjuntar
        //                                        {
        //                                            idTipoDocumento = doc.idTipoDocumento,
        //                                            idTipoConvocatoria = doc.idTipoConvocatoria,
        //                                            idTipoSeccion = doc.idTipoSeccion,
        //                                            vNombreTipoDocumento = doc.vNombreTipoDocumento,
        //                                            vTipoExtencioDocumento = doc.vTipoExtencioDocumento,
        //                                            nDocumentosAdjuntar = doc.nDocumentosAdjuntar,
        //                                            bDocumentoPublico = doc.bDocumentoPublico,
        //                                            idDocumentoAdjuntar = doc.idDocumentoAdjuntar,
        //                                            idUsuarioAspirante = doc.idUsuarioAspirante,
        //                                            vNombreDocumento = doc.vNombreDocumento,
        //                                            vExtencion = doc.vExtencion,
        //                                            bDocumentoCorrecto = doc.bDocumentoCorrecto,
        //                                            vObservaciones = doc.vObservaciones,
        //                                            byDocumentoAdjuntar = doc.byDocumentoAdjuntar

        //                                        }))));




        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return View("", preguntas);
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

        //public ActionResult obtenerInfoPreguntaRedirect(int idUsuario = 0, string nombre = "", string idConvocatoriaParam = "", string tipo = "")
        //{
        //    CargaSesion();

        //    ViewBag.PermiteModificar = SePuedeModificar();

        //    ViewBag.idUsuario = idUsuario;
        //    ViewBag.tipo = tipo;
        //    int idConvocatoria = Convert.ToInt32(idConvocatoriaParam);
        //    ConsultarPreguntasConvocatoria consultarPreguntasConvocatoria = new ConsultarPreguntasConvocatoria();
        //    ValoresEntradaConvocatoriaConfig valoresEntradaConvocatoria = new ValoresEntradaConvocatoriaConfig();
        //    valoresEntradaConvocatoria.idConvocatoria = 1;
        //    valoresEntradaConvocatoria.idUsuario = 19;
        //    IntegradorPreguntasporConvocatoria preguntasporConvocatoria = new IntegradorPreguntasporConvocatoria();
        //    List<PreguntasConvocatoria> preguntas = new List<PreguntasConvocatoria>();
        //    try
        //    {
        //        //  Service.Entidades.UsuarioSesion usuario = ObtenInfoSesion();
        //        ViewBag.nombre = nombre;

        //        valoresEntradaConvocatoria.idUsuario = idUsuario;
        //        valoresEntradaConvocatoria.idConvocatoria = idConvocatoria;

        //        preguntasporConvocatoria = consultarPreguntasConvocatoria.convocatoriaAux(valoresEntradaConvocatoria);

        //        preguntasporConvocatoria.getConfiguracionPreguntasConvocatoria
        //                              .ToList().ForEach(car => car.GetPreguntasporConvocatoria.ToList()
        //                                      .ForEach(cargar => preguntas.Add(new PreguntasConvocatoria
        //                                      {
        //                                          idTipoConvocatoria = cargar.idTipoSeccion,
        //                                          bRequiereDocumento = cargar.bRequiereDocumento,
        //                                          idTipoSeccion = cargar.idTipoSeccion,
        //                                          vNombreSeccion = cargar.vNombreSeccion,
        //                                          vTextoPregunta = cargar.vTextoPregunta,
        //                                          vTipoRespuesta = cargar.vTipoRespuesta,
        //                                          idConfiguracion = cargar.idConfiguracion,
        //                                          idTipoPregunta = cargar.idTipoPregunta,
        //                                          idUsuario = idUsuario,
        //                                          vValorRespuesta = cargar.vValorRespuesta,
        //                                          vValorRespuestaDescripcion = cargar.vValorRespuestaDescripcion
        //                                      })));


        //        preguntasporConvocatoria.getConfiguracionPreguntasConvocatoria
        //                                .ToList().ForEach(car => car.GetConfiguracionDocumentos.ToList()
        //                                        .ForEach(doc => preguntas.ForEach(reg => reg.DocumentosAdjuntar.Add(new PreguntasConvocatoria.ConfiguracionDocumentosAdjuntar
        //                                        {
        //                                            idTipoDocumento = doc.idTipoDocumento,
        //                                            idTipoConvocatoria = doc.idTipoConvocatoria,
        //                                            idTipoSeccion = doc.idTipoSeccion,
        //                                            vNombreTipoDocumento = doc.vNombreTipoDocumento,
        //                                            vTipoExtencioDocumento = doc.vTipoExtencioDocumento,
        //                                            nDocumentosAdjuntar = doc.nDocumentosAdjuntar,
        //                                            bDocumentoPublico = doc.bDocumentoPublico,
        //                                            idDocumentoAdjuntar = doc.idDocumentoAdjuntar,
        //                                            idUsuarioAspirante = doc.idUsuarioAspirante,
        //                                            vNombreDocumento = doc.vNombreDocumento,
        //                                            vExtencion = doc.vExtencion,
        //                                            bDocumentoCorrecto = doc.bDocumentoCorrecto,
        //                                            vObservaciones = doc.vObservaciones,
        //                                            byDocumentoAdjuntar = doc.byDocumentoAdjuntar

        //                                        }))));




        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return View("obtenerInfoPregunta", preguntas);
        //}

        //public PartialViewResult ObtenerDocumentacionFinalAspirante(string idAspirante)
        //{
        //    int idAspirantes = 0;
        //    List<BuscarAspirantes> Aspirantes = new List<BuscarAspirantes>();

        //    try
        //    {

        //        idAspirantes = Convert.ToInt16(idAspirante);
        //        documentoFinal = new DocumentoFinalAspirante();

        //        documentoFinal.ListaAspirantes = ConsultarAspirantes(idAspirantes);

        //        documentoFinal.vNombreAspirante = documentoFinal.ListaAspirantes.FirstOrDefault().vnombreAspirante.Trim();
        //        documentoFinal.idAspiranteDocumento = documentoFinal.ListaAspirantes.FirstOrDefault().idAspirante;
        //        documentoFinal.SeleccionarAspirantes = new SelectList(documentoFinal.ListaAspirantes, "ID", "Name");


        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //    return PartialView("ObtenerDocumentacionFinalAspirante", documentoFinal);
        //}


        //private string ObtenRutaVisualizarPdf(string idAspirante, bool bTipoPublico)
        //{

        //    string vrutaRelativa = string.Empty, vtipoDocuemnto = string.Empty;            
        //    cargarDocumento = new CargarDocumentoUnificadoPDF();
        //    InformacionAspiranteDocumentacion informacionAspirante = new InformacionAspiranteDocumentacion();
        //    DocumentoUnificadoAspirante documentoUnificado = new DocumentoUnificadoAspirante();
        //    ValoresEntradaConvocatoriaConfig valoresEntrada = new ValoresEntradaConvocatoriaConfig();
        //    string vpath;

        //    try
        //    {
        //        int idAspirantes = Convert.ToInt16(idAspirante);
        //        Service.Entidades.UsuarioSesion usuario = ObtenInfoSesion();
        //        valoresEntrada.idConvocatoria = ObtenConvocatoriaInfoSesion().IdConvocatoria;


        //        informacionAspirante.idAspirante = idAspirantes;
        //        informacionAspirante.idConvocatoria = valoresEntrada.idConvocatoria;
        //        informacionAspirante.bDocumentoPublico = bTipoPublico;

        //        documentoUnificado = cargarDocumento.DocumentoUnificado(informacionAspirante);

        //        vpath = Server.MapPath(documentoUnificado.vnombreRutaRelativaDocumentoFinal);


        //        if (documentoUnificado.bDocumentoCorrecto  ==false)
        //            throw new Exception("Archivo no disponible.");

        //    }
        //    catch (Exception ex)
        //    {                
        //        return "";
        //    }

        //    return vpath;
        //}

        //public ActionResult Visualizar_PDF(string idAspirante, bool bTipoPublico)
        //{
        //    string ruta = ObtenRutaVisualizarPdf(idAspirante, bTipoPublico);

        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(ruta))
        //            throw new Exception("Archivo no disponible");

        //        FileStream flCuerpoArchivo = new FileStream(ruta, FileMode.Open, FileAccess.ReadWrite);
        //        return File(flCuerpoArchivo, "application/pdf");

        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(@"<div class=""alert alert-info alert-dismissible"">Archivo no disponible.</div>");
        //    }
        //}

        //public JsonResult EstaListaFuncionalidadVisualizarPdf(string idAspirante)
        //{
        //    string rutaPublica = ObtenRutaVisualizarPdf(idAspirante, true);
        //    string rutaPrivada = ObtenRutaVisualizarPdf(idAspirante, false);
        //    bool hayPublica = !string.IsNullOrWhiteSpace(rutaPublica);
        //    bool hayPrivada = !string.IsNullOrWhiteSpace(rutaPrivada);
          
        //    return Json(new { EstaLista = hayPublica && hayPrivada}, JsonRequestBehavior.AllowGet);
        //}


        //public List<BuscarAspirantes> ConsultarAspirantes(int idAspirante)
        //{
        //    ConsultarDocumentoUnificado consultar = new ConsultarDocumentoUnificado();
        //    List<ConsultarAspirantesConvocatoriaResult> aspirantes = new List<ConsultarAspirantesConvocatoriaResult>();

        //    try
        //    {
        //        buscarAspirantes = new List<BuscarAspirantes>();


        //        aspirantes = consultar.ConsultarAspirantesConvocatorias(idAspirante);

        //        aspirantes.ToList().ForEach(reg => buscarAspirantes.Add(new BuscarAspirantes { idAspirante = reg.idUsuario, vnombreAspirante = reg.vNombreAspirante }));

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new InvalidOperationException(ex.GetBaseException().Message);
        //    }

        //    return buscarAspirantes;
        //}


        //public JsonResult RegistrarObservaciones(string vObservaciones, int idAspirante, bool bTipoPublico)
        //{
        //    string Descripcion = "";
        //    try
        //    {

        //        if (!CargaSesion())
        //            return Json(Descripcion = "La sesión ha caducado.", JsonRequestBehavior.AllowGet);

        //        if (string.IsNullOrEmpty(vObservaciones))
        //            return Json(Descripcion = "Favor de registrar las observaciones de la documentacion del aspirante.!", JsonRequestBehavior.AllowGet);
        //        documentoFinal = new DocumentoFinalAspirante();
        //        documentoFinal.vObservacionesDocumentoPDF = vObservaciones.ToString();
        //        documentoFinal.idAspiranteDocumento = idAspirante;
        //        documentoFinal.bDocumentoPublico = bTipoPublico;

        //        GuardarObservacionesDocumentoPDF(documentoFinal);

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(Descripcion = ex.Message, JsonRequestBehavior.AllowGet);
        //    }


        //    return Json(Descripcion = "Se ha guardado la informacion de forma correcta.!", JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult RegistrarObservacionAspirante(DocumentoFinalAspirante documentoFinal)
        //{
        //    List<PreguntasConvocatoria> preguntas = new List<PreguntasConvocatoria>();

        //    try
        //    {

        //        if (!CargaSesion())
        //            return Json(new { Estado = "-1", Descripcion = "La sesión ha caducado." }, JsonRequestBehavior.AllowGet);


        //        if (string.IsNullOrEmpty(documentoFinal.vObservacionesDocumentoPDF))
        //            return Json(new { Estado = "0", Descripcion = "Favor de registrar las observaciones de la documentacion del aspirante.!" }, JsonRequestBehavior.AllowGet);

        //        GuardarObservacionesDocumentoPDF(documentoFinal);

        //        //CargarPreguntas(documentoFinal.idAspiranteDocumento);
        //        //trow new NotImplementedException("s");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Estado = "0", Descripcion = ex.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
        //    }

        //    return View("ObtenerDocumentacionFinalAspirante", documentoFinal.idAspiranteDocumento);
        //    //return View("");

        //    //return Json(new { Estado = "1", Descripcion = "Se ha guardado la informacion de forma correcta.!" }, JsonRequestBehavior.AllowGet);

        //}

        //public void GuardarObservacionesDocumentoPDF(DocumentoFinalAspirante documentoFinal)
        //{

        //    cargarDocumento = new CargarDocumentoUnificadoPDF();
        //    InformacionAspiranteDocumentacion informacionAspirante = new InformacionAspiranteDocumentacion();
        //    DocumentoUnificadoAspirante documentoUnificado = new DocumentoUnificadoAspirante();

        //    try
        //    {
        //        Service.Entidades.ConvocatoriaSesion convocatoria = new Service.Entidades.ConvocatoriaSesion();
        //        convocatoria = ObtenConvocatoriaInfoSesion();


        //        informacionAspirante.idAspirante = documentoFinal.idAspiranteDocumento;
        //        informacionAspirante.idConvocatoria = convocatoria.IdConvocatoria;
        //        informacionAspirante.bDocumentoPublico = documentoFinal.bDocumentoPublico;
        //        informacionAspirante.vObservaciones = documentoFinal.vObservacionesDocumentoPDF.Trim();

        //        documentoUnificado = cargarDocumento.GuardarObservaciones(informacionAspirante);

        //        if (documentoUnificado.bDocumentoCorrecto == false)
        //        {
        //            throw new InvalidOperationException(documentoUnificado.vMensaje);
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        throw new InvalidOperationException(ex.GetBaseException().Message);
        //    }

        //}


    }
}