using Benedicta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benedicta.Controllers
{
    public class MenuController : Controller
    {

        private readonly BenedictaContext db = new BenedictaContext();

        public ActionResult Index()
        {
            AddView model = new AddView();
            model.Menus = db.Menu.OrderByDescending(m => m.Id).Take(6).ToList();
            model.MenuT1 = db.MenuT1.OrderByDescending(m => m.Id).Take(1).ToList();
            model.MenuT2 = db.MenuT2.OrderByDescending(m => m.Id).Take(1).ToList();
            model.Settings = db.Setting.OrderByDescending(m => m.Id).Take(1).ToList();
            return View(model);
        }
    }
}