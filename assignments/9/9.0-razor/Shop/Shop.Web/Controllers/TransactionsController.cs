using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class TransactionsController : Controller
    {
        // GET: Transaction
        public ActionResult Transactions()
        {
            return View();
        }
    }
}