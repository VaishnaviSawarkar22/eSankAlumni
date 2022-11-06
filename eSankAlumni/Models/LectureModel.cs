using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSankAlumni.Data;
using System.IO;

namespace eSankAlumni.Models
{
    public class LectureModel
    {
        public int LectureId { get; set; }
        public string LectureDate { get; set; }
        public string TimeSlot { get; set; }
        public string Topic { get; set; }
        public string Details { get; set; }
        public string LectureById { get; set; }
        public string LecturePhoto1 { get; set; }
        public string LecturePhoto2 { get; set; }
        public string NotesDocument { get; set; }
        public string TestDocument { get; set; }
        public string IsActive { get; set; }

        public string SaveLecture(HttpPostedFileBase fb1, HttpPostedFileBase fb2, LectureModel model)
        {
            string msg = "";
            eSankAlumniEntities db = new eSankAlumniEntities();
            string filePath1 = "";
            string fileName1 = "";
            string sysFileName1 = "";
            //var getdata = db.tblProducts.Where(p => p.Id == model.Id).FirstOrDefault();
            if (fb1 != null && fb1.ContentLength > 0)
            {

                //filePath1 = HttpContext.Current.Server.MapPath("~/Content/img/");
                filePath1 = HttpContext.Current.Server.MapPath("~/Content/img/");
                DirectoryInfo di = new DirectoryInfo(filePath1);
                if (!di.Exists)
                {
                    di.Create();
                }
                fileName1 = fb1.FileName;
                sysFileName1 = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb1.FileName);
                fb1.SaveAs(filePath1 + "//" + sysFileName1);
                if (!string.IsNullOrWhiteSpace(fb1.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("~/Content/img/") + "/" + sysFileName1;

                }
            }

            string filePath2 = "";
            string fileName2 = "";
            string sysFileName2 = "";
            //var getdata = db.tblProducts.Where(p => p.Id == model.Id).FirstOrDefault();
            if (fb2 != null && fb2.ContentLength > 0)
            {

                //filePath2 = HttpContext.Current.Server.MapPath("~/Content/img/");
                filePath2 = HttpContext.Current.Server.MapPath("~/Content/img/");
                DirectoryInfo di = new DirectoryInfo(filePath2);
                if (!di.Exists)
                {
                    di.Create();
                }
                fileName2 = fb2.FileName;
                sysFileName2 = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb2.FileName);
                fb2.SaveAs(filePath2 + "//" + sysFileName2);
                if (!string.IsNullOrWhiteSpace(fb2.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("~/Content/img/") + "/" + sysFileName2;

                }
            }
            var saveLecture = new tblLecture()
            {
                LectureDate = model.LectureDate,
                TimeSlot = model.TimeSlot,
                Topic = model.Topic,
                Details = model.Details,
                LectureById = model.LectureById,
                LecturePhoto1 = sysFileName1,
                LecturePhoto2 = sysFileName2,
                NotesDocument = model.NotesDocument,
                TestDocument = model.TestDocument,
                IsActive = model.IsActive
            };
            db.tblLectures.Add(saveLecture);
            db.SaveChanges();
            return msg;
        }

        public List<LectureModel> GetLectureList()
        {
            eSankAlumniEntities Db = new eSankAlumniEntities();
            List<LectureModel> lstAddLecture = new List<LectureModel>();
            var AddLectureList = Db.tblLectures.ToList();
            if (AddLectureList != null)
            {
                foreach (var Lecture in AddLectureList)
                {
                    lstAddLecture.Add(new LectureModel()
                    {
                        LectureId = Lecture.LectureId,
                        LectureDate = Lecture.LectureDate,
                        TimeSlot = Lecture.TimeSlot,
                        Topic = Lecture.Topic,
                        Details = Lecture.Details,
                        LectureById = Lecture.LectureById,
                        LecturePhoto1 = Lecture.LecturePhoto1,
                        LecturePhoto2 = Lecture.LecturePhoto2,
                        NotesDocument = Lecture.NotesDocument,
                        TestDocument = Lecture.TestDocument,
                        IsActive = Lecture.IsActive,


                    });
                }
            }
            return lstAddLecture;
        }
    }
}