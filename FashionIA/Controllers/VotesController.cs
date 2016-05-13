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
    public class VotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Votes/
        public ActionResult Index()
        {
            return View(db.vote.ToList());
        }

        // GET: /Votes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.vote.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

       
        public ActionResult Create_()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create_(Vote vote)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                            if (ModelState.IsValid){

                var vot = db.vote.Add( vote);
                if (vot != null)
                {
                    if (vot.Name == "Excellent" || vot.Name == "Good" || vot.Name == "Satisfactory" || vot.Name == "Improvement" || vot.Name == "Improvement" || vot.Name == "Poor")
                    {
                        vot.Count = vot.Count + 1;
                        vot.Result = (vot.Count * 100) / 30;
                        db.SaveChanges();
                        ViewBag.Message = "Thanks For Your Time";


                        return View();

                    }

                }
            }
            }
            return View(vote);

        }
        // GET: /Votes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.vote.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

        // POST: /Votes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Count,Result")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vote);
        }

        // GET: /Votes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.vote.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

        // POST: /Votes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vote vote = db.vote.Find(id);
            db.vote.Remove(vote);
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
