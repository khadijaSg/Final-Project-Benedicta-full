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
    public class MenuUpdatesController : Controller
    {
        private BenedictaContext db = new BenedictaContext();

        // GET: Manage/MenuUpdates
        public ActionResult Index()
        {
            return View(db.MenuUpdate.ToList());
        }

        // GET: Manage/MenuUpdates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuUpdate menuUpdate = db.MenuUpdate.Find(id);
            if (menuUpdate == null)
            {
                return HttpNotFound();
            }
            return View(menuUpdate);
        }

        // GET: Manage/MenuUpdates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/MenuUpdates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,Photo")] MenuUpdate menuUpdate,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                menuUpdate.Photo = fileName;
                db.MenuUpdate.Add(menuUpdate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuUpdate);
        }

        // GET: Manage/MenuUpdates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuUpdate menuUpdate = db.MenuUpdate.Find(id);
            if (menuUpdate == null)
            {
                return HttpNotFound();
            }
            return View(menuUpdate);
        }

        // POST: Manage/MenuUpdates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,Photo")] MenuUpdate menuUpdate,HttpPostedFileBase Photo)
        {
            db.Entry(menuUpdate).State = EntityState.Modified;

            if (Photo == null)
            {
                db.Entry(menuUpdate).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                menuUpdate.Photo = fileName;
            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuUpdate);
        }

        // GET: Manage/MenuUpdates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuUpdate menuUpdate = db.MenuUpdate.Find(id);
            if (menuUpdate == null)
            {
                return HttpNotFound();
            }
            return View(menuUpdate);
        }

        // POST: Manage/MenuUpdates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuUpdate menuUpdate = db.MenuUpdate.Find(id);
            db.MenuUpdate.Remove(menuUpdate);
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
