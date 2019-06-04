using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Benedicta.Models;

namespace Benedicta.Areas.Manage.Controllers
{
    public class SettingsController : Controller
    {
        private BenedictaContext db = new BenedictaContext();

        // GET: Manage/Settings
        public ActionResult Index()
        {
            return View(db.Setting.ToList());
        }

        // GET: Manage/Settings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Setting.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // GET: Manage/Settings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Settings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Logo,Facebook,Instagram,Phone,NavbarPhoto,Adress,Map")] Setting setting,HttpPostedFileBase NavbarPhoto,HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + NavbarPhoto.FileName;
                string path = Server.MapPath("~/Uploads/");
                NavbarPhoto.SaveAs(path + fileName);
                setting.NavbarPhoto = fileName;

                string fileNameLogo = DateTime.Now.ToString("yyyyMMddHHmmssff") + Logo.FileName;
                string pathLogo = Server.MapPath("~/Uploads/");
                Logo.SaveAs(path + fileName);
                setting.Logo = fileNameLogo;

                db.Setting.Add(setting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setting);
        }

        // GET: Manage/Settings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Setting.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: Manage/Settings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Logo,Facebook,Instagram,Phone,NavbarPhoto,Adress,Map")] Setting setting, HttpPostedFileBase Logo, HttpPostedFileBase NavbarPhoto)
        {
            db.Entry(setting).State = EntityState.Modified;

            if (Logo == null)
            {
                db.Entry(setting).Property(a => a.Logo).IsModified = false;
            }
            else
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Logo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Logo.SaveAs(path + fileName);
                setting.Logo = fileName;
            }
            if (NavbarPhoto == null)
            {
                db.Entry(setting).Property(a => a.NavbarPhoto).IsModified = false;
            }
            else
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + NavbarPhoto.FileName;
                string path = Server.MapPath("~/Uploads/");
                NavbarPhoto.SaveAs(path + fileName);
                setting.NavbarPhoto = fileName;
            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setting);
        }

        // GET: Manage/Settings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Setting.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: Manage/Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Setting setting = db.Setting.Find(id);
            db.Setting.Remove(setting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
