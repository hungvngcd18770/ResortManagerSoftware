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
    public class ContractDetailsController : Controller
    {
        private ResortManagerEntities db = new ResortManagerEntities();

        // GET: ContractDetails
        public ActionResult Index()
        {
            var contractDetails = db.ContractDetails.Include(c => c.AttachService).Include(c => c.Contract);
            return View(contractDetails.ToList());
        }

        // GET: ContractDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractDetail contractDetail = db.ContractDetails.Find(id);
            if (contractDetail == null)
            {
                return HttpNotFound();
            }
            return View(contractDetail);
        }

        // GET: ContractDetails/Create
        public ActionResult Create()
        {
            ViewBag.AttachServiceId = new SelectList(db.AttachServices, "AttachServiceId", "Name");
            ViewBag.ContractId = new SelectList(db.Contracts, "Id", "Id");
            return View();
        }

        // POST: ContractDetails/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContractDetailId,ContractId,AttachServiceId,Quantity")] ContractDetail contractDetail)
        {
            if (ModelState.IsValid)
            {
                db.ContractDetails.Add(contractDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttachServiceId = new SelectList(db.AttachServices, "AttachServiceId", "Name", contractDetail.AttachServiceId);
            ViewBag.ContractId = new SelectList(db.Contracts, "Id", "Id", contractDetail.ContractId);
            return View(contractDetail);
        }

        // GET: ContractDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractDetail contractDetail = db.ContractDetails.Find(id);
            if (contractDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttachServiceId = new SelectList(db.AttachServices, "AttachServiceId", "Name", contractDetail.AttachServiceId);
            ViewBag.ContractId = new SelectList(db.Contracts, "Id", "Id", contractDetail.ContractId);
            return View(contractDetail);
        }

        // POST: ContractDetails/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContractDetailId,ContractId,AttachServiceId,Quantity")] ContractDetail contractDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contractDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttachServiceId = new SelectList(db.AttachServices, "AttachServiceId", "Name", contractDetail.AttachServiceId);
            ViewBag.ContractId = new SelectList(db.Contracts, "Id", "Id", contractDetail.ContractId);
            return View(contractDetail);
        }

        // GET: ContractDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractDetail contractDetail = db.ContractDetails.Find(id);
            if (contractDetail == null)
            {
                return HttpNotFound();
            }
            return View(contractDetail);
        }

        // POST: ContractDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContractDetail contractDetail = db.ContractDetails.Find(id);
            db.ContractDetails.Remove(contractDetail);
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
