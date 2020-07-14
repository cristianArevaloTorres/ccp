using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnificacionDocumentoDao.ConsultarInformacionDocomentos
{
    public class ConsultarDocumentos
    {

        private BaseDatosDocumentsDataContext dbConexionRemota;

        public ConsultarDocumentos()
        {
            dbConexionRemota = new BaseDatosDocumentsDataContext();
        }

        public List<DocumentosPorUnificarResult> ConsultardocumentosPorUnificars(int idConvocatoria, SqlConnectionStringBuilder sqlConnection)
        {
            return Consultardocumentos(idConvocatoria, sqlConnection);
        }

        public List<ConsultarRutaDocumentosResult> ConsultarRutaDocumentosPorUnificar(int idConvocatoria, SqlConnectionStringBuilder sqlConnection)
        {
            return ConsultarRutaDocumentos(idConvocatoria, sqlConnection);
        }

        public List<ConsultarDocumentosPorUnificarResult> ConsultarNombresDocumentos(int idConvocatoria, int idUsuarioAspirante, bool bDocumentosPublicos, SqlConnectionStringBuilder sqlConnection)
        {
            return ConsultarInformacionDocumentos(idConvocatoria, idUsuarioAspirante, bDocumentosPublicos,sqlConnection);
        }

        public List<ConsultarDocumentosPorUnificarResult> ConsultarConvocatoriasActivas()
        {
            return ConsultarConvocatoriasActivas();
        }


        public GuardarDetalleDocumentoFinalResult RegistrarDocumentoFinal(string vTipoAccion, int idUsuarioAspirante, int idConvocatoria, string vnombreDocumentoFinal,
                  int idUsuarioAlta, bool bDocumentosPublicos, string vObservaciones, int idUsuarioValidacion, bool bDocumentoGeneradoCompleto, string vMensajeError, byte[] vrArchivoFinal, SqlConnectionStringBuilder sqlConnection)
        {
            return guardarDocumentoFinal(vTipoAccion, idUsuarioAspirante, idConvocatoria, vnombreDocumentoFinal, idUsuarioAlta, bDocumentosPublicos, vObservaciones, idUsuarioValidacion, bDocumentoGeneradoCompleto, vMensajeError, vrArchivoFinal, sqlConnection);
        }

        public List<ConsultarConvocatoriasActivasResult> ConsultarConvocatorias()
        {
            return consultarConvocatorias();
        }

        private List<DocumentosPorUnificarResult> Consultardocumentos(int idConvocatoria, SqlConnectionStringBuilder sqlConnection)
        {
            List<DocumentosPorUnificarResult> documentos = new List<DocumentosPorUnificarResult>();

            dbConexionRemota = new BaseDatosDocumentsDataContext();
            try
            {

                dbConexionRemota.Connection.ConnectionString = sqlConnection.ConnectionString;

                using (BaseDatosDocumentsDataContext dbContexto = new BaseDatosDocumentsDataContext(dbConexionRemota.Connection))
                {

                    documentos = dbContexto.DocumentosPorUnificar(idConvocatoria).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.GetBaseException().Message);
            }

            return documentos;
        }

        private List<ConsultarRutaDocumentosResult> ConsultarRutaDocumentos(int idConvocatoria, SqlConnectionStringBuilder sqlConnection)
        {
            List<ConsultarRutaDocumentosResult> consultarRutaDocumentos = new List<ConsultarRutaDocumentosResult>();

            dbConexionRemota = new BaseDatosDocumentsDataContext();
            try
            {

                dbConexionRemota.Connection.ConnectionString = sqlConnection.ConnectionString;

                using (BaseDatosDocumentsDataContext dbContexto = new BaseDatosDocumentsDataContext(dbConexionRemota.Connection))
                {


                    consultarRutaDocumentos = dbContexto.ConsultarRutaDocumentos(idConvocatoria).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.GetBaseException().Message);
            }

            return consultarRutaDocumentos;
        }


        private List<ConsultarDocumentosPorUnificarResult> ConsultarInformacionDocumentos(int idConvocatoria, int idUsuarioAspirante, bool bDocumentosPublicos , SqlConnectionStringBuilder sqlConnection)
        {
            List<ConsultarDocumentosPorUnificarResult> lstconsultarDocumentosPors = new List<ConsultarDocumentosPorUnificarResult>();

            dbConexionRemota = new BaseDatosDocumentsDataContext();

            try
            {

                dbConexionRemota.Connection.ConnectionString = sqlConnection.ConnectionString;

                using (BaseDatosDocumentsDataContext dbContexto = new BaseDatosDocumentsDataContext(dbConexionRemota.Connection))
                {


                    lstconsultarDocumentosPors = dbContexto.ConsultarDocumentosPorUnificar(idConvocatoria, idUsuarioAspirante, bDocumentosPublicos).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.GetBaseException().Message);
            }

            return lstconsultarDocumentosPors;
        }



        private GuardarDetalleDocumentoFinalResult guardarDocumentoFinal(string vTipoAccion, int idUsuarioAspirante, int idConvocatoria, string vnombreDocumentoFinal,
                  int idUsuarioAlta, bool bDocumentosPublicos, string vObservaciones, int idUsuarioValidacion, bool bDocumentoGeneradoCompleto, string vMensajeError, byte[] vrArchivoFinal, SqlConnectionStringBuilder sqlConnection)
        {

            GuardarDetalleDocumentoFinalResult guardarDetalleDocumento = new GuardarDetalleDocumentoFinalResult();

            dbConexionRemota = new BaseDatosDocumentsDataContext();
            try
            {

                dbConexionRemota.Connection.ConnectionString = sqlConnection.ConnectionString;

                using (BaseDatosDocumentsDataContext dbContexto = new BaseDatosDocumentsDataContext(dbConexionRemota.Connection))
                {


                    guardarDetalleDocumento = dbContexto.GuardarDetalleDocumentoFinal(vTipoAccion, idUsuarioAspirante, idConvocatoria, vnombreDocumentoFinal, idUsuarioAlta, false, bDocumentosPublicos, vObservaciones, idUsuarioValidacion, bDocumentoGeneradoCompleto, vMensajeError, vrArchivoFinal,0).FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.GetBaseException().Message);
            }
            return guardarDetalleDocumento;
        }



        private List<ConsultarConvocatoriasActivasResult> consultarConvocatorias()
        {
            List<ConsultarConvocatoriasActivasResult> convocatoriasActivasResults = new List<ConsultarConvocatoriasActivasResult>();
            try
            {
                using (BaseDatosDocumentsDataContext dbContexto = new BaseDatosDocumentsDataContext())
                {

                    convocatoriasActivasResults = dbContexto.ConsultarConvocatoriasActivas().ToList();
                }

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.GetBaseException().Message);
            }

            return convocatoriasActivasResults;
        }

    }
}
