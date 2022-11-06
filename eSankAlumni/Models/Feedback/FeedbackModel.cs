using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSankAlumni.Data;

namespace eSankAlumni.Models
{
    public class FeedbackModel
    {
        public int FeedbackId { get; set; }
        public string StudentName { get; set; }
        public int eSankalpId { get; set; }
        public int LectureId { get; set; }
        public int QueId { get; set; }
        public string Rating { get; set; }
        public System.DateTime FeedbackDate { get; set; }

        public string SaveFeedback(FeedbackModel model)
        {
            string msg = "save Feedback details";
            eSankAlumniEntities db = new eSankAlumniEntities();
            var saveFeedback = new tblFeedback()
            {


                StudentName = model.StudentName,
                eSankalpId = model.eSankalpId,
                LectureId = model.LectureId,
                QueId = model.QueId,
                Rating = model.Rating,
                FeedbackDate = model.FeedbackDate,

            };

            db.tblFeedbacks.Add(saveFeedback);
            db.SaveChanges();
            return msg;
        }

        public List<FeedbackModel> GetFeedbackList()
        {
            eSankAlumniEntities Db = new eSankAlumniEntities();
            List<FeedbackModel> lstAddFeedback = new List<FeedbackModel>();
            var AddFeedbackList = Db.tblFeedbacks.ToList();
            if (AddFeedbackList != null)
            {
                foreach (var Feedback in AddFeedbackList)
                {
                    lstAddFeedback.Add(new FeedbackModel()
                    {
                        FeedbackId = Feedback.FeedbackId,
                        StudentName = Feedback.StudentName,
                        eSankalpId = Feedback.eSankalpId,
                        LectureId = Feedback.LectureId,
                        QueId = Feedback.QueId,
                        Rating = Feedback.Rating,
                        FeedbackDate = Feedback.FeedbackDate
                       
                    });
                }
            }
            return lstAddFeedback;
        }
    }
}






