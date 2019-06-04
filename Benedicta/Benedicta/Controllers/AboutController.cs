using Benedicta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benedicta.Controllers
{
    public class AboutController : Controller
    {

        private readonly BenedictaContext db = new BenedictaContext();

        public ActionResult Index()
        {
            AddView model = new AddView();
            model.AboutInfos = db.AboutInfo.OrderByDescending(a => a.Id).Take(1).ToList();
            model.Properties = db.Property.OrderByDescending(s => s.Id).Take(3).ToList();
            model.Sliders = db.Slider.OrderByDescending(s => s.Id).Take(1).ToList();
            model.Settings = db.Setting.OrderByDescending(s => s.Id).Take(1).ToList();
            model.ReserveTableBgs = db.ReserveTableBg.OrderByDescending(s => s.Id).Take(1).ToList();
            return View(model);
        }
       
    }
}