using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Dropbox.Api;
using template01.Models;
using DropBoxServiciosAccionesApi;


namespace template01.Controllers
{
    public class HomeController : Controller
    //AsyncController
    {



        public ActionResult Index()
        {
           // Class1 instanciar = new Class1(); 
            //DropboxUImodel dropb = new DropboxUImodel();
            //dropb.CreateFolder("/TestFolder2");
            return View();
        }
        // GET: Home
        //public async Task<ActionResult> Index()
        //{
        //    try
        //    {
        //        DropboxUImodel dropb = new DropboxUImodel();
        //          dropb.IniciarSessionDropBox();
        //       // var task = dropb.CreateFolder("/TestFolder");            
        //        return await Task.FromResult(this.View("Index"));
        //      //  DropboxUImodel dropb = new DropboxUImodel();

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally {

        //    }
        //    return View();

        //}
        public ActionResult table_static_basic()
        {
            return View();
        }
        public ActionResult table_static_responsive()
        {
            return View();
        }
        public ActionResult table_datatables_buttons()
        {
            return View();
        }

        public ActionResult Dashboard(string correo = "", string contraseño = "")
        {
            return View();
        }

        public ActionResult Formwizard()
        {
            return View();
        }

   

    }
}
