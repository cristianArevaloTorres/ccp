using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Senado.Convocatoria.Areas.Validador
{
    public class ValidadorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Validador";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Validador_default",
                "Validador/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}