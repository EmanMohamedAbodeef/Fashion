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
    public class AdvertisesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Advertises/
        public ActionResult Index(string searchString)
        {

            var advertises = from s in db.advertise
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                advertises = advertises.Where(s =>
            s.Title.Equals(searchString.ToUpper())
            ||
            s.Content.Equals(searchString.ToUpper()));
            }

            return View(advertises.ToList());
        }

        public ActionResult History(string searchString)
        {

            var temp = from s in db.advertise
                       select s;
            searchString = Session["Name"].ToString();
            if (!String.IsNullOrEmpty(searchString))
            {
                temp = temp.Where(s => s.AuthorNAme.Equals(searchString));
            }

            return View(temp.ToList());
        }
        // GET: /Advertises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertise advertise = db.advertise.Find(id);


            if (advertise == null)
            {
                return HttpNotFound();
            }
            return View(advertise);
        }

        // GET: /Advertises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Advertises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Date,ViewNo,Title,Content")] Advertise advertise)
        {
            if (ModelState.IsValid)
            {
                advertise.AuthorNAme = @Session["Name"].ToString();
                advertise.AuthorRole = @Session["Role"].ToString();
                advertise.ViewNo = 0;
                advertise.Date = @DateTime.Now;
                db.advertise.Add(advertise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advertise);
        }

        // GET: /Advertises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertise advertise = db.advertise.Find(id);
            if (advertise == null)
            {
                return HttpNotFound();
            }
            return View(advertise);
        }
        public ActionResult Editt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertise advertise = db.advertise.Find(id);
            if (advertise == null)
            {
                return HttpNotFound();
            }
            return View(advertise);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editt([Bind(Include = "ID,Date,ViewNo,Title,Content")] Advertise article, TempArticle tempArticle)
        {
            if (ModelState.IsValid)
            {

                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // POST: /Article/Edit/Temp/Intex
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,ViewNo,Title,Content")] Advertise advertise, TempArticle tempArticle)
        {
            if (ModelState.IsValid)
            {

                db.Entry(advertise).State = EntityState.Modified;
                db.tempArticle.Add(tempArticle);
                db.SaveChanges();
                db.advertise.Remove(advertise);
                db.SaveChanges();
                return RedirectToAction("Index", "Temp");
            }
            return View(tempArticle);
        }
        

        // GET: /Advertises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertise advertise = db.advertise.Find(id);
            if (advertise == null)
            {
                return HttpNotFound();
            }
            return View(advertise);
        }

        // POST: /Advertises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertise advertise = db.advertise.Find(id);
            db.advertise.Remove(advertise);
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
