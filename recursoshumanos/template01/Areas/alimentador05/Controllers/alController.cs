using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace template01.Areas.alimentador05.Controllers
{
    public class alController : Controller
    {

        public ActionResult AltaPersonal()
        {
            return View();
        }
        public ActionResult actualizaPersonal()
        {
            return View();
        }
        public ActionResult bajaPersonal()
        {
            return View();
        }
        public ActionResult vacaciones()
        {
            return View();
        }
        public ActionResult suspenciones()
        {
            return View();
        }
        public ActionResult listanegra()
        {
            return View();
        }
        public ActionResult segsocial()
        {
            return View();
        }
        public ActionResult asistencia()
        {
            return View();
        }
        public ActionResult kardex()
        {
            return View();
        }
        public ActionResult asinacuenta()
        {
            return View();
        }
        public ActionResult asignamaterial()
        {
            return View();
        }
        public ActionResult vehiculos()
        {
            return View();
        }
        public ActionResult computo()
        {
            return View();
        }
        public ActionResult herramienta()
        {
            return View();
        }
   
        /// <summary>
        /// /
        /// </summary>
        /// <summary>
        /// /
        /// </summary>
        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>

        // GET: alimentador05/al
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult permisos()
        {
            return View();
        }
        public ActionResult almacen()
        {
            return View();
        }
        public ActionResult marca()
        {
            return View();
        }
        public ActionResult sucursales()
        {
            return View();
        }
        public ActionResult altausuarios()
        {
            return View();
        }

        public ActionResult Reporte()
        {
            return View();
        }




        // GET: alimentador05/al
        public ActionResult entrada()
        {
            return View();
        }
        public ActionResult salida()
        {
            return View();
        }

        // GET: alimentador05/al/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: alimentador05/al/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: alimentador05/al/Create
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

        // GET: alimentador05/al/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: alimentador05/al/Edit/5
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

        // GET: alimentador05/al/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: alimentador05/al/Delete/5
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
