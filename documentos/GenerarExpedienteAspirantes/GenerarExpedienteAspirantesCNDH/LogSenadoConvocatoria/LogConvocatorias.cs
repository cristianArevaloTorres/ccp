using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnificacionDocumentosPDF.Service.LogSenadoConvocatoria;

namespace GenerarExpedienteAspirantesCNDH.LogSenadoConvocatoria
{
    public class LogConvocatorias
    {
        public LogConvocatorias(int usuario, string ruta, string vtipoerror, string DescripcionError, string vparametros)
        {
            try
            {
                logService Log = new logService();
                Log.logServiceInserta(usuario, ruta, vtipoerror, DescripcionError, vparametros);

            }
            catch (Exception)
            {


            }

        }

    }
}
