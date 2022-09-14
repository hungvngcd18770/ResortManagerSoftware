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
    public class CustomerTypesController : Controller
    {
        private ResortManagerEntities db = new ResortManagerEntities();

        // GET: CustomerTypes
        public ActionResult Index()
        {
            var customerTypes = db.CustomerTypes.Include(c => c.Customer);
            return View(customerTypes.ToList());
        }

        // GET: CustomerTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerType customerType = db.CustomerTypes.Find(id);
            if (customerType == null)
            {
                return HttpNotFound();
            }
            return View(customerType);
        }

        // GET: CustomerTypes/Create
        public ActionResult Create()
        {
            ViewBag.CustomerTypeId = new SelectList(db.Customers, "CustomerId", "Name");
            return View();
        }

        // POST: CustomerTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerTypeId,Name")] CustomerType customerType)
        {
            if (ModelState.IsValid)
            {
                db.CustomerTypes.Add(customerType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerTypeId = new SelectList(db.Customers, "CustomerId", "Name", customerType.CustomerTypeId);
            return View(customerType);
        }

        // GET: CustomerTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerType customerType = db.CustomerTypes.Find(id);
            if (customerType == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerTypeId = new SelectList(db.Customers, "CustomerId", "Name", customerType.CustomerTypeId);
            return View(customerType);
        }

        // POST: CustomerTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerTypeId,Name")] CustomerType customerType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerTypeId = new SelectList(db.Customers, "CustomerId", "Name", customerType.CustomerTypeId);
            return View(customerType);
        }

        // GET: CustomerTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerType customerType = db.CustomerTypes.Find(id);
            if (customerType == null)
            {
                return HttpNotFound();
            }
            return View(customerType);
        }

        // POST: CustomerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerType customerType = db.CustomerTypes.Find(id);
            db.CustomerTypes.Remove(customerType);
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
