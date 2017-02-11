using Shop.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    [RoutePrefix("shop")]
    public class CustomerController : Controller
    {

        public ActionResult Customers()
        {
            return View();
        }
        public ActionResult CustomerView()
        {

            var controller = new ShopController();
            var customers = controller.GetCustomers();
            return View(customers);
        }
    }
}