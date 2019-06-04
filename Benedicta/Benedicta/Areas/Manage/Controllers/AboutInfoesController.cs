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
    public class AboutInfoesController : Controller
    {
        private BenedictaContext db = new BenedictaContext();

        // GET: Manage/AboutInfoes
        public ActionResult Index()
        {
            return View(db.AboutInfo.ToList());
        }

        // GET: Manage/AboutInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutInfo aboutInfo = db.AboutInfo.Find(id);
            if (aboutInfo == null)
            {
                return HttpNotFound();
            }
            return View(aboutInfo);
        }

        // GET: Manage/AboutInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/AboutInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,Photo")] AboutInfo aboutInfo, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                aboutInfo.Photo = fileName;
                db.AboutInfo.Add(aboutInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aboutInfo);
        }

        // GET: Manage/AboutInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutInfo aboutInfo = db.AboutInfo.Find(id);
            if (aboutInfo == null)
            {
                return HttpNotFound();
            }
            return View(aboutInfo);
        }

        // POST: Manage/AboutInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,Photo")] AboutInfo aboutInfo, HttpPostedFileBase Photo)
        {

            db.Entry(aboutInfo).State = EntityState.Modified;


            if (Photo == null)
            {
                db.Entry(aboutInfo).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                aboutInfo.Photo = fileName;
            }


            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutInfo);
        }

        // GET: Manage/AboutInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutInfo aboutInfo = db.AboutInfo.Find(id);
            if (aboutInfo == null)
            {
                return HttpNotFound();
            }
            return View(aboutInfo);
        }

        // POST: Manage/AboutInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutInfo aboutInfo = db.AboutInfo.Find(id);
            db.AboutInfo.Remove(aboutInfo);
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
