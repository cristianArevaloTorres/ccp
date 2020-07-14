using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YCP_DATA
{
   public class loginData
    {
        public class IDS {

            public int idregistro { get; set; }
            public int iddocumento { get; set; }
        }
        private IDS obtieneIds(string cadena)
        {
            IDS ids = new IDS();
            using (SqlConnection conn = new SqlConnection(cadena))
            {

                conn.Open();
                DataSet ds = new DataSet();
                string query = "select isnull(max( A.idRegistro) + 1 ,1) as idregistro , isnull(max( B.nDocumentoAdjuntado) + 1 ,1) as nDocumentoAdjuntado   "+
                                 "   from DocumentosComplementario_reg A " +
                                 "   inner " +
                                 "   join DocumentosAdjuntar_det B " +
                                 "   on 1 = 1";
                SqlCommand sqlComm = new SqlCommand(query, conn);
                using (SqlDataReader dr = sqlComm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ids = new IDS
                        {
                            idregistro = Convert.ToInt32(dr["idregistro"]),
                            iddocumento = Convert.ToInt32(dr["nDocumentoAdjuntado"])
                        };
                       
                    }
                }
                conn.Close();      
            }

            return ids;
        }

        //SP_insert_DocumentosComplementario_reg] @idRegistro int ,@idUsuario int 
      
     
        //Byte[]

        private bool validainfo(int idusuario, int iddocumento, int idregistro, string nombredoc, string tipoextencion, string tipodocumento, Byte[] documento)
        {
            bool resp = false;            
            resp = (idusuario > 0) ? true: false;
            resp = (idregistro > 0) ? true : false;
            resp = (nombredoc != "") ? true : false;
            resp = (tipoextencion != "") ? true : false;
            resp = (tipodocumento != "") ? true : false;
            resp = (documento != null) ? true : false;        
            return resp;
        }
        private bool SP_insert_DocumentosComplementario_reg(string cadena,int idregistro,int idusuario)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("SP_insert_DocumentosComplementario_reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                             parameter.ParameterName = "@idRegistro";
                             parameter.SqlDbType = SqlDbType.Int;
                             parameter.Direction = ParameterDirection.Input;
                             parameter.Value = idregistro;
                             cmd.Parameters.Add(parameter);

                            parameter = new SqlParameter();
                            parameter.ParameterName = "@idUsuario";
                            parameter.SqlDbType = SqlDbType.Int;
                            parameter.Direction = ParameterDirection.Input;
                            parameter.Value = idusuario;

                // Add the parameter to the Parameters collection.
                cmd.Parameters.Add(parameter);
                //    cmd.Parameters.AddWithValue("@param", Convert.ToInt32("0"), SqlDbType.Char);

                var dr = cmd.ExecuteNonQuery();

                cn.Close();
            }
            return false;
        }
        //[SP_insert_DocumentosAdjuntar_det] @nDocumentoAdjuntado int, @idRegistro int ,@vNombreDocumento varchar(300), @vTipoExtension varchar(5),@vTipoDocumento varchar(30)
        private bool SP_insert_DocumentosAdjuntar_det(string cadena,int iddocumento,int idregistro, string nombredoc,string tipoextencion,string tipodocumento)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("SP_insert_DocumentosComplementario_reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@idRegistro";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = idregistro;
                cmd.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@nDocumentoAdjuntado";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = iddocumento;
                cmd.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@vNombreDocumento";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = nombredoc;
                cmd.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@vTipoExtension";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = tipoextencion;
                cmd.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@vTipoDocumento";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = tipodocumento;
                cmd.Parameters.Add(parameter);
                //    cmd.Parameters.AddWithValue("@param", Convert.ToInt32("0"), SqlDbType.Char);

                var dr = cmd.ExecuteNonQuery();

                cn.Close();
            }
            return false;
        }
        private bool SP_insert_DocumentosComplementaSP_DocumentosCargados_Adjuntarrio_reg(string cadena,int idregistro,int iddocumento,Byte[] documento)
        {
            //[SP_DocumentosCargados_Adjuntar]  @idRegistro int ,@nDocumentoAdjuntar int,@bDocumentoCargado varbinary(max) NULL 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("SP_insert_DocumentosComplementario_reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@idRegistro";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = idregistro;
                cmd.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@nDocumentoAdjuntar";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = iddocumento;
                cmd.Parameters.Add(parameter);           

                parameter = new SqlParameter();
                parameter.ParameterName = "@bDocumentoCargado";
                parameter.SqlDbType = SqlDbType.VarBinary;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = documento;
                cmd.Parameters.Add(parameter);
                //    cmd.Parameters.AddWithValue("@param", Convert.ToInt32("0"), SqlDbType.Char);

                var dr = cmd.ExecuteNonQuery();

                cn.Close();
            }
            return false;
        }
        public bool insertarInfo(string cadena,int idusuario , string nombredoc, string tipoextencion, string tipodocumento, Byte[] documento)
        {

            IDS ids = obtieneIds(cadena);
            int idregistro = ids.idregistro;
            int iddocumento = ids.iddocumento;
            validainfo( idusuario,  iddocumento,  idregistro,  nombredoc,  tipoextencion,  tipodocumento, documento);
            SP_insert_DocumentosComplementario_reg(cadena,idregistro, idusuario);
            SP_insert_DocumentosAdjuntar_det(cadena, iddocumento,  idregistro,  nombredoc,  tipoextencion,  tipodocumento);
            SP_insert_DocumentosComplementaSP_DocumentosCargados_Adjuntarrio_reg(cadena,  idregistro,  iddocumento,  documento);

            

            using (SqlConnection conn = new SqlConnection(cadena))
            {

             
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("NombreStoreProcedure", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                //    cmd.Parameters.AddWithValue("@param", Convert.ToInt32("0"), SqlDbType.Char);

                    var dr = cmd.ExecuteNonQuery();
             
                    cn.Close();
                }
     


            }

            return false;
        }

        public List<usuariosInfo2> BuscarUsuario(string usuario, string contraseña,string cadena)
        {
            List<usuariosInfo2> _usuariosInfo2 = new List<usuariosInfo2>();
            usuariosInfo2 usuariosInfo2 = new usuariosInfo2();


            using (SqlConnection conn = new SqlConnection(cadena))
            {

                conn.Open();
                DataSet ds = new DataSet();
                string query = "consulta para llenar session ";
                SqlCommand sqlComm = new SqlCommand(query, conn);
                using (SqlDataReader dr = sqlComm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuariosInfo2 = new usuariosInfo2
                        {
                            idusuario = Convert.ToInt32(dr["IDUSUARIO"]),
                            nombre = dr["NOMBRE"].ToString(),
                            apellidoP = dr["AP"].ToString(),
                            apellidoM = dr["AM"].ToString(),
                            vtipo = dr["TIPOUSUARIO"].ToString(),
                            usuario = dr["VUSUARIO"].ToString()

                        };
                        _usuariosInfo2.Add(usuariosInfo2);
                    }
                }
                conn.Close();
                //SqlDataAdapter da = new SqlDataAdapter();
                //da.SelectCommand = sqlComm;
                //da.Fill(ds);

                //DataTable dt = ds.Tables[0];       
                //if (ds.Tables[0].Rows.Count > 1)
                //{
                //    //empresa.Add(new Empresa() { IdEmpresa = "0", Nombre = "-- SELECCIONE EMPRESA --" });
                //}




            }

            return _usuariosInfo2;
        }


    }
}
