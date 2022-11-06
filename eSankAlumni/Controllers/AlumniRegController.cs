using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSankAlumni.Models;

namespace eSankAlumni.Controllers
{
    public class AlumniRegController : Controller
    {
        // GET: AluminiReg
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegList()
        {
            return View();
        }

        public ActionResult SaveAlumniReg(AlumniRegModel model)
        {

            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];
                }
                return Json(new { Message = (new AlumniRegModel().SaveAlumniReg(fb, model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult GetAlumniReg()
        {
            try
            {
                return Json(new { model = (new AlumniRegModel().GetAlumniReg()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}