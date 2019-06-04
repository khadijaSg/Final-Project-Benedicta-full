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
    public class ContactsController : Controller
    {
        private BenedictaContext db = new BenedictaContext();

        // GET: Manage/Contacts
        public ActionResult Index()
        {
            return View(db.Contact.ToList());
        }

        // GET: Manage/Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Manage/Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,Photo")] Contact contact,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                contact.Photo = fileName;
                db.Contact.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Manage/Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Manage/Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,Photo")] Contact contact,HttpPostedFileBase Photo)
        {
            db.Entry(contact).State = EntityState.Modified;

            if (Photo == null)
            {
                db.Entry(contact).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                contact.Photo = fileName;
            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Manage/Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Manage/Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contact.Find(id);
            db.Contact.Remove(contact);
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
