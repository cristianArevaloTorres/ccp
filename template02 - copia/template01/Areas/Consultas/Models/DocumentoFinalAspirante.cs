using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Senado.Convocatoria.Areas.Consultas.Models
{
    public class DocumentoFinalAspirante
    {
        public bool bDocumentoIntegrado { get; set; }

        public string vMensaje { get; set; }

        public bool bDocumentoCorrecto { get; set; }

        public int IdDocumentoGenerado { get; set; }

        public int idconvocatoria { get; set; }

        [Required]
        [Display(Name = "vNombreAspirante")]
        public string vNombreAspirante { get; set; }


        public int idAspiranteDocumento { get; set; }


        public string vnombreDocumentoFinal { get; set; }

        [Required]
        [Display(Name = "vTipoDocumentoPublico")]
        public string vTipoDocumentoPublico { get; set; }

        public bool bDocumentoPublico { get; set; }

        public bool bSeleccionDocumentoPublico { get; set; }

        public bool bSeleccionDocumentoPrivado{ get; set; }

        public byte[] byDocumentoFinal { get; set; }


        public string vnombreRutaDocumentoFinal { get; set; }


        [Required]
        [Display(Name = "Aspirantes")]
        public SelectList SeleccionarAspirantes { get; set; }

        public IEnumerable<BuscarAspirantes> ListaAspirantes { get; set; }

        [Required]
        [Display(Name = "vObservacionesDocumentoPDF")]
        public string vObservacionesDocumentoPDF { get; set; }



        public DocumentoFinalAspirante()
        {
            vMensaje = string.Empty;
            bDocumentoCorrecto = false;
            bDocumentoIntegrado = false;
            IdDocumentoGenerado = 0;
            idconvocatoria = 0;
            idAspiranteDocumento = 0;
            vnombreDocumentoFinal = string.Empty;
            bDocumentoPublico = false;
            byDocumentoFinal = null;
            vnombreRutaDocumentoFinal = string.Empty;
            ListaAspirantes = null;
            vObservacionesDocumentoPDF = string.Empty;


        }

    }

    public class BuscarAspirantes
    {


        public int idAspirante { get; set; }

        public string vnombreAspirante { get; set; }

        public BuscarAspirantes()
        {
            idAspirante = 0;
            vnombreAspirante = string.Empty;
        }


    }
}
