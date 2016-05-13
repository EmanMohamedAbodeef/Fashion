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
    public class ArticleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Article/

        public ActionResult Index(string searchString)
        {
           
            var articles = from s in db.article
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s =>
            s.Title.Equals(searchString.ToUpper())
            ||
            s.Content.Equals(searchString.ToUpper()));
            }
            
            return View(articles.ToList());
        }


        // GET: /Article/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: /Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Article/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleId,Date,ViewNo,Title,Content,AuthorNAme,AuthorRole")] Article article )
        {
            if (ModelState.IsValid)
            {
                article.AuthorNAme = @Session["Name"].ToString();
                article.AuthorRole = @Session["Role"].ToString();
                article.ViewNo = 0;
                article.Date = @DateTime.Now;
                db.article.Add(article);
                db.SaveChanges();
                ViewBag.Message = "Your Article Has Been Sent Successfully. Please wait for Admin Approval.";

                return View();
            }

            return View(article);
        }

        // GET: /Article/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }
        public ActionResult Editt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editt([Bind(Include = "ArticleId,Date,ViewNo,Title,Content")] Article article, TempArticle tempArticle)
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
        public ActionResult Edit([Bind(Include="ArticleId,Date,ViewNo,Title,Content")] Article article , TempArticle tempArticle)
        {
            if (ModelState.IsValid)
            {
      
                db.Entry(article).State = EntityState.Modified;
                db.tempArticle.Add(tempArticle);
                db.SaveChanges();
                db.article.Remove(article);
                db.SaveChanges();
                return RedirectToAction("Index","Temp");
            }
            return View(tempArticle);
        }
        
        // GET: /Article/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: /Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.article.Find(id);
            db.article.Remove(article);
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
