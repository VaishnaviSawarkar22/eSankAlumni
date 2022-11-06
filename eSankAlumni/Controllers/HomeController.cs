using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSankAlumni.Data;


namespace eSankAlumni.Controllers
{
    public class HomeController : Controller
    {
        public eSankAlumniEntities db = new eSankAlumniEntities();
        public ActionResult Index()
        {
            return View(db.tblFeedbacks.ToList());
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AdminIndex()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}