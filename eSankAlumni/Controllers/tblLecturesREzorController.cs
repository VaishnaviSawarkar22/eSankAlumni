using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eSankAlumni.Data;

namespace eSankAlumni.Controllers
{
    public class tblLecturesREzorController : Controller
    {
        private eSankAlumniEntities db = new eSankAlumniEntities();

        // GET: tblLecturesREzor
        public ActionResult Index()
        {
            return View(db.tblLectures.ToList());
        }

        // GET: tblLecturesREzor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLecture tblLecture = db.tblLectures.Find(id);
            if (tblLecture == null)
            {
                return HttpNotFound();
            }
            return View(tblLecture);
        }

        // GET: tblLecturesREzor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblLecturesREzor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LectureId,LectureDate,TimeSlot,Topic,Details,LectureById,LecturePhoto1,LecturePhoto2,NotesDocument,TestDocument,IsActive")] tblLecture tblLecture)
        {
            if (ModelState.IsValid)
            {
                db.tblLectures.Add(tblLecture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblLecture);
        }

        // GET: tblLecturesREzor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLecture tblLecture = db.tblLectures.Find(id);
            if (tblLecture == null)
            {
                return HttpNotFound();
            }
            return View(tblLecture);
        }

        // POST: tblLecturesREzor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LectureId,LectureDate,TimeSlot,Topic,Details,LectureById,LecturePhoto1,LecturePhoto2,NotesDocument,TestDocument,IsActive")] tblLecture tblLecture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLecture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLecture);
        }

        // GET: tblLecturesREzor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLecture tblLecture = db.tblLectures.Find(id);
            if (tblLecture == null)
            {
                return HttpNotFound();
            }
            return View(tblLecture);
        }

        // POST: tblLecturesREzor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLecture tblLecture = db.tblLectures.Find(id);
            db.tblLectures.Remove(tblLecture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
