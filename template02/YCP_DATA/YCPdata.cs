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
    public class YCPdata
    {
        public Boolean guardarusuarios01(string cadena, string vtipo, string nombre, string apellidop, string apellidom, string correo, string usuario, string vrazon, string edad,string contraseña)
        {
            try
            {
                List<usuariosInfo2> _usuariosInfo2 = new List<usuariosInfo2>();
                usuariosInfo2 usuariosInfo2 = new usuariosInfo2();
                using (SqlConnection conn = new SqlConnection(cadena))
                {

                    conn.Open();
                    DataSet ds = new DataSet();
                    string query = "insert into usuarios01 values (1,UPPER('" + correo + "') ,'"+contraseña+"')";
                    SqlCommand sqlComm = new SqlCommand(query, conn);
                    sqlComm.ExecuteNonQuery();                   
                    conn.Close();
                }
                guardar_usuariosInfo02_usuariossocios17( cadena,  vtipo,  nombre,  apellidop,  apellidom,  correo,  usuario,  vrazon,  edad);
            }
            catch (Exception)
            {

               
            }
            return false;
        }
        public Boolean guardar_usuariosInfo02_usuariossocios17(string cadena,string vtipo, string nombre, string apellidop, string apellidom, string correo, string usuario, string vrazon, string edad)
        {
            int usuarios = Usuario(correo,cadena);
            try
            {
                List<usuariosInfo2> _usuariosInfo2 = new List<usuariosInfo2>();
                usuariosInfo2 usuariosInfo2 = new usuariosInfo2();
                using (SqlConnection conn = new SqlConnection(cadena))
                {

                    conn.Open();
                    DataSet ds = new DataSet();
                    string query = " insert into usuariosInfo02 values(" + usuarios + ",'" + vtipo + "' ,'" + nombre + "','" + apellidop + "','" + apellidom + "','" + correo + "','" + correo + "','" + vrazon + "',"+ edad + ")";
                    SqlCommand sqlComm = new SqlCommand(query, conn);
                    sqlComm.ExecuteNonQuery();
                    query = "";               
                    query = "insert into usuariossocios17 values(" + usuarios + ",'" + vtipo + "' ,' " + nombre + " " + apellidop + " " + apellidom +"'," + edad + ",'" + vrazon+ "')";
                    sqlComm = new SqlCommand(query, conn);
                    sqlComm.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {


            }
            return false;
        }
        public int Usuario(string correo, string cadenaconexion)
        {

            List<usuariosInfo2> _usuariosInfo2 = new List<usuariosInfo2>();
            usuariosInfo2 usuariosInfo2 = new usuariosInfo2();
            string cadenaconexion2 = "";
            int idsocio = 0;
            using (SqlConnection conn = new SqlConnection(cadenaconexion))
            {

                conn.Open();
                DataSet ds = new DataSet();
                string query = "select  * from usuarios01 where vusuario = UPPER('" + correo + "')";
                SqlCommand sqlComm = new SqlCommand(query, conn);
                using (SqlDataReader dr = sqlComm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuariosInfo2 = new usuariosInfo2
                        {
                            idusuario = Convert.ToInt32(dr["idusuario"]),                           
                        };
                        _usuariosInfo2.Add(usuariosInfo2);
                    }
                }
                conn.Close();
            

            }
            if (_usuariosInfo2.Count > 0)
            {
                idsocio = _usuariosInfo2.FirstOrDefault().idusuario;
            }
            
            return idsocio;
        }
        public List<usuariosInfo2> IformacionUsuarios(string vtipo, string cadenaconexion)
        {

            List<usuariosInfo2> _usuariosInfo2 = new List<usuariosInfo2>();
            usuariosInfo2 usuariosInfo2 = new usuariosInfo2();
            string cadenaconexion2 = "";

            using (SqlConnection conn = new SqlConnection(cadenaconexion))
            {

                conn.Open();
                DataSet ds = new DataSet();
                string query = "select * from usuariosInfo02 where vtipo = '" + vtipo + "' ";
                SqlCommand sqlComm = new SqlCommand(query, conn);
                using (SqlDataReader dr = sqlComm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuariosInfo2 = new usuariosInfo2
                        {
                            idusuario = Convert.ToInt32(dr["idusuario"]),
                            vtipo = dr["vtipo"].ToString(),
                            nombre = dr["nombre"].ToString(),
                            apellidoP = dr["apellidop"].ToString(),
                            apellidoM = dr["apellidom"].ToString(),
                            correo = dr["correo"].ToString(),
                            usuario = dr["usuario"].ToString(),
                            vrazon = dr["vrazon"].ToString(),
                            edad = Convert.ToInt32(dr["edad"])

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
