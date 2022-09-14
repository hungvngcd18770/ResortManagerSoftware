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
    public class ContractsController : Controller
    {
        private ResortManagerEntities db = new ResortManagerEntities();

        // GET: Contracts
        public ActionResult Index()
        {
            var contracts = db.Contracts.Include(c => c.Customer).Include(c => c.Employee).Include(c => c.Service);
            return View(contracts.ToList());
        }

        // GET: Contracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name");
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Name");
            return View();
        }

        // POST: Contracts/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate,Deposit,TotalMoney,EmployeeId,CustomerId,ServiceId")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Contracts.Add(contract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", contract.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", contract.EmployeeId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Name", contract.ServiceId);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", contract.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", contract.EmployeeId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Name", contract.ServiceId);
            return View(contract);
        }

        // POST: Contracts/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate,Deposit,TotalMoney,EmployeeId,CustomerId,ServiceId")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", contract.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", contract.EmployeeId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Name", contract.ServiceId);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract contract = db.Contracts.Find(id);
            db.Contracts.Remove(contract);
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
