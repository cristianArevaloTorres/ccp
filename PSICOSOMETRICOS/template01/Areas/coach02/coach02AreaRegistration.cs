using System.Web.Mvc;

namespace template01.Areas.coach02
{
    public class coach02AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "coach02";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "coach02_default",
                "coach02/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}