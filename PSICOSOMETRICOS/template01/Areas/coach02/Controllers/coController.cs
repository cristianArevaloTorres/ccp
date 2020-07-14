using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace template01.Areas.coach02.Controllers
{
    public class coController : Controller
    {

        




         public ActionResult ConsultaClientes()
        {
            return View();
        }
        public ActionResult asesoriapersonal()
        {
            return View();
        }
        public ActionResult asignartareas()
        {
            return View();
        }


        // GET: coach02/co
        public ActionResult Index()
        {
            return View();
        }

        // GET: coach02/co/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: coach02/co/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: coach02/co/Create
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

        // GET: coach02/co/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: coach02/co/Edit/5
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

        // GET: coach02/co/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: coach02/co/Delete/5
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
