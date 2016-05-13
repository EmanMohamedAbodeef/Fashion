using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FashionIA.Models;
using System.Web.Security;

namespace FashionIA.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Account/
        public ActionResult Index(string searchString)
        {

            var users = from s in db.user
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s =>
            s.Email.Equals(searchString.ToUpper())
            ||
            s.Name.Equals(searchString.ToUpper()));
            }

            return View(users.ToList());
        }
        public ActionResult Index2()
        {

            return View();
        }

        //login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult Partial1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var usr = db.user.Single(u => u.Email == user.Email && u.Password == user.Password && u.Role == user.Role);
                if (usr != null)
                {
                    if (user.Email == "mohamedhassan12333@yahoo.com" &&( user.Role=="admin" || user.Role=="Admin"))
                    {
                        Session["UID"] = usr.ID.ToString();
                        Session["Email"] = usr.Email.ToString();
                        Session["Role"] = usr.Role.ToString();
                        Session["Name"] = usr.Name.ToString();
                        Session["Password"] = usr.Password.ToString();



                        return RedirectToAction("Index2");
                    }
                    else if (usr.Email == user.Email && (user.Role == "Editor" || user.Role == "editor"))
                    {
                        Session["UID"] = usr.ID.ToString();
                        Session["Email"] = usr.Email.ToString();
                        Session["Role"] = usr.Role.ToString();
                        Session["Name"] = usr.Name.ToString();
                        Session["Password"] = usr.Password.ToString();

                        return RedirectToAction("Profile");
                    }
                    else if (usr.Email == user.Email && (user.Role == "user" || user.Role == "User"))
                    {
                        Session["UID"] = usr.ID.ToString();
                        Session["Email"] = usr.Email.ToString();
                        Session["Role"] = usr.Role.ToString();
                        Session["Name"] = usr.Name.ToString();
                        Session["Password"] = usr.Password.ToString();

                        return RedirectToAction("LoggedIn");
                    }
                    else
                    {
                              ViewBag.Message = "you entred invaled user name or password";

                    }
                }
                else
                {
                    ModelState.AddModelError("", "you entred invaled user name or password");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {

            if (file != null)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/images/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);

                //save new record in database
                User newRecord = new User();
                newRecord.Name = Request.Form["Name"];
                newRecord.Password = Request.Form["Password"];
                newRecord.Role = Request.Form["Role"];
                newRecord.Image = ImageName;
                newRecord.Email = Request.Form["Email"];
                db.user.Add(newRecord);
                db.SaveChanges();

            }
            //Display records
            return RedirectToAction("Login");
        }

        public ActionResult Display()
        {
            return View();
        }

        // GET: /Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,Password,Role,Image,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                db.user.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }

        // GET: /Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Password,Role,Image,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

 

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index2([Bind(Include = "ID,Name,Password,Role,Image,Email")]User user)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        ApplicationDbContext db = new ApplicationDbContext();
            

        //        //save new record in database
        //        User newRecord = new User();
        //        newRecord.Name = Request.Form["UID"];
        //        newRecord.Name = Request.Form["Name"];
        //        newRecord.Password = Request.Form["Password"];
        //        newRecord.Role = Request.Form["Role"];             
        //        newRecord.Email = Request.Form["Email"];
        //        db.Entry(newRecord).State = EntityState.Modified;
        //        db.SaveChanges();

        //    }
        //    //Display records
        //    return RedirectToAction("Index");
        //}

        // GET: /Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.user.Find(id);
            db.user.Remove(user);
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
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            try
            {
                /*Geting the file name*/
                string filename = System.IO.Path.GetFileName(file.FileName);
                /*Saving the file in server folder*/
                file.SaveAs(Server.MapPath("~/Images/" + filename));
                string filepathtosave = "Images/" + filename;
                /*Storing image path to show preview*/
                ViewBag.Image = filepathtosave;
                /*
                 * HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE
                 *
                 */

                ViewBag.Message = "File Uploaded successfully.";
            }
            catch
            {
                ViewBag.Message = "Error while uploading the files.";
            }
            return RedirectToAction("Profile");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditAdmin(HttpPostedFileBase file)
        {
            try
            {
                /*Geting the file name*/
                string filename = System.IO.Path.GetFileName(file.FileName);
                /*Saving the file in server folder*/
                file.SaveAs(Server.MapPath("~/Images/" + filename));
                string filepathtosave = "Images/" + filename;
                /*Storing image path to show preview*/
                ViewBag.Image = filepathtosave;
                /*
                 * HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE
                 *
                 */

                ViewBag.Message = "File Uploaded successfully.";
            }
            catch
            {
                ViewBag.Message = "Error while uploading the files.";
            }
            return RedirectToAction("Index2");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Upload2(HttpPostedFileBase file)
        {
            try
            {
                /*Geting the file name*/
                string filename = System.IO.Path.GetFileName(file.FileName);
                /*Saving the file in server folder*/
                file.SaveAs(Server.MapPath("~/Images/" + filename));
                string filepathtosave = "Images/" + filename;
                /*Storing image path to show preview*/
                ViewBag.Image = filepathtosave;
                /*
                 * HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE
                 *
                 */

                ViewBag.Message = "File Uploaded successfully.";
            }
            catch
            {
                ViewBag.Message = "Error while uploading the files.";
            }
            return RedirectToAction("Index2");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Upload3(HttpPostedFileBase file)
        {
            try
            {
                /*Geting the file name*/
                string filename = System.IO.Path.GetFileName(file.FileName);
                /*Saving the file in server folder*/
                file.SaveAs(Server.MapPath("~/Images/" + filename));
                string filepathtosave = "Images/" + filename;
                /*Storing image path to show preview*/
                ViewBag.Image = filepathtosave;
                /*
                 * HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE
                 *
                 */

                ViewBag.Message = "File Uploaded successfully.";
            }
            catch
            {
                ViewBag.Message = "Error while uploading the files.";
            }
            return RedirectToAction("LoggedIn");
        }

    


    }
}
