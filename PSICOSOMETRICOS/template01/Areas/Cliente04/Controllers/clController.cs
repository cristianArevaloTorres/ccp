using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace template01.Areas.Cliente04.Controllers
{
    public class clController : Controller
    {
        // GET: Cliente04/cl

                     
                       




              public ActionResult recetas()
        {
            return View();
        }
        public ActionResult elegirnutriologo()
        {
            return View();
        }
        public ActionResult tareas()
        {
            return View();
        }
        public ActionResult elegircoauch()
        {
            return View();
        }
        public ActionResult asesoriapersonal()
        {
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }

        // GET: Cliente04/cl/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente04/cl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente04/cl/Create
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

        // GET: Cliente04/cl/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente04/cl/Edit/5
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

        // GET: Cliente04/cl/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente04/cl/Delete/5
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
