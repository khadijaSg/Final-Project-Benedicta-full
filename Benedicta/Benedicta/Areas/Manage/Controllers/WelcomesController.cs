using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Benedicta.Models;

namespace Benedicta.Areas.Manage.Controllers
{
    public class WelcomesController : Controller
    {
        private BenedictaContext db = new BenedictaContext();

        // GET: Manage/Welcomes
        public ActionResult Index()
        {
            return View(db.Welcome.ToList());
        }

        // GET: Manage/Welcomes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Welcome welcome = db.Welcome.Find(id);
            if (welcome == null)
            {
                return HttpNotFound();
            }
            return View(welcome);
        }

        // GET: Manage/Welcomes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Welcomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Word,Title,Text,Photo")] Welcome welcome,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                welcome.Photo = fileName;
                db.Welcome.Add(welcome);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(welcome);
        }

        // GET: Manage/Welcomes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Welcome welcome = db.Welcome.Find(id);
            if (welcome == null)
            {
                return HttpNotFound();
            }
            return View(welcome);
        }

        // POST: Manage/Welcomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Word,Title,Text,Photo")] Welcome welcome,HttpPostedFileBase Photo)
        {
            db.Entry(welcome).State = EntityState.Modified;

            if (Photo == null)
            {
                db.Entry(welcome).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                welcome.Photo = fileName;
            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(welcome);
        }

        // GET: Manage/Welcomes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Welcome welcome = db.Welcome.Find(id);
            if (welcome == null)
            {
                return HttpNotFound();
            }
            return View(welcome);
        }

        // POST: Manage/Welcomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Welcome welcome = db.Welcome.Find(id);
            db.Welcome.Remove(welcome);
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
