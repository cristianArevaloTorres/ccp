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

        public List<usuariosInfo2> BuscarUsuario(string usuario, string contraseña,string cadena)
        {
            List<usuariosInfo2> _usuariosInfo2 = new List<usuariosInfo2>();
            usuariosInfo2 usuariosInfo2 = new usuariosInfo2();


            using (SqlConnection conn = new SqlConnection(cadena))
            {

                conn.Open();
                DataSet ds = new DataSet();
                string query = "select A.NOMBRE,A.AP, A.AM, A.IDUSUARIO, B.VUSUARIO,A.TIPOUSUARIO from usuario_psea_01 A " + 
                               "inner join usuario_seg_psea_02 B " + 
                               "ON A.IDUSUARIO = B.idUsuario " +
                                "where UPPER(B.VUSUARIO) =UPPER('" + usuario + "') "+
                                "and B.vDescripcionpp ='" + contraseña+"'";
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
