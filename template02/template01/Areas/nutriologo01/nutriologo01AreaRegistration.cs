using System.Web.Mvc;

namespace template01.Areas.nutriologo01
{
    public class nutriologo01AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "nutriologo01";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "nutriologo01_default",
                "nutriologo01/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}