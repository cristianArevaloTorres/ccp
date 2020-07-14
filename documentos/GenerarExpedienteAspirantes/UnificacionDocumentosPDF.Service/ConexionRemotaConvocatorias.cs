using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnificacionDocumentoDao;
using UnificacionDocumentoDao.ConsultarInformacionDocomentos;

namespace UnificacionDocumentosPDF.Service
{
    public class ConexionRemotaConvocatorias
    {

        

        public ConexionRemotaConvocatorias()
        {
            
        }

        public List<ConexionRemotaBD> CargarConexionesBD ()
        {
            int nconvocatorias = 0;
            ConsultarDocumentos consultarDocumentos = new ConsultarDocumentos();
            List<ConexionRemotaBD> conexionRemotaBDs = new List<ConexionRemotaBD>();         
            List<ConsultarConvocatoriasActivasResult> consultarConvocatorias = new List<ConsultarConvocatoriasActivasResult>();

            try
            {

                consultarConvocatorias = consultarDocumentos.ConsultarConvocatorias();

                consultarConvocatorias.ForEach(reg => conexionRemotaBDs.Add(new ConexionRemotaBD { idConvocatoria = reg.idConvocatoria,
                    bConexionRemotaActiva = true, idRegistroConexion = ++nconvocatorias, sqlConexionRemotaBD = CargarConexion(reg)
                } ));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.GetBaseException().Message);
            }

            return conexionRemotaBDs;
        }

        private SqlConnectionStringBuilder CargarConexion(ConsultarConvocatoriasActivasResult result)
        {
            SqlConnectionStringBuilder sqlConnection = new SqlConnectionStringBuilder();
            
            try
            {

                sqlConnection.UserID =  result.vUsuario;
                sqlConnection.Password = result.vContraseña;
                sqlConnection.DataSource = result.vIpServidor;
                sqlConnection.InitialCatalog = result.vNombreBaseDatos;
                
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.GetBaseException().Message);
            }

            return sqlConnection;
        }


    }





}
