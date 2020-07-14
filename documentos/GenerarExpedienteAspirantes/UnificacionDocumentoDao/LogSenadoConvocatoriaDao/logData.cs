using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnificacionDocumentoDao.LogSenadoConvocatoriaDao
{
    public class logData
    {
        private BaseDatosDocumentsDataContext dbConexionRemota;
        public void logDataInserta(int usuario = 0, string ruta = "", string vtipoerror = "", string DescripcionError = "", string vparametros = "")
        {
            try
            {
                using (BaseDatosDocumentsDataContext dbContexto = new BaseDatosDocumentsDataContext())
                {

                    var respuesta = dbContexto.sp_insertaValoresLog(usuario, ruta, vtipoerror, DescripcionError, vparametros);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void logDataInsertaBD( string ruta , string vtipoerror , string DescripcionError , string vparametros, SqlConnectionStringBuilder sqlConnection)
        {
            dbConexionRemota = new BaseDatosDocumentsDataContext();
            try
            {

                dbConexionRemota.Connection.ConnectionString = sqlConnection.ConnectionString;

                using (BaseDatosDocumentsDataContext dbContexto = new BaseDatosDocumentsDataContext(dbConexionRemota.Connection))
                { 

                    var respuesta = dbContexto.sp_insertaValoresLog(77, ruta, vtipoerror, DescripcionError, vparametros);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
