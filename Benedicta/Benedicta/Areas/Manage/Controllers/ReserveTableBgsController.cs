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
    public class ReserveTableBgsController : Controller
    {
        private BenedictaContext db = new BenedictaContext();

        // GET: Manage/ReserveTableBgs
        public ActionResult Index()
        {
            return View(db.ReserveTableBg.ToList());
        }

        // GET: Manage/ReserveTableBgs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveTableBg reserveTableBg = db.ReserveTableBg.Find(id);
            if (reserveTableBg == null)
            {
                return HttpNotFound();
            }
            return View(reserveTableBg);
        }

        // GET: Manage/ReserveTableBgs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/ReserveTableBgs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Photo")] ReserveTableBg reserveTableBg, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                reserveTableBg.Photo = fileName;
                db.ReserveTableBg.Add(reserveTableBg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reserveTableBg);
        }

        // GET: Manage/ReserveTableBgs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveTableBg reserveTableBg = db.ReserveTableBg.Find(id);
            if (reserveTableBg == null)
            {
                return HttpNotFound();
            }
            return View(reserveTableBg);
        }

        // POST: Manage/ReserveTableBgs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Photo")] ReserveTableBg reserveTableBg, HttpPostedFileBase Photo)
        {
            db.Entry(reserveTableBg).State = EntityState.Modified;


            if (Photo == null)
            {
                db.Entry(reserveTableBg).Property(r => r.Photo).IsModified = false;
            }
            else
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                reserveTableBg.Photo = fileName;
            }


            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reserveTableBg);
        }

        // GET: Manage/ReserveTableBgs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveTableBg reserveTableBg = db.ReserveTableBg.Find(id);
            if (reserveTableBg == null)
            {
                return HttpNotFound();
            }
            return View(reserveTableBg);
        }

        // POST: Manage/ReserveTableBgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReserveTableBg reserveTableBg = db.ReserveTableBg.Find(id);
            db.ReserveTableBg.Remove(reserveTableBg);
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
