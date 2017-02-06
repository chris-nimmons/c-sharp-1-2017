using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult ProductListPartial()
        {
            var controller = new ShopController();
            var products = controller.GetProducts();

            return View(products);
        }

        public ActionResult Depends()
        {
            return View();
        }

        public ActionResult NerfGun()
        {
            return View();
        }

        public ActionResult ComputerMouse()
        {
            return View();
        }
    }
}