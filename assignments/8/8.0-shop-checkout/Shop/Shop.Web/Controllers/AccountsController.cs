using Newtonsoft.Json;
using Shop.Models;
using Shop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class AccountsController : Controller
    {
        public AuthenticationContext Context { get; set; }

        public AccountsController()
        {
            Context = new AuthenticationContext();
        }
        // GET: Accounts
        public ActionResult Login(LoginRequest model)
        {
            SHA256 hasher = SHA256.Create();

            byte[] buffer = Encoding.UTF8.GetBytes(model.Password);

            var hash = hasher.ComputeHash(buffer);

            string password = BitConverter.ToString(hash).Replace("-", "");

            var account = Context.Accounts.FirstOrDefault(q => q.Email == model.Email);

            if(account.Password == password)
            {
                var user = new UserModel() { IsAuthenticated = true, Name = account.Email };
                user.Roles.Add("Consumer");

                var value = JsonConvert.SerializeObject(user);

                var cookie = new HttpCookie("authentication", value);

                Response.Cookies.Add(cookie);

                return Redirect("~/home");
            }
            else
            {
                return Redirect("~/home");
            }
           
        }

        public ActionResult LoginAccount()
        {
            return View();
        }

        public ActionResult RegisterAccount()
        {
            return View();
        }
        public ActionResult Register(RegisterRequest model)
        {
            SHA256 hasher = SHA256.Create();

            byte[] buffer = Encoding.UTF8.GetBytes(model.Password);

            var hash = hasher.ComputeHash(buffer);

            var account = new Account();
            account.Email = model.Email;
            account.Password = BitConverter.ToString(hash).Replace("-", "");

            Context.Accounts.Add(account);

            Context.SaveChanges();

            return Redirect("~/home");
        }
    }
}