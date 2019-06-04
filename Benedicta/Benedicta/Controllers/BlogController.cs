using Benedicta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benedicta.Controllers
{
    public class BlogController : Controller
    {
        private readonly BenedictaContext db = new BenedictaContext();

        public ActionResult Index()
        {
            AddView model = new AddView();
            model.News = db.New.OrderByDescending(n => n.Id).Take(5).ToList();
            model.Users = db.User.OrderByDescending(n => n.Id).Take(5).ToList();
            model.Settings = db.Setting.OrderByDescending(n => n.Id).Take(5).ToList();

            return View(model);
        }
    }
}