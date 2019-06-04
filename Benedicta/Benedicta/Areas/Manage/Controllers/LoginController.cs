using Benedicta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Benedicta.Areas.Manage.Controllers
{
    public class LoginController : Controller
    {
        private readonly BenedictaContext db = new BenedictaContext();

        public ActionResult Index()
        {

            if(Session["AdminLogin"] != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if(string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                Session["LoginError"] = "Your email or password is incorrect. Please try again...";

                return RedirectToAction("Index");

            }

            User us = db.User.FirstOrDefault(e => e.Email == user.Email);


            if (us != null)
            {
                if (Crypto.VerifyHashedPassword(us.Password, user.Password))
                {
                    Session["AdminLogin"] = true;
                    Session["Admin"] = us;
                    return RedirectToAction("Index", "Dashboard");
                }

            }

            Session["LoginError"] = "incorrect";

            return RedirectToAction("Index");


        }

    }
}