using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace Shop.Web.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [RoutePrefix("Salesreport")]
    public class ReportController : Controller
    {
        private ShopContext Context { get; set; }
        public ReportController()
        {
            Context = new ShopContext();
        }
  
        [Route("")]
        public ActionResult SalesReport()
        {
            var transactions = Context.Transactions.ToList();
            return View(transactions);
        }
        public List<Transaction> Transactions { get; set; }
    }
}