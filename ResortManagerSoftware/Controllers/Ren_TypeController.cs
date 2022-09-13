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
    public class Ren_TypeController : Controller
    {
        private ResortManagerEntities db = new ResortManagerEntities();

        // GET: Ren_Type
        public ActionResult Index()
        {
            return View(db.Ren_Type.ToList());
        }

        // GET: Ren_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ren_Type ren_Type = db.Ren_Type.Find(id);
            if (ren_Type == null)
            {
                return HttpNotFound();
            }
            return View(ren_Type);
        }

        // GET: Ren_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ren_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentypeId,RenName,RenCost")] Ren_Type ren_Type)
        {
            if (ModelState.IsValid)
            {
                db.Ren_Type.Add(ren_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ren_Type);
        }

        // GET: Ren_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ren_Type ren_Type = db.Ren_Type.Find(id);
            if (ren_Type == null)
            {
                return HttpNotFound();
            }
            return View(ren_Type);
        }

        // POST: Ren_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentypeId,RenName,RenCost")] Ren_Type ren_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ren_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ren_Type);
        }

        // GET: Ren_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ren_Type ren_Type = db.Ren_Type.Find(id);
            if (ren_Type == null)
            {
                return HttpNotFound();
            }
            return View(ren_Type);
        }

        // POST: Ren_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ren_Type ren_Type = db.Ren_Type.Find(id);
            db.Ren_Type.Remove(ren_Type);
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
