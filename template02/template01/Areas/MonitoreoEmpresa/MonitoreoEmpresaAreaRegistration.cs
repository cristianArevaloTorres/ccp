using System.Web.Mvc;

namespace template01.Areas.MonitoreoEmpresa
{
    public class MonitoreoEmpresaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MonitoreoEmpresa";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MonitoreoEmpresa_default",
                "MonitoreoEmpresa/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}