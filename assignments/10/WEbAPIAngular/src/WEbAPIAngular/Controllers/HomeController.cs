using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace WEbAPIAngular
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("~/account/login");

            }
            return Redirect("~/rooms/browse");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}





