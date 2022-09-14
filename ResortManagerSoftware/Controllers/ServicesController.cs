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
    public class ServicesController : Controller
    {
        private ResortManagerEntities db = new ResortManagerEntities();

        // GET: Services
        public ActionResult Index()
        {
            var services = db.Services.Include(s => s.Ren_Type).Include(s => s.Service_type);
            return View(services.ToList());
        }

        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            ViewBag.RentypeId = new SelectList(db.Ren_Type, "RentypeId", "RenName");
            ViewBag.TypeId = new SelectList(db.Service_type, "TypeId", "Name");
            return View();
        }

        // POST: Services/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceId,Name,Are,DoubleS,SerciceMaxPeople,TypeId,RentypeId,StandRoom,DescriptionOtherConvenience,PoolArea")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RentypeId = new SelectList(db.Ren_Type, "RentypeId", "RenName", service.RentypeId);
            ViewBag.TypeId = new SelectList(db.Service_type, "TypeId", "Name", service.TypeId);
            return View(service);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.RentypeId = new SelectList(db.Ren_Type, "RentypeId", "RenName", service.RentypeId);
            ViewBag.TypeId = new SelectList(db.Service_type, "TypeId", "Name", service.TypeId);
            return View(service);
        }

        // POST: Services/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceId,Name,Are,DoubleS,SerciceMaxPeople,TypeId,RentypeId,StandRoom,DescriptionOtherConvenience,PoolArea")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RentypeId = new SelectList(db.Ren_Type, "RentypeId", "RenName", service.RentypeId);
            ViewBag.TypeId = new SelectList(db.Service_type, "TypeId", "Name", service.TypeId);
            return View(service);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
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
