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
    public class Service_typeController : Controller
    {
        private ResortManagerEntities db = new ResortManagerEntities();

        // GET: Service_type
        public ActionResult Index()
        {
            return View(db.Service_type.ToList());
        }

        // GET: Service_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_type service_type = db.Service_type.Find(id);
            if (service_type == null)
            {
                return HttpNotFound();
            }
            return View(service_type);
        }

        // GET: Service_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service_type/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeId,Name")] Service_type service_type)
        {
            if (ModelState.IsValid)
            {
                db.Service_type.Add(service_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service_type);
        }

        // GET: Service_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_type service_type = db.Service_type.Find(id);
            if (service_type == null)
            {
                return HttpNotFound();
            }
            return View(service_type);
        }

        // POST: Service_type/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeId,Name")] Service_type service_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service_type);
        }

        // GET: Service_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_type service_type = db.Service_type.Find(id);
            if (service_type == null)
            {
                return HttpNotFound();
            }
            return View(service_type);
        }

        // POST: Service_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service_type service_type = db.Service_type.Find(id);
            db.Service_type.Remove(service_type);
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
