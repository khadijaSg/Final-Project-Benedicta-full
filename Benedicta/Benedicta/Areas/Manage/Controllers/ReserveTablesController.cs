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
    public class ReserveTablesController : Controller
    {
        private BenedictaContext db = new BenedictaContext();

        // GET: Manage/ReserveTables
        public ActionResult Index()
        {
            return View(db.ReserveTable.ToList());
        }

        // GET: Manage/ReserveTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveTable reserveTable = db.ReserveTable.Find(id);
            if (reserveTable == null)
            {
                return HttpNotFound();
            }
            return View(reserveTable);
        }

        // GET: Manage/ReserveTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/ReserveTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Seats,Name,Email,Phone,Date,Time,SpecialRequests")] ReserveTable reserveTable)
        {
            if (ModelState.IsValid)
            {
                db.ReserveTable.Add(reserveTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reserveTable);
        }

        // GET: Manage/ReserveTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveTable reserveTable = db.ReserveTable.Find(id);
            if (reserveTable == null)
            {
                return HttpNotFound();
            }
            return View(reserveTable);
        }

        // POST: Manage/ReserveTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Seats,Name,Email,Phone,Date,Time,SpecialRequests")] ReserveTable reserveTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserveTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reserveTable);
        }

        // GET: Manage/ReserveTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveTable reserveTable = db.ReserveTable.Find(id);
            if (reserveTable == null)
            {
                return HttpNotFound();
            }
            return View(reserveTable);
        }

        // POST: Manage/ReserveTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReserveTable reserveTable = db.ReserveTable.Find(id);
            db.ReserveTable.Remove(reserveTable);
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
