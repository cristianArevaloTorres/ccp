using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace template01.Areas.jachicko.Controllers
{
    public class jaController : Controller
    {
        // GET: jachicko/ja

        public ActionResult preguntaIA()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: jachicko/ja/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: jachicko/ja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: jachicko/ja/Create
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

        // GET: jachicko/ja/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: jachicko/ja/Edit/5
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

        // GET: jachicko/ja/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: jachicko/ja/Delete/5
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
