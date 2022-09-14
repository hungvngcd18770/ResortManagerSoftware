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
    public class EmployeesController : Controller
    {
        private ResortManagerEntities db = new ResortManagerEntities();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Division).Include(e => e.Education_Degree).Include(e => e.Position);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "Name");
            ViewBag.EdId = new SelectList(db.Education_Degree, "EdId", "EdName");
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Name");
            return View();
        }

        // POST: Employees/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Birthday,IdCard,Salary,Phone,Email,Address,PositionId,EdId,DivisionId,UserName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "Name", employee.DivisionId);
            ViewBag.EdId = new SelectList(db.Education_Degree, "EdId", "EdName", employee.EdId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Name", employee.PositionId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "Name", employee.DivisionId);
            ViewBag.EdId = new SelectList(db.Education_Degree, "EdId", "EdName", employee.EdId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Name", employee.PositionId);
            return View(employee);
        }

        // POST: Employees/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,Name,Birthday,IdCard,Salary,Phone,Email,Address,PositionId,EdId,DivisionId,UserName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "Name", employee.DivisionId);
            ViewBag.EdId = new SelectList(db.Education_Degree, "EdId", "EdName", employee.EdId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Name", employee.PositionId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
