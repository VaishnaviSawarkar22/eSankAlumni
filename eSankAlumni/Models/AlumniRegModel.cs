using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSankAlumni.Data;
using System.IO;

namespace eSankAlumni.Models
{
    public class AlumniRegModel
    {
        public int AlumniId { get; set; }
        public string AlumniName { get; set; }
        public string eSankalpId { get; set; }
        public string PassoutYr { get; set; }
        public string DOB { get; set; }
        public string TotalExp { get; set; }
        public string CurrentCompany { get; set; }
        public string CTC { get; set; }
        public string Photo { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string CollegeName { get; set; }
        public string Education { get; set; }
        public string IsActive { get; set; }

        public string SaveAlumniReg(HttpPostedFileBase fb, AlumniRegModel model)
        {
            string msg = "";
            AlumniRegModel l = new AlumniRegModel();
            eSankAlumniEntities db = new eSankAlumniEntities();

            string filePath = "";
            string fileName = "";
            string sysFileName = "";

            if (fb != null && fb.ContentLength > 0)
            {

                filePath = HttpContext.Current.Server.MapPath("~/Content/img/");
                DirectoryInfo di = new DirectoryInfo(filePath);
                if (!di.Exists)
                {
                    di.Create();
                }
                fileName = fb.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                fb.SaveAs(filePath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("~/Content/img/") + "/" + sysFileName;

                }
            }
            var SaveAlumniReg = new tblAlumniReg()
            {
               
                AlumniName = model.AlumniName,
                eSankalpId = model.eSankalpId,
                PassoutYr = model.PassoutYr,
                DOB = model.DOB,
                TotalExp = model.TotalExp,
                CurrentCompany = model.CurrentCompany,
                CTC = model.CTC,
                Photo = sysFileName,
                City = model.City,
                Address = model.Address,
                CollegeName = model.CollegeName,
                Education = model.Education,
                IsActive = model.IsActive,
            };
            db.tblAlumniRegs.Add(SaveAlumniReg);
            db.SaveChanges();
            return msg;
        }

        public List<AlumniRegModel> GetAlumniReg()
        {
            eSankAlumniEntities db = new eSankAlumniEntities();
            List<AlumniRegModel> lstalumniReg = new List<AlumniRegModel>();
            var alumniRegs = db.tblAlumniRegs.ToList();
            if (alumniRegs != null)
            {
                foreach (var alumniReg in alumniRegs)
                {
                    lstalumniReg.Add(new AlumniRegModel()
                    {
                        AlumniId = alumniReg.AlumniId,
                        AlumniName = alumniReg.AlumniName,
                        eSankalpId = alumniReg.eSankalpId,
                        PassoutYr = alumniReg.PassoutYr,
                        DOB = alumniReg.DOB,
                        TotalExp = alumniReg.TotalExp,
                        CurrentCompany = alumniReg.CurrentCompany,
                        CTC = alumniReg.CTC,
                        Photo = alumniReg.Photo,
                        City = alumniReg.City,
                        Address = alumniReg.Address,
                        CollegeName = alumniReg.CollegeName,
                        Education = alumniReg.Education,
                        IsActive = alumniReg.IsActive,
                    });
                }
            }
            return lstalumniReg;
        }
    }
}
    