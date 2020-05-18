//using Senado.Convocatoria.Models;
//using Senado.Convocatoria.Utilidades;
//using Senado.Seguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace template01
{
    public class BaseController : Controller
    {
        /// <summary>
        /// BeginExecuteCore: Metodo que ejecuta automáticamente el inicio del controlador actual.
        /// </summary>
        /// <param name="llamado">Captura el tpo de llamado que se le hace al controlador</param>
        /// <param name="estado">Momento en el que se encuentra el controlador</param>
        /// 
        //public LogConvocatorias logConvocatoria;
        protected override IAsyncResult BeginExecuteCore(AsyncCallback llamado, object estado)
        {
            string nombreIdioma = null;

            // Intenta leer el idioma en la cookie desde la petición
            HttpCookie idiomaCookie = Request.Cookies["_Idioma"];

            if (idiomaCookie != null)
            {
                nombreIdioma = idiomaCookie.Value;
            }
            else
            {
                // Se obtiene desde el encabzado HTTP AcceptLanguages
                nombreIdioma = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null;
            }

            // Valida el nombre del idioma


            // Modifica los idiomas de la tarea actual.
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(llamado, estado);
        }

        //public Service.Entidades.ConvocatoriaSesion ObtenConvocatoriaInfoSesion()
        //{
        //    Service.Entidades.ConvocatoriaSesion convocatoria = (Service.Entidades.ConvocatoriaSesion)System.Web.HttpContext.Current.Session["ConvocatoriaInfo"];
        //    if (convocatoria == null)
        //        throw new Exception("No se pudo leer la información de la convotoria en sesión.");

        //    return convocatoria;
        //}

        //protected Service.Entidades.UsuarioSesion ObtenInfoSesion()
        //{
        //    Service.Entidades.UsuarioSesion usuario = (Service.Entidades.UsuarioSesion)System.Web.HttpContext.Current.Session["usuarioAutenticado"];
        //    if (usuario == null)
        //        throw new Exception("No cuenta con una sesión activa.");

        //    return usuario;
        //}


        //protected bool CargaSesion(bool generarMensajeUsuario = true)
        //{
        //    try
        //    {
        //        CargaSesionConvocatoria();
        //        Service.Entidades.UsuarioSesion sesion = ObtenInfoSesion();

        //        ViewBag.Usuario = $"{sesion.Nombre?.ToUpper()} {sesion.ApellidoPaterno?.ToUpper()} {sesion.ApellidoMaterno?.ToUpper()} [{sesion.Usuario}]";
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        new Service.ConfiguracionConvocatorias.logService().logServiceInserta(0, "CargaSesion", "sesion", ex.ToString());

        //        if (generarMensajeUsuario)
        //            ViewBag.MensajeUsuario = MensajeUsuario.GeneraHtmlMensaje(ex.GetBaseException().Message, ex);

        //        return false;
        //    }

        //}

        //protected bool EsConvocatoriaCerrada()
        //{
        //    try
        //    {
        //        DateTime fechaActual = new Service.Comun.ServidorSevice().ObtenFechaHora();
        //        var convocatoriaSesion = ObtenConvocatoriaInfoSesion();

        //        if (fechaActual < convocatoriaSesion.FehaHoraInicio || fechaActual >= convocatoriaSesion.FehaHoraFin)
        //            return true;

        //        return false;                
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.EsConvocatoriaCerrada = true;

        //        new Service.ConfiguracionConvocatorias.logService().logServiceInserta(0, "EsConvocatoriaCerrada", "sesion", ex.ToString());
        //        throw new Exception("Error al validar el estatus de la convocatoria, favor de validar con el administrador del sistema.");
        //    }
        //}

        //protected bool EsConvocatoriaPausada()
        //{
        //    try
        //    {               
        //       var convocatoriaSesion = ObtenConvocatoriaInfoSesion();

        //        if (convocatoriaSesion.SinHorario)
        //            return false;

        //        DateTime fechaActual = new Service.Comun.ServidorSevice().ObtenFechaHora();

        //        if (!convocatoriaSesion.DiasHabiles.Contains(fechaActual.Date))
        //            return true;

        //        if (!convocatoriaSesion.HoraApertura.HasValue || !convocatoriaSesion.HoraCerrado.HasValue)
        //            return false;

        //        DateTime horarioApertura = fechaActual.Date.Add(convocatoriaSesion.HoraApertura.Value);
        //        DateTime horarioCierre = fechaActual.Date.Add(convocatoriaSesion.HoraCerrado.Value);

        //        return fechaActual < horarioApertura || fechaActual >= horarioCierre;

        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.EsConvocatoriaPausada = true;

        //        new Service.ConfiguracionConvocatorias.logService().logServiceInserta(0, "EsConvocatoriaPausada", "sesion", ex.ToString());
        //        throw new Exception("Error al validar el estatus de la convocatoria, favor de validar con el administrador del sistema.");
        //    }
        //}


        public void EnviaCorreo(string correoElectronico, string mensaje, string asunto)
        {
            string usuario = "", contraseña = "", servidor = "";
            int puerto = 25;
           
           
            usuario = "peri-informes@iteration.mx";
            contraseña = "PERISOFT123";
            servidor = "mail.iteration.mx";
            puerto = 26;        
            using (Smtp correo = new Smtp(servidor, usuario, contraseña, puerto))
            {
               // correo.ActivarSsl = true;

                if (!correo.Enviar(correoElectronico, asunto, mensaje, null))
                {                   
                   throw new Exception(correo.Errores);
                }

            }     

        }


        ////AQUI: Metodo temporal que debe ser sustituido cuandos e implemente la configuración por convatoria totalmente por BD
        //protected void CargaSesionConvocatoria()
        //{

        //    try
        //    {
        //        Service.Login.LoginService servicio = new Service.Login.LoginService();
        //        System.Web.HttpContext.Current.Session["ConvocatoriaInfo"] = servicio.ObtenConvocatoriaInfoSesion(System.Configuration.ConfigurationManager.AppSettings["IdTipoConvocatoria"].ToIntSafe());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al cargar la configuración de la convocatoria. " + ex.GetBaseException().Message);

        //    }

        //}
    }
}