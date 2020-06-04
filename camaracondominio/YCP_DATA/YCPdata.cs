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
 

        public Boolean mandarmsj(string cadena, int usuario,int idcliente,string mensaje)
        {
            try
            {
                List<usuariosInfo2> _usuariosInfo2 = new List<usuariosInfo2>();
                usuariosInfo2 usuariosInfo2 = new usuariosInfo2();
                using (SqlConnection conn = new SqlConnection(cadena))
                {

                    conn.Open();
                    DataSet ds = new DataSet();
                    string query = "insert into asesoriausuarios07 values (" + usuario + ","+ idcliente+",'"+mensaje+ "',null,1,0, getdate(),'NUTRIOLOGO')";
                    SqlCommand sqlComm = new SqlCommand(query, conn);
                    sqlComm.ExecuteNonQuery();
                    conn.Close();
                }                
            }
            catch (Exception)
            {


            }
            return false;
        }
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
        public Boolean insertarAlimentos(string idsocio, string idcomida, string idtipocomida, string idalimento, string vporcion, string fechacomida,string cadena)
        {          
            try
            {
                List<usuariosInfo2> _usuariosInfo2 = new List<usuariosInfo2>();
                usuariosInfo2 usuariosInfo2 = new usuariosInfo2();
                using (SqlConnection conn = new SqlConnection(cadena))
                {

                    conn.Open();
                    DataSet ds = new DataSet();
                    string query = " insert into recetasUsuario values(" + idsocio + "," + idcomida + "," + idtipocomida + "," + idalimento + ",'" + vporcion + "',(SELECT(TRY_CONVERT(date, '" + fechacomida  + "', 103)) ))";
                    SqlCommand sqlComm = new SqlCommand(query, conn);
                    sqlComm.ExecuteNonQuery();                
                    conn.Close();
                }
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
      
       public List<asesoriausuarios7> obtienechat(int usuario, int cliente, string cadena)
        {
            List<asesoriausuarios7> _usuariosInfo2 = new List<asesoriausuarios7>();
            asesoriausuarios7 usuariosInfo2 = new asesoriausuarios7();


            using (SqlConnection conn = new SqlConnection(cadena))
            {

                conn.Open();
                DataSet ds = new DataSet();
                string query = " select top 100 CB.*, (AB.nombre + ' ' + AB.apellidop) AS nombre from( " +
                               " SELECT BC.*, CASE WHEN BC.vtipocouch = 'NUTRIOLOGO' THEN BC.idusuario ELSE BC.idusuariocliente END AS idnombre FROM asesoriausuarios07 BC) CB " +
                                " inner join usuariosInfo02  AB " +
                               " ON AB.idusuario = CB.idnombre " +
                               " where cb.idusuario =  " + usuario +
                               "  and cb.idusuariocliente = " + cliente +
                               "  order by cb.idregistro asc ";
                SqlCommand sqlComm = new SqlCommand(query, conn);
                using (SqlDataReader dr = sqlComm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuariosInfo2 = new asesoriausuarios7
                        {                                               
                            idpregunta = Convert.ToInt32(dr["idpregunta"]),
                            idusuario= Convert.ToInt32(dr["idusuariocliente"]),
                            idusuarionutco = Convert.ToInt32(dr["idusuario"]),
                            idrespuesta = Convert.ToInt32(dr["idrespuesta"]),                            
                            nombreCompleto = dr["nombre"].ToString(),
                            vrespuesta = dr["vrespuesta"].ToString(),
                            vpregunta = dr["vpregunta"].ToString()
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


        public List<recetasAlimentos11> obtienealimentos(int socio, int idreceta, string cadena)
        {
            List<recetasAlimentos11> _usuariosInfo2 = new List<recetasAlimentos11>();
            recetasAlimentos11 usuariosInfo2 = new recetasAlimentos11();


            using (SqlConnection conn = new SqlConnection(cadena))
            {

                conn.Open();
                DataSet ds = new DataSet();
                string query =" select ab.* from recetasAlimentos11 ab "+
                                 "inner "+
                                  "                                         join recetas10 bc "+
                                   "                                  on ab.idreceta = bc.idreceta "+
                                 "where bc.idsocio =  "+ socio + 
                                "and ab.idreceta = " + idreceta  ;
                SqlCommand sqlComm = new SqlCommand(query, conn);
                using (SqlDataReader dr = sqlComm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuariosInfo2 = new recetasAlimentos11
                        {
                            idreceta= Convert.ToInt32(dr["idreceta"]),
                            idalimentos = Convert.ToInt32(dr["idalimento"]),
                            descripcion = dr["descripcion"].ToString(),
                            idRegistro = Convert.ToInt32(dr["idRegistro"])

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



        //

        public List<consultacliente> consuiltaclientes(int idsocio, string cadena)
        {
            List<consultacliente> _usuariosInfo2 = new List<consultacliente>();
            consultacliente usuariosInfo2 = new consultacliente();


            using (SqlConnection conn = new SqlConnection(cadena))
            {

                conn.Open();
                DataSet ds = new DataSet();
                string query = " select AB.* ,CD.* ,(DATEDIFF(DAY, getdate(),CASE WHEN CD.VIGENCIAFINAL IS NULL THEN 0  ELSE CD.VIGENCIAFINAL END)) as diasparaaVencer, " +
                               "  CASE " +
                                "          WHEN  CD.VIGENCIAFINAL IS NULL THEN 'SR' " +
                                 "         ELSE 'CR' " +
                                  "        END AS REGISTRO " +
                                " from(select * from usuariosInfo02 where vtipo = 'Usuario') AB " +
                                "INNER JOIN usuariosRelacion18 BC " +
                                "ON BC.idUSUARIOc = AB.idusuario " +
                                "LEFT JOIN PAGOS19 CD " +
                                "ON BC.idUSUARIOc = CD.IDUSUARIO " +
                                "WHERE BC.idUSUARIOs =" + idsocio;
                SqlCommand sqlComm = new SqlCommand(query, conn);
                using (SqlDataReader dr = sqlComm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuariosInfo2 = new consultacliente
                        {                            
                            idusuario = Convert.ToInt32(dr["idusuario"]),                          
                            nombre = dr["nombre"].ToString(),
                            apellidoP = dr["apellidop"].ToString(),
                            apellidoM = dr["apellidom"].ToString(),
                            vigenciaini = dr["VIGENCIAINICIAL"].ToString(),
                            vigenciafin = dr["VIGENCIAFINAL"].ToString(),
                            anual = dr["BANUAL"].ToString(),
                            mensual = dr["BMENSUAL"].ToString(),
                            registro = dr["REGISTRO"].ToString(),
                            diasrest = Convert.ToInt32(dr["diasparaaVencer"]),                             
                            edad = Convert.ToInt32(dr["edad"])
                        };
                        _usuariosInfo2.Add(usuariosInfo2);
                    }
                }
                conn.Close(); 
            }
            return _usuariosInfo2;
        }


        public List<recetas10> obtienerecetas(int idsocio, string cadena)
        {
            List<recetas10> _usuariosInfo2 = new List<recetas10>();
            recetas10 usuariosInfo2 = new recetas10();
          

            using (SqlConnection conn = new SqlConnection(cadena))
            {

                conn.Open();
                DataSet ds = new DataSet();
                string query = "select DISTINCT CD.* from  recetas10 CD " +
                                
                                "WHERE CD.idsocio = "+ idsocio;
                SqlCommand sqlComm = new SqlCommand(query, conn);
                using (SqlDataReader dr = sqlComm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuariosInfo2 = new recetas10
                        {
                            idreceta = Convert.ToInt32(dr["idreceta"]),
                            descripcion = dr["descripcion"].ToString()
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
        public List<usuariosInfo2> infoclienteNutriologo(int usuario, string cadenaconexion)
        {

            List<usuariosInfo2> _usuariosInfo2 = new List<usuariosInfo2>();
            usuariosInfo2 usuariosInfo2 = new usuariosInfo2();
            string cadenaconexion2 = "";

            using (SqlConnection conn = new SqlConnection(cadenaconexion))
            {

                conn.Open();
                DataSet ds = new DataSet();
                string query = "select * from usuariosInfo02 where idusuario = '" + usuario + "' ";
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

        public List<usuariossocios17> cbosocios(int idsocio,string cadenaconexion)
        {
            List<usuariossocios17> _usuariosInfo2 = new List<usuariossocios17>();
            usuariossocios17 usuariosInfo2 = new usuariossocios17();            
            using (SqlConnection conn = new SqlConnection(cadenaconexion))
            {
                conn.Open();
                DataSet ds = new DataSet();
                string query = "select idusuario,nombre,apellidop,apellidom from usuariosRelacion18 " +
                               " inner join usuariosInfo02 " +
                                 " on idusuario = idUSUARIOc " +
                                 "where idUSUARIOs = " + idsocio;
                SqlCommand sqlComm = new SqlCommand(query, conn);
                using (SqlDataReader dr = sqlComm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuariosInfo2 = new usuariossocios17
                        {
                            idUsuario = Convert.ToInt32(dr["idusuario"]),                            
                            nosbres = dr["nombre"].ToString(),    
                            ap = dr["apellidop"].ToString(),
                            am= dr["apellidom"].ToString()
                        };
                        _usuariosInfo2.Add(usuariosInfo2);
                    }
                }
                conn.Close();                
            }
            return _usuariosInfo2;
        }


    }
}
