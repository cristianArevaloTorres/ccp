using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace template01.Areas.MonitoreoEmpresa.Controllers
{
    public class MonitorbusController : Controller
    {
        // GET: MonitoreoEmpresa/Monitorbus
        public ActionResult Index()
        {
            return View();
        }

        // GET: MonitoreoEmpresa/Monitorbus/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MonitoreoEmpresa/Monitorbus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonitoreoEmpresa/Monitorbus/Create
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

        // GET: MonitoreoEmpresa/Monitorbus/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MonitoreoEmpresa/Monitorbus/Edit/5
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

        // GET: MonitoreoEmpresa/Monitorbus/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MonitoreoEmpresa/Monitorbus/Delete/5
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
