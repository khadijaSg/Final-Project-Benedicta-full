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
    public class MenuT2Controller : Controller
    {
        private BenedictaContext db = new BenedictaContext();

        // GET: Manage/MenuT2
        public ActionResult Index()
        {
            return View(db.MenuT2.ToList());
        }

        // GET: Manage/MenuT2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuT2 menuT2 = db.MenuT2.Find(id);
            if (menuT2 == null)
            {
                return HttpNotFound();
            }
            return View(menuT2);
        }

        // GET: Manage/MenuT2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/MenuT2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,Photo")] MenuT2 menuT2, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                menuT2.Photo = fileName;
                db.MenuT2.Add(menuT2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuT2);
        }

        // GET: Manage/MenuT2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuT2 menuT2 = db.MenuT2.Find(id);
            if (menuT2 == null)
            {
                return HttpNotFound();
            }
            return View(menuT2);
        }

        // POST: Manage/MenuT2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,Photo")] MenuT2 menuT2, HttpPostedFileBase Photo)
        {
            db.Entry(menuT2).State = EntityState.Modified;


            if (Photo == null)
            {
                db.Entry(menuT2).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                menuT2.Photo = fileName;
            }


            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuT2);
        }

        // GET: Manage/MenuT2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuT2 menuT2 = db.MenuT2.Find(id);
            if (menuT2 == null)
            {
                return HttpNotFound();
            }
            return View(menuT2);
        }

        // POST: Manage/MenuT2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuT2 menuT2 = db.MenuT2.Find(id);
            db.MenuT2.Remove(menuT2);
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
