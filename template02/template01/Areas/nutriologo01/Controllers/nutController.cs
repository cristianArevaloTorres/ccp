using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace template01.Areas.nutriologo01.Controllers
{
    public class nutController : Controller
    {

        





      public ActionResult ConsultaClientes()
        {
            return View();
        }
        public ActionResult Asignarrecetacliente()
        {
            return View();
        }
        public ActionResult asesoriapersonal()
        {
            return View();
        }
        public ActionResult datosclienteavances()
        {
            return View();
        }






        // GET: nutriologo01/nut
        public ActionResult Index()
        {
            return View();
        }

        // GET: nutriologo01/nut/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: nutriologo01/nut/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: nutriologo01/nut/Create
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

        // GET: nutriologo01/nut/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: nutriologo01/nut/Edit/5
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

        // GET: nutriologo01/nut/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: nutriologo01/nut/Delete/5
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
