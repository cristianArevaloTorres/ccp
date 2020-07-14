using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnificacionDocumentoDao;


namespace UnificacionDocumentosPDF.Service
{
    public class GeneracionDocumento
    {


        public int idCodigoGeneracion { get; set; }
        public string vMensajeGeneracionDocumento { get; set; }

        public bool bDocumentosGeneradosCorrectamente { get; set; }

        public List<ArchivosAspirantesPDF> lstArchivosAspirantes { get; set; }

        public GeneracionDocumento()
        {
            idCodigoGeneracion = 0;
            vMensajeGeneracionDocumento = string.Empty;
            bDocumentosGeneradosCorrectamente = false;
            lstArchivosAspirantes = new List<ArchivosAspirantesPDF>();


        }


    }

    public class ArchivosAspirantesPDF
    {



        public bool vGeneracionPDFCorrecto { get; set; }

        public string vMensajeGeneracionPDf { get; set; }

        public int idAspirante { get; set; }
        public int idConvocatoria { get; set; }
        public string vRutaDocumentos { get; set; }

        public string vNombreDocumentoSalida { get; set; }


        public List<string> vDocumentosAspirantes { get; set; }

        public List<ConsultarDocumentosPorUnificarResult> lstunificarResults { get; set; }

        public bool bDocumentosPublicos { get; set; }

        public EstatusGeneracionDocumento estatusGeneracion { get; set; }

        public EstatusGuardarDocumento estatusGuardarDocumento { get; set; }

        public ArchivosAspirantesPDF()
        {
            idConvocatoria = 0;
            vGeneracionPDFCorrecto = false;
            vMensajeGeneracionPDf = string.Empty;
            idAspirante = 0;
            vRutaDocumentos = string.Empty;
            vNombreDocumentoSalida = string.Empty;
            vDocumentosAspirantes = new List<string>();
            bDocumentosPublicos = false;
            estatusGeneracion = new EstatusGeneracionDocumento();
            estatusGuardarDocumento = new EstatusGuardarDocumento();
            lstunificarResults = new List<ConsultarDocumentosPorUnificarResult>();


        }


    }


    public class EstatusGeneracionDocumento
    {


        public bool bDocumentoGenerado { get; set; }
        public string vMensajeDocumento { get; set; }

        public byte[] byDocumentoFinal { get; set; }


        public EstatusGeneracionDocumento()
        {
            bDocumentoGenerado = false;
            vMensajeDocumento = string.Empty;
            byDocumentoFinal = null;
        }


    }

    public class EstatusGuardarDocumento
    {


        public bool bDocumentoGenerado { get; set; }
        public string vMensajeDocumento { get; set; }



        public EstatusGuardarDocumento()
        {
            bDocumentoGenerado = false;
            vMensajeDocumento = string.Empty;
        }


    }

    public class ConexionRemotaBD
    {

        public int idRegistroConexion { get; set; }
        public int idConvocatoria { get; set; }

        public SqlConnectionStringBuilder sqlConexionRemotaBD { get; set; }   

        public bool bConexionRemotaActiva { get; set; }
        public string vMensajeConexion { get; set; }

        public ConexionRemotaBD()
        {
            idRegistroConexion = 0;
            sqlConexionRemotaBD = new SqlConnectionStringBuilder();
            idConvocatoria = 0;
            bConexionRemotaActiva = false;
            vMensajeConexion = string.Empty;
        }


    }

}
