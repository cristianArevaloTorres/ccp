using System.Web.Mvc;

namespace template01.Areas.jachicko
{
    public class jachickoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "jachicko";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "jachicko_default",
                "jachicko/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}