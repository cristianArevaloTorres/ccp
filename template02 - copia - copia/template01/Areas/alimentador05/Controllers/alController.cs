using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace template01.Areas.alimentador05.Controllers
{
    public class alController : Controller
    {
        
            
        public ActionResult recetas()
        {
            return View();
        }
        public ActionResult alimentos()
        {
            return View();
        }






        // GET: alimentador05/al
        public ActionResult Index()
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
