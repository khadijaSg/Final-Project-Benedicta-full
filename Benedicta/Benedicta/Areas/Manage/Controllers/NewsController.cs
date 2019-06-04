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
    public class NewsController : Controller
    {
        private BenedictaContext db = new BenedictaContext();

        // GET: Manage/News
        public ActionResult Index()
        {
            var user = db.New.Include(n => n.User);
            return View(user.ToList());
        }

        // GET: Manage/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.New.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: Manage/News/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.User, "Id", "Name");
            return View();
        }

        // POST: Manage/News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Photo,DateTime,Title,Text,UserId")] News news,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                news.Photo = fileName;
                db.New.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.User, "Id", "Name", news.UserId);
            return View(news);
        }

        // GET: Manage/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.New.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.User, "Id", "Name", news.UserId);
            return View(news);
        }

        // POST: Manage/News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Photo,DateTime,Title,Text,UserId")] News news,HttpPostedFileBase Photo)
        {
            db.Entry(news).State = EntityState.Modified;

            if (Photo == null)
            {
                db.Entry(news).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Photo.FileName;
                string path = Server.MapPath("~/Uploads/");
                Photo.SaveAs(path + fileName);
                news.Photo = fileName;
            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.User, "Id", "Name", news.UserId);
            return View(news);
        }

        // GET: Manage/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.New.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Manage/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.New.Find(id);
            db.New.Remove(news);
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
