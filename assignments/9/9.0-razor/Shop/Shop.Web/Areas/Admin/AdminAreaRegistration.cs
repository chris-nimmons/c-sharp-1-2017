using System.Web.Mvc;
using Shop.Models;

namespace Shop.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "admin/{controller}/{action}/{id}",
                new { controller = "Products", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { " Shop.Web.Areas.Admin.Controllers" }
            );
        }
    }
}
