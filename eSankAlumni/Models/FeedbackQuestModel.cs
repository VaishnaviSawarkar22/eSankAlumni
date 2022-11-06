using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSankAlumni.Data;

namespace eSankAlumni.Models
{
    public class FeedbackQuestModel
    {
        public int Que { get; set; }
        public string Question { get; set; }

        public string SaveFeedbackQuest(FeedbackQuestModel model)
        {
            string msg = "";
            eSankAlumniEntities db = new eSankAlumniEntities();
            var saveFeedbackQuest = new tblFeedbackQuest()
            {
                Question = model.Question
            };
            db.tblFeedbackQuests.Add(saveFeedbackQuest);
            db.SaveChanges();
            return msg;
        }

        public List<FeedbackQuestModel> GetFeedbackQuest()
        {
            eSankAlumniEntities db = new eSankAlumniEntities();
            List<FeedbackQuestModel> lstFeedbackQuest = new List<FeedbackQuestModel>();
            var feedbackQuest = db.tblFeedbackQuests.ToList();
            if (feedbackQuest != null)
            {
                foreach (var FeedbackQuest in feedbackQuest)
                {
                    lstFeedbackQuest.Add(new FeedbackQuestModel()

                    {
                        Que = FeedbackQuest.Que,
                        Question = FeedbackQuest.Question,

                    });
                }

            }
            return lstFeedbackQuest;
        }
    }
}


