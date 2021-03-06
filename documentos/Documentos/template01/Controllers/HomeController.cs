﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

using template01.Models;
using System.Text.RegularExpressions;
using YCP_DATA;
using System.Web.Configuration;

namespace template01.Controllers
{
    public class HomeController : Controller
    //AsyncController
    {

        public ActionResult obtieneAdjuntadoos()
        {
            List<YCP_DATA.DocumentosAdjuntar> _DocumentosAdjuntarDAO = new List<YCP_DATA.DocumentosAdjuntar>();
            List<Models.DocumentosAdjuntar> _DocumentosAdjuntar = new List<Models.DocumentosAdjuntar>();
            try
            {
                loginData ob = new loginData();
                string cadena = WebConfigurationManager.ConnectionStrings["YCP_BD"].ConnectionString;
                _DocumentosAdjuntarDAO = ob.obtieneDocumentosAdjuntar(cadena);

                foreach (var item in _DocumentosAdjuntarDAO)
                {
                    Models.DocumentosAdjuntar ent = new Models.DocumentosAdjuntar();
                    ent.bProcesado = item.bProcesado;
                    ent.dtFechaCarga = item.dtFechaCarga;
                    ent.idRegistro = item.idRegistro;
                    ent.nDocumentoAdjuntado = item.nDocumentoAdjuntado;
                    ent.vNombreDocumento = item.vNombreDocumento;
                    ent.vTipoDocumento = item.vTipoDocumento;
                    ent.vTipoExtension = item.vTipoExtension;
                    _DocumentosAdjuntar.Add(ent);
                    ent = new Models.DocumentosAdjuntar();
                }


            }
            catch (Exception ex)
            {

            }

            return View("obtieneAdjuntadoos", _DocumentosAdjuntar);
        }

        public ActionResult Index()
        {
           // Class1 instanciar = new Class1(); 
            //DropboxUImodel dropb = new DropboxUImodel();
            //dropb.CreateFolder("/TestFolder2");
            return View();
        }
        [HttpPost]
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
           

                byDocumento = EncriptarDocumento(ArchivoAdjuntar, Request);

                var vNombreArch = Request.Files[0];
                vNombreArchivo = LimpiaNombreArchivo(vNombreArch.FileName);



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

           nombreArchivo = Regex.Replace(nombreArchivo, @"(,|;|°|!|\$|=|¨|:|~|\^|`|´|¿|\?|\+|¬|¡|%|\*|{|}|@|&|'|\(|\)|<|>|#)", "");

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


        public ActionResult table_static_basic()
        {
            return View();
        }
        public ActionResult table_static_responsive()
        {
            return View();
        }
        public ActionResult table_datatables_buttons()
        {
            return View();
        }

        public ActionResult Dashboard(string correo = "", string contraseño = "")
        {
            return View();
        }

        public ActionResult Formwizard()
        {
            return View();
        }
             public void guardar(HttpPostedFileBase file)
        {

            if (file == null) return;

            string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + file.FileName).ToLower();
            string ruta = Server.MapPath("~/Uploads/" + archivo);
            file.SaveAs(ruta);



        }
        public void UploadImage(string imageData)
        {
            string archivo = "imagen.png";
            string fileNameWitPath = Server.MapPath("~/Uploads/" + archivo);
            using (System.IO.FileStream fs = new System.IO.FileStream(fileNameWitPath, System.IO.FileMode.Create))
            {
                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))

                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
            }
        }

   

    }
}
