using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionIA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Footer()
        {
            return View();
        }
        public ActionResult bootstrap()
        {
            return View();
        }

        public ActionResult men()
        {
            return View();
        }

        public ActionResult women()
        {
            return View();
        }

        
        public ActionResult shops()
        {
            return View();
        }
        public ActionResult factory()
        {
            return View();
        }

        public ActionResult beauty()
        {
            return View();
        }
    }
}