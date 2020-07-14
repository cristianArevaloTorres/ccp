using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnificacionDocumentosPDF.Service.LogSenadoConvocatoria
{
    public class LogConvocatoriaBD
    {
        public LogConvocatoriaBD(string ruta, string vtipoerror, string DescripcionError, string vparametros ,SqlConnectionStringBuilder sqlConnection)
        {
            try
            {
                logService Log = new logService();
                Log.logServiceInsertaBD(ruta, vtipoerror, DescripcionError, vparametros, sqlConnection);

            }
            catch (Exception)
            {


            }

        }
    }
}
