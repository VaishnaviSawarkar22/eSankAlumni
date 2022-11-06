using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSankAlumni.Models;
using eSankAlumni.Data;

namespace eSankAlumni.Controllers
{
    public class FeedbackController : Controller
    {
        public eSankAlumniEntities db = new eSankAlumniEntities();
        // GET: Feedback
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FeedbackList1()
        {
            return View();
        }

        public ActionResult FeedbackList()
        {
            return View(db.tblFeedbacks.ToList());
        }




        public ActionResult SaveFeedback(FeedbackModel model)
        {
            try
            {
                return Json(new { message = (new FeedbackModel().SaveFeedback(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetFeedbackList()
        {
            try
            
            {
                return Json(new { model = new FeedbackModel().GetFeedbackList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}

    
    