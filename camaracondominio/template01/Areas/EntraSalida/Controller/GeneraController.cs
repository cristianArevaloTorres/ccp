using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace template01.Areas.EntraSalida.Controller
{
    public class GeneraController : BaseController
    {
        // GET: EntraSalida/Genera
        public ActionResult Index()
        {
            return View();
        }

        // GET: EntraSalida/Genera/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EntraSalida/Genera/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntraSalida/Genera/Create
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

        // GET: EntraSalida/Genera/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EntraSalida/Genera/Edit/5
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

        // GET: EntraSalida/Genera/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EntraSalida/Genera/Delete/5
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
