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
    public class MenuT1Controller : Controller
    {
        private BenedictaContext db = new BenedictaContext();

        // GET: Manage/MenuT1
        public ActionResult Index()
        {
            return View(db.MenuT1.ToList());
        }

        // GET: Manage/MenuT1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuT1 menuT1 = db.MenuT1.Find(id);
            if (menuT1 == null)
            {
                return HttpNotFound();
            }
            return View(menuT1);
        }

        // GET: Manage/MenuT1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/MenuT1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,Photo")] MenuT1 menuT1, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                menuT1.Photo = fileName;
                db.MenuT1.Add(menuT1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuT1);
        }

        // GET: Manage/MenuT1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuT1 menuT1 = db.MenuT1.Find(id);
            if (menuT1 == null)
            {
                return HttpNotFound();
            }
            return View(menuT1);
        }

        // POST: Manage/MenuT1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,Photo")] MenuT1 menuT1, HttpPostedFileBase Photo)
        {
            db.Entry(menuT1).State = EntityState.Modified;


            if (Photo == null)
            {
                db.Entry(menuT1).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                menuT1.Photo = fileName;
            }


            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuT1);
        }

        // GET: Manage/MenuT1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuT1 menuT1 = db.MenuT1.Find(id);
            if (menuT1 == null)
            {
                return HttpNotFound();
            }
            return View(menuT1);
        }

        // POST: Manage/MenuT1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuT1 menuT1 = db.MenuT1.Find(id);
            db.MenuT1.Remove(menuT1);
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
