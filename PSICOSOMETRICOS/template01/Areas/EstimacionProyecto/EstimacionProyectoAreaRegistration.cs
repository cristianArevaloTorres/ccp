using System.Web.Mvc;

namespace template01.Areas.EstimacionProyecto
{
    public class EstimacionProyectoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EstimacionProyecto";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EstimacionProyecto_default",
                "EstimacionProyecto/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}