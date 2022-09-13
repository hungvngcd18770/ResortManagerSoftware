using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResortManagerSoftware.Models;

namespace ResortManagerSoftware.Controllers
{
    public class Education_DegreeController : Controller
    {
        private ResortManagerEntities db = new ResortManagerEntities();

        // GET: Education_Degree
        public ActionResult Index()
        {
            return View(db.Education_Degree.ToList());
        }

        // GET: Education_Degree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education_Degree education_Degree = db.Education_Degree.Find(id);
            if (education_Degree == null)
            {
                return HttpNotFound();
            }
            return View(education_Degree);
        }

        // GET: Education_Degree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Education_Degree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EdId,EdName")] Education_Degree education_Degree)
        {
            if (ModelState.IsValid)
            {
                db.Education_Degree.Add(education_Degree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(education_Degree);
        }

        // GET: Education_Degree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education_Degree education_Degree = db.Education_Degree.Find(id);
            if (education_Degree == null)
            {
                return HttpNotFound();
            }
            return View(education_Degree);
        }

        // POST: Education_Degree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EdId,EdName")] Education_Degree education_Degree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(education_Degree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(education_Degree);
        }

        // GET: Education_Degree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education_Degree education_Degree = db.Education_Degree.Find(id);
            if (education_Degree == null)
            {
                return HttpNotFound();
            }
            return View(education_Degree);
        }

        // POST: Education_Degree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Education_Degree education_Degree = db.Education_Degree.Find(id);
            db.Education_Degree.Remove(education_Degree);
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
