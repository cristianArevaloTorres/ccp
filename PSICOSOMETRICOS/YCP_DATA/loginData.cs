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

        public List<usuariosInfo2> BuscarUsuario(string correo, string contraseña,string cadena)
        {
            List<usuariosInfo2> _usuariosInfo2 = new List<usuariosInfo2>();
            usuariosInfo2 usuariosInfo2 = new usuariosInfo2();


            using (SqlConnection conn = new SqlConnection(cadena))
            {

                conn.Open();
                DataSet ds = new DataSet();
                string query = " select TOP 1 BC.idusuario,BC.nombre,BC.apellidop,BC.apellidom,UPPER(BC.vtipo) as vtipo,BC.usuario from usuarios01 AB " +
                                "INNER JOIN usuariosInfo02 BC " +
                                "ON AB.idusuario = BC.idusuario " +
                                "where UPPER(AB.vusuario) =UPPER('"+correo+"') "+ 
                                "and AB.contraseña ='"+contraseña+"'";
                SqlCommand sqlComm = new SqlCommand(query, conn);
                using (SqlDataReader dr = sqlComm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuariosInfo2 = new usuariosInfo2
                        {
                            idusuario = Convert.ToInt32(dr["idusuario"]),
                            nombre = dr["nombre"].ToString(),
                            apellidoP = dr["apellidop"].ToString(),
                            apellidoM = dr["apellidom"].ToString(),
                            vtipo = dr["vtipo"].ToString(),
                            usuario = dr["usuario"].ToString()

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
