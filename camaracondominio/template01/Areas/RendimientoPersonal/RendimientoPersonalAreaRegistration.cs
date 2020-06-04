using System.Web.Mvc;

namespace template01.Areas.RendimientoPersonal
{
    public class RendimientoPersonalAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RendimientoPersonal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RendimientoPersonal_default",
                "RendimientoPersonal/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}