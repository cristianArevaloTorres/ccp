using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace template01.Areas.RendimientoPersonal.Controllers
{
    public class RendimientoController : Controller
    {
        // GET: RendimientoPersonal/Rendimiento
        public ActionResult Index()
        {
            return View();
        }

        // GET: RendimientoPersonal/Rendimiento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RendimientoPersonal/Rendimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RendimientoPersonal/Rendimiento/Create
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

        // GET: RendimientoPersonal/Rendimiento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RendimientoPersonal/Rendimiento/Edit/5
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

        // GET: RendimientoPersonal/Rendimiento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RendimientoPersonal/Rendimiento/Delete/5
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
