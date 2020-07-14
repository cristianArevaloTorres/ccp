using System.Web.Mvc;

namespace template01.Areas.alimentador05
{
    public class alimentador05AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "alimentador05";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "alimentador05_default",
                "alimentador05/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}