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
    public class TempController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Temp/
        public ActionResult Index(string searchString)
        {

            var temps = from s in db.tempArticle
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                temps = temps.Where(s =>
            s.AuthorNAme.Equals(searchString)
            ||
            s.AuthorRole.Equals(searchString));
            }

            return View(temps.ToList());
        }
        public ActionResult History(string searchString)
        {

            var temp = from s in db.tempArticle
                        select s;
            searchString = Session["Name"].ToString();
            if (!String.IsNullOrEmpty(searchString))
            {
                temp = temp.Where(s => s.AuthorNAme.Equals(searchString));
            }

            return View(temp.ToList());
        }
        
        // GET: /Temp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempArticle temparticle = db.tempArticle.Find(id);
            temparticle.ViewNo = temparticle.ViewNo + 1;
            db.SaveChanges();

            if (temparticle == null)
            {
                return HttpNotFound();
            }
            return View(temparticle);
        }

        // GET: /Temp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Temp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ArticleId,Date,ViewNo,Title,Content")] TempArticle temparticle)
        {
            if (ModelState.IsValid)
            {
                temparticle.AuthorNAme = @Session["Name"].ToString();
                temparticle.AuthorRole = @Session["Role"].ToString();
                temparticle.ViewNo = 0;
                temparticle.Date = @DateTime.Now;
                db.tempArticle.Add(temparticle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(temparticle);
        }

        // GET: /Temp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempArticle temparticle = db.tempArticle.Find(id);
            if (temparticle == null)
            {
                return HttpNotFound();
            }
            return View(temparticle);
        }

        // POST: /Temp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ArticleId,Date,ViewNo,Title,Content")] TempArticle temparticle, Favourate fav)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temparticle).State = EntityState.Modified;
                db.favourate.Add(fav);
                db.SaveChanges();
               
                return RedirectToAction("Index", "Fav");
            }
            return View(fav);
        }
        public ActionResult Editt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempArticle temparticle = db.tempArticle.Find(id);
            if (temparticle == null)
            {
                return HttpNotFound();
            }
            return View(temparticle);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editt([Bind(Include = "ArticleId,Date,ViewNo,Title,Content")]TempArticle tempArticle)
        {
            if (ModelState.IsValid)
            {

                db.Entry(tempArticle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tempArticle);
        }


        // GET: /Temp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempArticle temparticle = db.tempArticle.Find(id);
            if (temparticle == null)
            {
                return HttpNotFound();
            }
            return View(temparticle);
        }

        // POST: /Temp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TempArticle temparticle = db.tempArticle.Find(id);
            db.tempArticle.Remove(temparticle);
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
