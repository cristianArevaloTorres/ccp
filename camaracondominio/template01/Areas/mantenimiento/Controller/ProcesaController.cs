using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace template01.Areas.mantenimiento.Controller
{
    public class ProcesaController : BaseController
    {
        // GET: mantenimiento/Procesa
        public ActionResult Index()
        {
            return View();
        }

        // GET: mantenimiento/Procesa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: mantenimiento/Procesa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mantenimiento/Procesa/Create
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

        // GET: mantenimiento/Procesa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: mantenimiento/Procesa/Edit/5
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

        // GET: mantenimiento/Procesa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: mantenimiento/Procesa/Delete/5
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
