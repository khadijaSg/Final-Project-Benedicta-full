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
    public class TeasController : Controller
    {
        private BenedictaContext db = new BenedictaContext();

        // GET: Manage/Teas
        public ActionResult Index()
        {
            return View(db.Tea.ToList());
        }

        // GET: Manage/Teas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tea tea = db.Tea.Find(id);
            if (tea == null)
            {
                return HttpNotFound();
            }
            return View(tea);
        }

        // GET: Manage/Teas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Teas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,Photo")] Tea tea,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                tea.Photo = fileName;
                db.Tea.Add(tea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tea);
        }

        // GET: Manage/Teas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tea tea = db.Tea.Find(id);
            if (tea == null)
            {
                return HttpNotFound();
            }
            return View(tea);
        }

        // POST: Manage/Teas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,Photo")] Tea tea,HttpPostedFileBase Photo)
        {
            db.Entry(tea).State = EntityState.Modified;

            if (Photo == null)
            {
                db.Entry(tea).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                tea.Photo = fileName;
            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tea);
        }

        // GET: Manage/Teas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tea tea = db.Tea.Find(id);
            if (tea == null)
            {
                return HttpNotFound();
            }
            return View(tea);
        }

        // POST: Manage/Teas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tea tea = db.Tea.Find(id);
            db.Tea.Remove(tea);
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
