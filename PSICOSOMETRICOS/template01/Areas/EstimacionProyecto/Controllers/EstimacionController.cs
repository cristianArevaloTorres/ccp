using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace template01.Areas.EstimacionProyecto.Controllers
{
    public class EstimacionController : Controller
    {
        // GET: EstimacionProyecto/Estimacion
        public ActionResult Index()
        {
            return View();
        }

        // GET: EstimacionProyecto/Estimacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EstimacionProyecto/Estimacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstimacionProyecto/Estimacion/Create
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

        // GET: EstimacionProyecto/Estimacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstimacionProyecto/Estimacion/Edit/5
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

        // GET: EstimacionProyecto/Estimacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstimacionProyecto/Estimacion/Delete/5
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
