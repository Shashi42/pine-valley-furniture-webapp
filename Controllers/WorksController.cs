using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S3G2_PVFAPP.Models;

namespace S3G2_PVFAPP.Controllers
{
    public class WorksController : Controller
    {
        private S3G2PVFEntities db = new S3G2PVFEntities();

        // GET: Works
        public ActionResult Index()
        {
            var work = db.Work.Include(w => w.Employee).Include(w => w.Work_center);
            return View(work.ToList());
        }

        // GET: Works/Details/5
        public ActionResult Details(string employeeID, string workcenterID)
        {
            if (employeeID == null || workcenterID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Work.Find(employeeID, workcenterID);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        // GET: Works/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "NAME");
            ViewBag.WorkcenterID = new SelectList(db.Work_center, "WorkcenterID", "WorkcenterName");
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,WorkcenterID,WorkDescription")] Work work)
        {
            if (ModelState.IsValid)
            {
                db.Work.Add(work);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "NAME", work.EmployeeID);
            ViewBag.WorkcenterID = new SelectList(db.Work_center, "WorkcenterID", "WorkcenterName", work.WorkcenterID);
            return View(work);
        }

        // GET: Works/Edit/5
        public ActionResult Edit(string employeeID, string workcenterID)
        {
            if (employeeID == null || workcenterID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Work.Find(employeeID, workcenterID);
            if (work == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "NAME", work.EmployeeID);
            ViewBag.WorkcenterID = new SelectList(db.Work_center, "WorkcenterID", "WorkcenterName", work.WorkcenterID);
            return View(work);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,WorkcenterID,WorkDescription")] Work work)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "NAME", work.EmployeeID);
            ViewBag.WorkcenterID = new SelectList(db.Work_center, "WorkcenterID", "WorkcenterName", work.WorkcenterID);
            return View(work);
        }

        // GET: Works/Delete/5
        public ActionResult Delete(string employeeID, string workcenterID)
        {
            if (employeeID == null || workcenterID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Work.Find(employeeID, workcenterID);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string employeeID, string workcenterID)
        {
            Work work = db.Work.Find(employeeID, workcenterID);
            db.Work.Remove(work);
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
