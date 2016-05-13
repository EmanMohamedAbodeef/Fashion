using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FashionIA.Models;

namespace FashionIA.Controllers
{
    public class FavController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Fav/
        public ActionResult Index()
        {
            return View(db.favourate.ToList());
        }

        // GET: /Fav/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favourate favourate = db.favourate.Find(id);
            if (favourate == null)
            {
                return HttpNotFound();
            }
            return View(favourate);
        }

        // GET: /Fav/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Fav/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ArticleId,Date,ViewNo,Title,Content,feild,AuthorNAme,AuthorRole")] Favourate favourate)
        {
            if (ModelState.IsValid)
            {
                db.favourate.Add(favourate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(favourate);
        }

        // GET: /Fav/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favourate favourate = db.favourate.Find(id);
            if (favourate == null)
            {
                return HttpNotFound();
            }
            return View(favourate);
        }

        // POST: /Fav/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ArticleId,Date,ViewNo,Title,Content,feild,AuthorNAme,AuthorRole")] Favourate favourate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favourate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(favourate);
        }

        // GET: /Fav/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favourate favourate = db.favourate.Find(id);
            if (favourate == null)
            {
                return HttpNotFound();
            }
            return View(favourate);
        }

        // POST: /Fav/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Favourate favourate = db.favourate.Find(id);
            db.favourate.Remove(favourate);
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
