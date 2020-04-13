using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using template01.Models;
using YCP_DATA;

namespace template01.Areas.nutriologo01.Controllers
{
    public class nutController : BaseController
    {
        public ActionResult _sociosasesoria()
        {
            string cadena = WebConfigurationManager.ConnectionStrings["YCP_BD"].ConnectionString;
            List<YCP_DATA.usuariossocios17> _listasocios = new List<YCP_DATA.usuariossocios17>();
            List<Models.usuariossocios17> _listasociosvista = new List<Models.usuariossocios17>();
            Models.usuariossocios17 entidd = new Models.usuariossocios17();
            YCPdata serv = new YCPdata();
            _listasocios = serv.cbosocios((int)(Session["idUsuario"]), cadena);
            foreach (var item in _listasocios)
            {
                entidd = new Models.usuariossocios17
                {
                    idUsuario = item.idUsuario,
                    nosbres = item.nosbres,
                    ap = item.ap,
                    am = item.am
                };
                _listasociosvista.Add(entidd);
            }

            return PartialView("_sociosasesoria", _listasociosvista);
        }


        public JsonResult insertarAlimentos(string idsocio, string idcomida, string idtipocomida, string idalimento, string vporcion, string fechacomida)
        {
            string cadena = WebConfigurationManager.ConnectionStrings["YCP_BD"].ConnectionString;
            YCPdata serv = new YCPdata();
             serv.insertarAlimentos( idsocio,  idcomida,  idtipocomida,  idalimento,  vporcion,  fechacomida, cadena);
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet               
            };
        }
        public ActionResult _resultadobusquedaCliente(int idcliente = 0)
        {
            string cadena = WebConfigurationManager.ConnectionStrings["YCP_BD"].ConnectionString;
            List<YCP_DATA.usuariosInfo2> _listasocios = new List<YCP_DATA.usuariosInfo2>();
            List<Models.usuariosInfo2> _listasociosvista = new List<Models.usuariosInfo2>();
            Models.usuariosInfo2 entidd = new Models.usuariosInfo2();
            YCPdata serv = new YCPdata();
            _listasocios = serv.infoclienteNutriologo(idcliente, cadena);
            string nombre = "";
            int edad = 0;
            string razon = "";
            foreach (var item in _listasocios)
            {
                entidd = new Models.usuariosInfo2
                {
                    idusuario = item.idusuario,
                    nombre = item.nombre,
                    apellidoP = item.apellidoP,
                    apellidoM = item.apellidoM,
                    edad = item.edad,
                    vrazon = item.vrazon                   
                };
                _listasociosvista.Add(entidd);
            }
            nombre = _listasociosvista.FirstOrDefault().nombre + " " + _listasociosvista.FirstOrDefault().apellidoP + " " + _listasociosvista.FirstOrDefault().apellidoM;
            edad = _listasociosvista.FirstOrDefault().edad;
            razon = _listasociosvista.FirstOrDefault().vrazon;
            ViewBag.idcliente = idcliente;
            ViewBag.nombre = nombre;
            ViewBag.edad = edad;
            ViewBag.razon = razon;
            return PartialView("_resultadobusquedaCliente");
        }

        //idsocio de session se saca 
        
         public ActionResult _obtienealimentos(int idsocio = 0,int idreceta = 0)
        {
            string cadena = WebConfigurationManager.ConnectionStrings["YCP_BD"].ConnectionString;
            List<YCP_DATA.recetasAlimentos11> _listasocios = new List<YCP_DATA.recetasAlimentos11>();
            List<Models.recetasAlimentos11> _listasociosvista = new List<Models.recetasAlimentos11>();
            Models.recetasAlimentos11 entidd = new Models.recetasAlimentos11();
            YCPdata serv = new YCPdata();
            _listasocios = serv.obtienealimentos((int)(Session["idUsuario"]), idreceta, cadena);
            foreach (var item in _listasocios)
            {
                entidd = new Models.recetasAlimentos11
                {
                    idreceta = item.idreceta,
                    idalimentos = item.idalimentos,
                    descripcion = item.descripcion,
                    idRegistro = item.idRegistro
                };
                _listasociosvista.Add(entidd);
            }
            ViewBag.idreceta = idreceta;
            return PartialView("_obtienealimentos", _listasociosvista);
        }
        public ActionResult _obtieneRecetasaltas(int idsocio = 0)
        {
            string cadena = WebConfigurationManager.ConnectionStrings["YCP_BD"].ConnectionString;
            List<YCP_DATA.recetas10> _listasocios = new List<YCP_DATA.recetas10>();
            List<Models.recetas10> _listasociosvista = new List<Models.recetas10>();
            Models.recetas10 entidd = new Models.recetas10();
            YCPdata serv = new YCPdata();
            _listasocios = serv.obtienerecetas((int)(Session["idUsuario"]), cadena);
            foreach (var item in _listasocios)
            {
                entidd = new Models.recetas10
                {
                    idreceta = item.idreceta,
                    descripcion = item.descripcion
                };
                _listasociosvista.Add(entidd);
            }

            return PartialView("_obtieneRecetasaltas", _listasociosvista);
        }
        public ActionResult _obtienelcientes()
        {
            string cadena = WebConfigurationManager.ConnectionStrings["YCP_BD"].ConnectionString;
            List<YCP_DATA.usuariossocios17> _listasocios = new List<YCP_DATA.usuariossocios17>();
            List<Models.usuariossocios17> _listasociosvista = new List<Models.usuariossocios17>();
            Models.usuariossocios17 entidd = new Models.usuariossocios17();
            YCPdata serv = new YCPdata();
            _listasocios = serv.cbosocios((int)(Session["idUsuario"]), cadena);
            foreach (var item in _listasocios)
            {
                entidd = new Models.usuariossocios17
                {
                    idUsuario = item.idUsuario,
                    nosbres = item.nosbres,
                    ap = item.ap,
                    am = item.am
                };
                _listasociosvista.Add(entidd);
            }
          
            return PartialView("_obtienelcientes", _listasociosvista);
        }


        public ActionResult ConsultaClientes()
        {
            string cadena = WebConfigurationManager.ConnectionStrings["YCP_BD"].ConnectionString;
            List<YCP_DATA.consultacliente> _listasocios = new List<YCP_DATA.consultacliente>();
            List<Models.consultacliente> _listasociosvista = new List<Models.consultacliente>();
            Models.consultacliente entidd = new Models.consultacliente();
            YCPdata serv = new YCPdata();
            _listasocios = serv.consuiltaclientes((int)(Session["idUsuario"]), cadena);
            foreach (var item in _listasocios)
            {
                entidd = new Models.consultacliente
                {
                    idusuario = item.idusuario,
                    nombre = item.nombre,
                    apellidoP = item.apellidoP,
                    apellidoM = item.apellidoM,
                    vigenciaini = item.vigenciaini,
                    vigenciafin = item.vigenciafin,
                    anual = item.anual,
                    mensual = item.mensual,
                    registro = item.registro,
                    diasrest = item.diasrest,
                    edad = item.edad
                };
                _listasociosvista.Add(entidd);
            }
            
            return PartialView("ConsultaClientes", _listasociosvista);
        }
        public ActionResult Asignarrecetacliente()
        {
            return View();
        }
        public ActionResult asesoriapersonal()
        {
            return View();
        }
        public ActionResult datosclienteavances()
        {
            return View();
        }






        // GET: nutriologo01/nut
        public ActionResult Index()
        {
            return View();
        }

        // GET: nutriologo01/nut/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: nutriologo01/nut/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: nutriologo01/nut/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: nutriologo01/nut/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: nutriologo01/nut/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: nutriologo01/nut/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: nutriologo01/nut/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
