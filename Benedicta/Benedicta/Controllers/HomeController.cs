using Benedicta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benedicta.Controllers
{
    public class HomeController : Controller
    {
        private readonly BenedictaContext db = new BenedictaContext();
        public ActionResult Index()
        {
            AddView model = new AddView();
            model.Welcomes = db.Welcome.OrderByDescending(w=>w.Id).Take(1).ToList();
            model.Services = db.Service.OrderByDescending(s => s.Id).Take(3).ToList();
            model.MenuUpdates = db.MenuUpdate.OrderByDescending(m => m.Id).Take(1).ToList();
            model.Menus = db.Menu.OrderByDescending(m => m.Id).Take(6).ToList();
            model.Settings = db.Setting.OrderByDescending(s => s.Id).Take(1).ToList();
            model.Properties = db.Property.OrderByDescending(p => p.Id).Take(2).ToList();
            model.ReserveTableBgs = db.ReserveTableBg.OrderByDescending(r => r.Id).Take(1).ToList();
            model.ReserveTables = db.ReserveTable.OrderByDescending(r => r.Id).Take(1).ToList();
            model.Abouts = db.About.OrderByDescending(a => a.Id).Take(1).ToList();
            model.Teas = db.Tea.OrderByDescending(t => t.Id).Take(1).ToList();
            model.News = db.New.OrderByDescending(n => n.Id).Take(3).ToList();
            model.Users = db.User.OrderByDescending(n => n.Id).Take(3).ToList();
            return View(model);
        }
    }
}