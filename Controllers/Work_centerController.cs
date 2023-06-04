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
    public class Work_centerController : Controller
    {
        private S3G2PVFEntities db = new S3G2PVFEntities();

        // GET: Work_center
        public ActionResult Index()
        {
            return View(db.Work_center.ToList());
        }

        // GET: Work_center/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_center work_center = db.Work_center.Find(id);
            if (work_center == null)
            {
                return HttpNotFound();
            }
            return View(work_center);
        }

        // GET: Work_center/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Work_center/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkcenterID,WorkcenterName")] Work_center work_center)
        {
            if (ModelState.IsValid)
            {
                db.Work_center.Add(work_center);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(work_center);
        }

        // GET: Work_center/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_center work_center = db.Work_center.Find(id);
            if (work_center == null)
            {
                return HttpNotFound();
            }
            return View(work_center);
        }

        // POST: Work_center/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkcenterID,WorkcenterName")] Work_center work_center)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_center).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work_center);
        }

        // GET: Work_center/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_center work_center = db.Work_center.Find(id);
            if (work_center == null)
            {
                return HttpNotFound();
            }
            return View(work_center);
        }

        // POST: Work_center/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Work_center work_center = db.Work_center.Find(id);
            db.Work_center.Remove(work_center);
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
