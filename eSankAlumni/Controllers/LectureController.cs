using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSankAlumni.Models;
using System.IO;
using eSankAlumni.Data;

namespace eSankAlumni.Controllers
{
    public class LectureController : Controller
    {
        public eSankAlumniEntities db = new eSankAlumniEntities();
        // GET: Lecture
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult LectureList()
        {
            return View(db.tblLectures.ToList());
        }



        public ActionResult SaveLecture(LectureModel model)
        {

            try
            {
                HttpPostedFileBase fb1 = null;
                HttpPostedFileBase fb2 = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    if (i == 0)
                    {
                        fb1 = Request.Files[0];
                    }
                    if (i == 1)
                    {
                        fb2 = Request.Files[1];
                    }
                }
                return Json(new { Message = (new LectureModel().SaveLecture(fb1, fb2, model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetLectureList()

        {
            try

            {
                return Json(new { model = new LectureModel().GetLectureList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
