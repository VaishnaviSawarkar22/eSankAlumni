using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSankAlumni.Models;
 

namespace eSankAlumni.Controllers
{
    public class FeedbackQuestController : Controller
    {
        // GET: FeedbackQuest
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminIndex()
        {
            return View();
        }

        public ActionResult SaveFeedbackQuest(FeedbackQuestModel model)
        {

            try
            {
                return Json(new { Message = (new FeedbackQuestModel().SaveFeedbackQuest(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetFeedbackQuest()
        {
            try
            {
                return Json(new { model = (new FeedbackQuestModel().GetFeedbackQuest()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
    
