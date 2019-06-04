using Benedicta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benedicta.Controllers
{
    public class ContactController : Controller
    {
        private readonly BenedictaContext db = new BenedictaContext();

        public ActionResult Index()
        {
            AddView model = new AddView();

            model.Settings = db.Setting.OrderByDescending(s => s.Id).Take(1).ToList();
            model.Contacts = db.Contact.OrderByDescending(s => s.Id).Take(1).ToList();

            model.ContactForms = db.ContactForm.OrderByDescending(s => s.Id).Take(1).ToList();
            return View(model);
        }
    }
}