using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnificacionDocumentosPDF.Service.LogSenadoConvocatoria;
using UnificacionDocumentoDao.ConsultarInformacionDocomentos;
using UnificacionDocumentoDao;
using System.Data.SqlClient;

namespace UnificacionDocumentosPDF.Service
{
    public class UnificarDocumentos
    {

        public LogConvocatorias logConvocatoria;

        public LogConvocatoriaBD logConvocatoriaBD;
        
        private GeneracionDocumento generacion { get; set; }


        private EstatusGeneracionDocumento estatusGeneracionDocumento { get; set; }

        private EstatusGuardarDocumento estatusGuardarDocumento { get; set; }

        public UnificarDocumentos()
        {
            generacion = new GeneracionDocumento();

        }


        public GeneracionDocumento generacionDocumentoPDF()
        {
            GeneracionDocumento documento = new GeneracionDocumento();
            ConexionRemotaConvocatorias consultarDocumentos = new ConexionRemotaConvocatorias();
            List<ConexionRemotaBD> conexionRemotas = new List<ConexionRemotaBD>();
            try
            {

                conexionRemotas = consultarDocumentos.CargarConexionesBD().ToList();

                conexionRemotas.ForEach( conexion => documento = GeneracionPDF( conexion ));


            }
            catch (Exception ex)
            {
                logConvocatoria = new LogConvocatorias(777, "UnificarDocumentos", "generacionDocumentoPDF_Exception", ex.GetBaseException().Message, "");
                documento.bDocumentosGeneradosCorrectamente = false;
                documento.vMensajeGeneracionDocumento=ex.GetBaseException().Message;

            }
            return documento;
        }



        private GeneracionDocumento GeneracionPDF(ConexionRemotaBD conexion)
        {            
            int idConvocatoria = 0;
            generacion = new GeneracionDocumento();
            ConsultarDocumentos consultarDocumentos = new ConsultarDocumentos();
            List<DocumentosPorUnificarResult> documentosPorUnificarResults = new List<DocumentosPorUnificarResult>();
            List<ConsultarRutaDocumentosResult> lstconsultarRutaDocumentos = new List<ConsultarRutaDocumentosResult>();


            try
            {

                idConvocatoria = conexion.idConvocatoria;

                logConvocatoriaBD = new LogConvocatoriaBD("UnificarDocumentos", "GeneracionDocumento", "GeneracionPDF_01", "", conexion.sqlConexionRemotaBD);
                



                generacion.bDocumentosGeneradosCorrectamente = true;
                documentosPorUnificarResults = consultarDocumentos.ConsultardocumentosPorUnificars(idConvocatoria, conexion.sqlConexionRemotaBD);

                logConvocatoriaBD = new LogConvocatoriaBD( "UnificarDocumentos", "GeneracionDocumento" , "GeneracionPDF_02", documentosPorUnificarResults.Count().ToString(), conexion.sqlConexionRemotaBD);

                if (documentosPorUnificarResults.FirstOrDefault().REG == 0)
                {
                    throw new Exception("No se encontraron documentos por  unificar.!");
                }

                lstconsultarRutaDocumentos = consultarDocumentos.ConsultarRutaDocumentosPorUnificar(idConvocatoria, conexion.sqlConexionRemotaBD );

                logConvocatoriaBD = new LogConvocatoriaBD( "UnificarDocumentos", "GeneracionDocumento", "GeneracionPDF_03", lstconsultarRutaDocumentos.Count().ToString(), conexion.sqlConexionRemotaBD);

                lstconsultarRutaDocumentos.ForEach(reg => generacion.lstArchivosAspirantes.Add(new ArchivosAspirantesPDF
                {
                    idAspirante = reg.idAspiranteDocumento,
                    bDocumentosPublicos = reg.bDocumentosPublicos,
                    vRutaDocumentos = reg.vNombreRutaCarpeta,
                    idConvocatoria = reg.idConvocatoria,
                    vNombreDocumentoSalida = reg.bDocumentosPublicos == false ? "Expediente_Privado_Aspirante_" + reg.idAspiranteDocumento + ".pdf" :
                                                                                "Expediente_Publico_Unido_Aspirante_" + reg.idAspiranteDocumento + ".pdf"
                }));

                logConvocatoriaBD = new LogConvocatoriaBD( "UnificarDocumentos", "GeneracionDocumento", "GeneracionPDF_04", generacion.lstArchivosAspirantes.Count().ToString(), conexion.sqlConexionRemotaBD);

                lstconsultarRutaDocumentos.ForEach(reg => generacion.lstArchivosAspirantes.Where(archivos => reg.idAspiranteDocumento == archivos.idAspirante && reg.bDocumentosPublicos == archivos.bDocumentosPublicos)
                                          .ToList().ForEach(agregar => agregar.lstunificarResults = ConsultarDocumentoFisico(reg.idConvocatoria, reg.vNombreRutaCarpeta, reg.idAspiranteDocumento, reg.bDocumentosPublicos, conexion.sqlConexionRemotaBD)));

                logConvocatoriaBD = new LogConvocatoriaBD("UnificarDocumentos", "GeneracionDocumento", "GeneracionPDF_05", generacion.lstArchivosAspirantes.Count().ToString(), conexion.sqlConexionRemotaBD);

                generacion.lstArchivosAspirantes.ForEach(documentos => documentos.estatusGeneracion = GenerarPDFSeparacion(documentos.vDocumentosAspirantes, documentos.vNombreDocumentoSalida, documentos.vRutaDocumentos, documentos.lstunificarResults, conexion.sqlConexionRemotaBD));

                logConvocatoriaBD = new LogConvocatoriaBD("UnificarDocumentos", "GeneracionDocumento", "GeneracionPDF_06", generacion.lstArchivosAspirantes.Count().ToString(), conexion.sqlConexionRemotaBD);

                generacion.lstArchivosAspirantes.ForEach(documentos => documentos.estatusGuardarDocumento = GuardarDocumento(documentos, conexion.sqlConexionRemotaBD));

                logConvocatoriaBD = new LogConvocatoriaBD( "UnificarDocumentos", "GeneracionDocumento", "GeneracionPDF_07", generacion.lstArchivosAspirantes.Count().ToString(), conexion.sqlConexionRemotaBD);
            }
            catch (Exception ex)
            {
                logConvocatoriaBD = new LogConvocatoriaBD( "UnificarDocumentos", "GeneracionDocumento_Exception", "GeneracionPDF_08", generacion.lstArchivosAspirantes.Count().ToString(), conexion.sqlConexionRemotaBD);

                ///throw new InvalidOperationException(ex.GetBaseException().Message);

            }

            logConvocatoriaBD = new LogConvocatoriaBD( "UnificarDocumentos", "GeneracionDocumento", "GeneracionPDF_08", "FIN", conexion.sqlConexionRemotaBD);

            return generacion;

        }


        private List<ConsultarDocumentosPorUnificarResult> ConsultarDocumentoFisico(int idConvocatoria, string vRutaDocumento, int idAspirante, bool ddocumentoPublico, SqlConnectionStringBuilder  sqlConnection)
        {




            List<string> listRutas = new List<string>();

            ConsultarDocumentos consultarDocumentos = new ConsultarDocumentos();
            List<ConsultarDocumentosPorUnificarResult> lstdocumentosPorUnificarResults = new List<ConsultarDocumentosPorUnificarResult>();


            try
            {

                logConvocatoriaBD = new LogConvocatoriaBD( "UnificarDocumentos", "ConsultarDocumentoFisico", "ConsultarDocumentoFisico", "01", sqlConnection);

                DirectoryInfo vrutaDirectorio = new DirectoryInfo(vRutaDocumento);

                lstdocumentosPorUnificarResults = consultarDocumentos.ConsultarNombresDocumentos(idConvocatoria, idAspirante, ddocumentoPublico, sqlConnection).ToList();

                foreach (var nombrePDF in lstdocumentosPorUnificarResults)
                {

                    FileInfo[] archivos = vrutaDirectorio.GetFiles(nombrePDF.vNombreDoc);

                    string[] lstdocumentos = new string[archivos.Length];


                    ///archivos.ToList().ForEach(documento => listRutas.Add(documento.FullName) );
                    archivos.ToList().ForEach(documento => lstdocumentosPorUnificarResults.Where(doc => doc.vNombreDoc.Trim() == nombrePDF.vNombreDoc).FirstOrDefault().vRutaTipoDocumento = documento.FullName);


                }

                logConvocatoria = new LogConvocatorias(777, "UnificarDocumentos", "ConsultarDocumentoFisico", "ConsultarDocumentoFisico", "02");

            }
            catch (Exception ex)
            {                
                logConvocatoriaBD = new LogConvocatoriaBD("UnificarDocumentos", "ConsultarDocumentoFisico", ex.GetBaseException().Message, "02", sqlConnection);
            }

            //return listRutas;
            return lstdocumentosPorUnificarResults;

        }        

        public EstatusGeneracionDocumento GenerarCabeceroPDF(List<string> vrutaPath, string vnombreDocumento, string vrutaCarpetaInicial, List<ConsultarDocumentosPorUnificarResult> lstunificarResults)
        {
            string vmensaje = string.Empty, vrutaDocumento = string.Empty, vRutapdf = string.Empty;
            EstatusGeneracionDocumento estatusGeneracionDocumento = new EstatusGeneracionDocumento();
            // Documento que se crea despues de unir los archivos
            PdfDocument outputDocument = new PdfDocument();

            try
            {

                string valor = "Ensayo de autoría propia, en un máximo de 5 cuartillas, en hoja carta, letra tipo Arial tamaño 12, con interlineado sencillo, sobre alguno de los siguientes temas: Voto electrónico, Financiamiento público a partirdos políticos, Paridad transversal en órganos colegiados electos popularmente y Libertad de expresión en las redes sociales:";
                // For para recorrer el listado de archivos para irlo abriendo uno por uno

                foreach (var doc in lstunificarResults)
                {

                    PdfDocument inputDocument = PdfReader.Open(doc.vRutaTipoDocumento, PdfDocumentOpenMode.Import);
                    int count = inputDocument.PageCount + 1;
                    bool bPaginaInicialCreada = true;

                    // For para recorrer pagina por pagina el pdf
                    for (int idx = 0; idx < count; idx++)
                    {

                        PdfPage page = null;


                        if (idx == 0 && bPaginaInicialCreada == true)
                        {
                            page = new PdfPage();
                            outputDocument.AddPage(page);
                        }
                        else
                        {


                            page = outputDocument.AddPage(inputDocument.Pages[idx]);
                            bPaginaInicialCreada = false;
                        }

                        if (idx == 0 && bPaginaInicialCreada == true)
                        {
                            int id = idx - 1;
                            idx = id;
                            count = count - 1;

                            XGraphics graph = XGraphics.FromPdfPage(page);
                            XFont font = new XFont("Calibri (Cuerpo)", 9, XFontStyle.Bold);
                            //graph.DrawString(valor, font, XBrushes.Black, new XRect(0, 0, page.Width.Point, page.Height.Point), XStringFormats.Center);
                            graph.DrawString(doc.vNombreTipoDocumento.Trim(), font, XBrushes.Black, new XRect(20, 250, 100, 122), XStringFormats.Center);
                            bPaginaInicialCreada = false;
                        }


                    }
                    // Se agrega un pagina al archivo de salida
                    //outputDocument.AddPage(page);
                    outputDocument.Save(vrutaCarpetaInicial + doc.vNombreDoc);
                    ///vrutaDocumento = file;
                }

                vRutapdf = vrutaCarpetaInicial + vnombreDocumento;
                byte[] bytes = System.IO.File.ReadAllBytes(vRutapdf);
                File.WriteAllBytes(vRutapdf, bytes);

                estatusGeneracionDocumento.bDocumentoGenerado = true;
                estatusGeneracionDocumento.byDocumentoFinal = bytes;

                System.Diagnostics.Debug.WriteLine("Documento generado en: " + vrutaCarpetaInicial + vnombreDocumento);
            }
            catch (Exception ex)
            {
                estatusGeneracionDocumento.bDocumentoGenerado = false;
                estatusGeneracionDocumento.vMensajeDocumento = ex.GetBaseException().Message;
            }

            return estatusGeneracionDocumento;
        }

        public EstatusGeneracionDocumento GenerarPDFSeparacion(List<string> vrutaPath, string vnombreDocumento, string vrutaCarpetaInicial, List<ConsultarDocumentosPorUnificarResult> lstunificarResults , SqlConnectionStringBuilder sqlConnection)
        {
            string vmensaje = string.Empty, vrutaDocumento = string.Empty, vRutapdf = string.Empty;
            EstatusGeneracionDocumento estatusGeneracionDocumento = new EstatusGeneracionDocumento();
            // Documento que se crea despues de unir los archivos
            PdfDocument outputDocument = new PdfDocument();

            try
            {

                // For para recorrer el listado de archivos para irlo abriendo uno por uno

                logConvocatoriaBD = new LogConvocatoriaBD( "UnificarDocumentos", "GenerarPDFSeparacion", "GenerarPDFSeparacion", "01", sqlConnection);

                foreach (var doc in lstunificarResults)
                {

                    PdfDocument inputDocument = PdfReader.Open(doc.vRutaTipoDocumento, PdfDocumentOpenMode.Import);
                    int count = inputDocument.PageCount + 1;
                    bool bPaginaInicialCreada = true;

                    // For para recorrer pagina por pagina el pdf
                    for (int idx = 0; idx < count; idx++)
                    {

                        PdfPage page = null;


                        if (idx == 0 && bPaginaInicialCreada == true)
                        {
                            page = new PdfPage();

                            outputDocument.AddPage(page);
                        }
                        else
                        {
                            page = outputDocument.AddPage(inputDocument.Pages[idx]);
                            bPaginaInicialCreada = false;
                        }

                        if (idx == 0 && bPaginaInicialCreada == true)
                        {
                            int id = idx - 1;
                            idx = id;
                            count = count - 1;

                            XGraphics graph = XGraphics.FromPdfPage(page);
                            XFont font = new XFont("Calibri (Cuerpo)", 12, XFontStyle.Underline);
                            //graph.DrawString(valor, font, XBrushes.Black, new XRect(0, 0, page.Width.Point, page.Height.Point), XStringFormats.Center);


                            int cantidad = doc.vNombreTipoDocumento.Length;

                            if (cantidad <= 70)
                            {
                                graph.DrawString(doc.vNombreTipoDocumento.Trim(), font, XBrushes.Black, new XRect(100, 100, page.Width - 250, 600), XStringFormats.Center);
                            }
                            else
                            {
                                string vrecuperarCadena = "";
                                if (cantidad >= 71 && cantidad <= 80)
                                {
                                    graph.DrawString(doc.vNombreTipoDocumento.Trim().Substring(0, 80), font, XBrushes.Black, new XRect(100, 100, page.Width - 250, 600), XStringFormats.Center);
                                }
                                if (cantidad == 99)
                                {
                                    vrecuperarCadena = doc.vNombreTipoDocumento.Trim().Substring(81);
                                    graph.DrawString(doc.vNombreTipoDocumento.Trim().Substring(0, 80), font, XBrushes.Black, new XRect(100, 100, page.Width - 250, 600), XStringFormats.Center);
                                    graph.DrawString(vrecuperarCadena, font, XBrushes.Black, new XRect(120, 120, page.Width - 250, 600), XStringFormats.CenterLeft);
                                }
                                else if (cantidad == 95)
                                {
                                    vrecuperarCadena = doc.vNombreTipoDocumento.Trim().Substring(73);
                                    graph.DrawString(doc.vNombreTipoDocumento.Trim().Substring(0, 72), font, XBrushes.Black, new XRect(100, 100, page.Width - 250, 600), XStringFormats.Center);
                                    graph.DrawString(vrecuperarCadena, font, XBrushes.Black, new XRect(100, 120, page.Width - 250, 600), XStringFormats.CenterLeft);
                                }
                                else if (cantidad == 101)
                                {
                                    vrecuperarCadena = doc.vNombreTipoDocumento.Trim().Substring(73);
                                    graph.DrawString(doc.vNombreTipoDocumento.Trim().Substring(0, 72), font, XBrushes.Black, new XRect(100, 100, page.Width - 250, 600), XStringFormats.Center);
                                    graph.DrawString(vrecuperarCadena, font, XBrushes.Black, new XRect(100, 120, page.Width - 250, 600), XStringFormats.CenterLeft);
                                }
                                else if (cantidad == 140)
                                {
                                    vrecuperarCadena = string.Empty;
                                    vrecuperarCadena = doc.vNombreTipoDocumento.Trim().Substring(0, 70);
                                    graph.DrawString(vrecuperarCadena, font, XBrushes.Black, new XRect(100, 110, page.Width - 250, 600), XStringFormats.Center);
                                    vrecuperarCadena = string.Empty;
                                    vrecuperarCadena = doc.vNombreTipoDocumento.Trim().Substring(71);
                                    graph.DrawString(vrecuperarCadena, font, XBrushes.Black, new XRect(100, 130, page.Width - 250, 600), XStringFormats.Center);
                                }
                                else if (cantidad == 234)
                                {
                                    string vcadena = doc.vNombreTipoDocumento.Trim();
                                    vrecuperarCadena = vcadena.Substring(0, 78);
                                    graph.DrawString(vrecuperarCadena, font, XBrushes.Black, new XRect(100, 100, page.Width - 250, 600), XStringFormats.Center);

                                    vrecuperarCadena = vcadena.Substring(79, 61);
                                    graph.DrawString(vrecuperarCadena, font, XBrushes.Black, new XRect(100, 120, page.Width - 250, 600), XStringFormats.Center);

                                    vrecuperarCadena = vcadena.Substring(139, 35);
                                    graph.DrawString(vrecuperarCadena, font, XBrushes.Black, new XRect(100, 140, page.Width - 250, 600), XStringFormats.Center);

                                    vrecuperarCadena = vcadena.Substring(140);
                                    graph.DrawString(vrecuperarCadena, font, XBrushes.Black, new XRect(100, 160, page.Width - 250, 600), XStringFormats.Center);

                                }

                                else if (cantidad == 337)
                                {
                                    string vcadena = doc.vNombreTipoDocumento.Trim();
                                    vrecuperarCadena = vcadena.Substring(0, 70);
                                    graph.DrawString(vrecuperarCadena, font, XBrushes.Black, new XRect(100, 100, page.Width - 250, 600), XStringFormats.Center);

                                    vrecuperarCadena = vcadena.Substring(71, 70);
                                    graph.DrawString(vrecuperarCadena, font, XBrushes.Black, new XRect(100, 120, page.Width - 250, 600), XStringFormats.Center);

                                    vrecuperarCadena = vcadena.Substring(142, 74);
                                    graph.DrawString(vrecuperarCadena, font, XBrushes.Black, new XRect(100, 140, page.Width - 250, 600), XStringFormats.Center);

                                    vrecuperarCadena = vcadena.Substring(217, 75);
                                    graph.DrawString(vrecuperarCadena, font, XBrushes.Black, new XRect(100, 160, page.Width - 250, 600), XStringFormats.Center);

                                    graph.DrawString(doc.vNombreTipoDocumento.Trim().Substring(293), font, XBrushes.Black, new XRect(100, 180, page.Width - 250, 600), XStringFormats.Center);

                                }

                            }
                            bPaginaInicialCreada = false;
                        }
                    }
                    // Se agrega un pagina al archivo de salida

                    outputDocument.Save(vrutaCarpetaInicial + vnombreDocumento);
                }

                vRutapdf = vrutaCarpetaInicial + vnombreDocumento;
                byte[] bytes = System.IO.File.ReadAllBytes(vRutapdf);
                File.WriteAllBytes(vRutapdf, bytes);

                estatusGeneracionDocumento.bDocumentoGenerado = true;
                estatusGeneracionDocumento.byDocumentoFinal = bytes;

                logConvocatoriaBD = new LogConvocatoriaBD("UnificarDocumentos", "GenerarPDFSeparacion", "GenerarPDFSeparacion", "02" , sqlConnection);

            }
            catch (Exception ex)
            {
                estatusGeneracionDocumento.bDocumentoGenerado = false;
                estatusGeneracionDocumento.vMensajeDocumento = ex.GetBaseException().Message;
            }

            return estatusGeneracionDocumento;
        }


        public EstatusGeneracionDocumento GenerarPDF(List<string> vrutaPath, string vnombreDocumento, string vrutaCarpetaInicial, List<ConsultarDocumentosPorUnificarResult> lstunificarResults)
        {
            string vmensaje = string.Empty;
            string vrutaDocumento = string.Empty;
            string vRutapdf = string.Empty;
            EstatusGeneracionDocumento estatusGeneracionDocumento = new EstatusGeneracionDocumento();

            ///const string outputFileName = vnombreDocumento;            

            // Documento que se crea despues de unir los archivos
            PdfDocument outputDocument = new PdfDocument();

            try
            {


                // For para recorrer el listado de archivos para irlo abriendo uno por uno
                //foreach (string file in vrutaPath)
                foreach (var doc in lstunificarResults)
                {
                    //PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);
                    PdfDocument inputDocument = PdfReader.Open(doc.vRutaTipoDocumento, PdfDocumentOpenMode.Import);
                    int count = inputDocument.PageCount;

                    // For para recorrer pagina por pagina el pdf
                    for (int idx = 0; idx < count; idx++)
                    {
                        PdfPage page = inputDocument.Pages[idx];

                        //PdfPage page = inputDocument.PageCount > idx ? inputDocument.Pages[idx] : new PdfPage();

                        //if (idx == 0)
                        //{
                        //    ///inputDocument.Pages[idx] : new PdfPage();
                        //    XGraphics graph = XGraphics.FromPdfPage(page);
                        //    XFont font = new XFont("Engravers MT", 18, XFontStyle.Bold);
                        //    graph.DrawString(doc.vNombreTipoDocumento.Trim(), font, XBrushes.Black, new XRect(0, 0, page.Width.Point, page.Height.Point), XStringFormats.Center);
                        //}

                        // Se agrega un pagina al archivo de salida
                        outputDocument.AddPage(page);
                    }

                    outputDocument.Save(vrutaCarpetaInicial + vnombreDocumento);
                    ///vrutaDocumento = file;
                }

                vRutapdf = vrutaCarpetaInicial + vnombreDocumento;
                byte[] bytes = System.IO.File.ReadAllBytes(vRutapdf);
                File.WriteAllBytes(vRutapdf, bytes);

                estatusGeneracionDocumento.bDocumentoGenerado = true;
                estatusGeneracionDocumento.byDocumentoFinal = bytes;

                System.Diagnostics.Debug.WriteLine("Documento generado en: " + vrutaCarpetaInicial + vnombreDocumento);
            }
            catch (Exception ex)
            {
                estatusGeneracionDocumento.bDocumentoGenerado = false;
                estatusGeneracionDocumento.vMensajeDocumento = ex.GetBaseException().Message;
            }

            return estatusGeneracionDocumento;
        }


        public EstatusGuardarDocumento GuardarDocumento(ArchivosAspirantesPDF archivos, SqlConnectionStringBuilder sqlConnection)
        {
            EstatusGuardarDocumento estatusGuardar = new EstatusGuardarDocumento();
            ConsultarDocumentos consultarDocumentos = new ConsultarDocumentos();
            GuardarDetalleDocumentoFinalResult guardar = new GuardarDetalleDocumentoFinalResult();

            try
            {


                logConvocatoriaBD = new LogConvocatoriaBD( "UnificarDocumentos", "GuardarDocumento", "GuardarDocumento", "01",sqlConnection);

                guardar = consultarDocumentos.RegistrarDocumentoFinal("INSERT", archivos.idAspirante, archivos.idConvocatoria, archivos.vNombreDocumentoSalida, 777, archivos.bDocumentosPublicos,
                                                                        null, 0, archivos.estatusGeneracion.bDocumentoGenerado, archivos.estatusGeneracion.vMensajeDocumento, archivos.estatusGeneracion.byDocumentoFinal, sqlConnection);

                estatusGuardar.bDocumentoGenerado = guardar.idErrorReturn == 0 ? true : false;
                estatusGuardar.vMensajeDocumento = guardar.vDescripcionErrorReturn;

                logConvocatoriaBD = new LogConvocatoriaBD ("UnificarDocumentos", "GuardarDocumento", "GuardarDocumento", "02: " + guardar.vDescripcionErrorReturn, sqlConnection);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.GetBaseException().Message);
            }

            return estatusGuardar;
        }



    }
}
