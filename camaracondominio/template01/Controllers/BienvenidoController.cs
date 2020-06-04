using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace template01.Controllers
{
    public class BienvenidoController : Controller
    {
        // GET: Bienvenido
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bienvenido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bienvenido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bienvenido/Create
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

        // GET: Bienvenido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bienvenido/Edit/5
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

        // GET: Bienvenido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bienvenido/Delete/5
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
