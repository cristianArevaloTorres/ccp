using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using YCP_DATA;
namespace template01.Controllers
{
    public class BienvenidoController : Controller
    {
        // GET: Bienvenido
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdjuntarDocumento(HttpPostedFileBase ArchivoAdjuntar, int tipo)
        {
            try
            {

                GuardarInformacionDocumentos(ArchivoAdjuntar, tipo);

            }
            catch (Exception ex)
            {

            }

            return View("Index");
        }
        public ActionResult eliminar(string idreg, string iddoc)
        {
            try
            {
                string cadena = WebConfigurationManager.ConnectionStrings["YCP_BD"].ConnectionString;
                loginData ob = new loginData();
                ob.eliminar(idreg, iddoc, cadena);

            }
            catch (Exception ex)
            {

            }

            return View("Index");
        }
        private void GuardarInformacionDocumentos(HttpPostedFileBase ArchivoAdjuntar, int tipo)
        {
            byte[] byDocumento = null;
            string vNombreArchivo = string.Empty;


            try
            {
                string cadena = WebConfigurationManager.ConnectionStrings["YCP_BD"].ConnectionString;

                byDocumento = EncriptarDocumento(ArchivoAdjuntar, Request);

                var vNombreArch = Request.Files[0];
                vNombreArchivo = LimpiaNombreArchivo(vNombreArch.FileName);
                int idusuario = Convert.ToInt32((Session["idUsuario"]));

                loginData OBJ = new loginData();
                OBJ.insertarInfo(cadena, idusuario, vNombreArchivo, "PDF", "CXL", byDocumento);


                //   RegistrarDocumentosPreguntas(byDocumento);

            }
            catch (Exception ex)
            {

            }

        }
        private string LimpiaNombreArchivo(string nombreArchivo)
        {
            if (string.IsNullOrEmpty(nombreArchivo))
                return "archivoSinNombre.pdf";

            //  nombreArchivo = Regex.Replace(nombreArchivo, @"(,|;|°|!|\$|=|¨|:|~|\^|`|´|¿|\?|\+|¬|¡|%|\*|{|}|@|&|'|\(|\)|<|>|#)", "");

            if (nombreArchivo.Length > 200)
                nombreArchivo = nombreArchivo.Replace(".PDF", "").Replace(".pdf", "").Substring(0, 195) + ".pdf";

            return nombreArchivo;
        }

        private Byte[] EncriptarDocumento(HttpPostedFileBase ArchivoAdjuntar, HttpRequestBase requestBase)
        {
            byte[] byDocumento = null;

            try
            {
                var file = requestBase.Files[0];
                var length = file.InputStream.Length; //Length: 103050706

                using (var binaryReader = new System.IO.BinaryReader(file.InputStream))
                {
                    byDocumento = binaryReader.ReadBytes(file.ContentLength);
                }

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.GetBaseException().Message);
            }



            return byDocumento;
        }


        private void RegistrarDocumentosPreguntas(string vTipoAccion, int idDocumentoAdjuntar, int idTipoSeccion, int idTipoDocumento, int idUsuarioAspirante, string vNombre,
                                                                                     string vExtencion, bool vDocumentoPublico, bool bDocumentoCorrecto, string vObservacion, byte[] vrArchivo)
        {

            //List<GuardarDocumentosConvocatoriaResult> guardarResults = new List<GuardarDocumentosConvocatoriaResult>();
            //try
            //{
            //    using (BaseDatosDataContext context = new BaseDatosDataContext(true))
            //    {
            //        guardarResults = context.GuardarDocumentosConvocatoria(vTipoAccion, idDocumentoAdjuntar, idTipoSeccion, idTipoDocumento, idUsuarioAspirante, vNombre, vExtencion, vDocumentoPublico, bDocumentoCorrecto, vObservacion, vrArchivo).ToList();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new InvalidOperationException(ex.GetBaseException().Message);
            //}
            //return guardarResults;
        }



        // GET: Bienvenido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bienvenido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bienvenido/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bienvenido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bienvenido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bienvenido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bienvenido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
