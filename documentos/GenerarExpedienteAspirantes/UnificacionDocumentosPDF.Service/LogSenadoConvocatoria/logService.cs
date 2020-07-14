using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnificacionDocumentoDao.LogSenadoConvocatoriaDao;

namespace UnificacionDocumentosPDF.Service.LogSenadoConvocatoria
{
    public class logService
    {
        public void logServiceInserta(int usuario = 0, string ruta = "", string vtipoerror = "", string DescripcionError = "", string vparametros = "")
        {
            try
            {
                logData dataLog = new logData();
                dataLog.logDataInserta(usuario, ruta, vtipoerror, DescripcionError, vparametros);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void logServiceInsertaBD( string ruta, string vtipoerror, string DescripcionError , string vparametros , SqlConnectionStringBuilder sqlConnection)
        {
            try
            {
                logData dataLog = new logData();
                dataLog.logDataInsertaBD( ruta, vtipoerror, DescripcionError, vparametros, sqlConnection);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
