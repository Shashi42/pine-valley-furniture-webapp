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
    public class ProductionsController : Controller
    {
        private S3G2PVFEntities db = new S3G2PVFEntities();

        // GET: Productions
        public ActionResult Index()
        {
            var production = db.Production.Include(p => p.Product).Include(p => p.Work_center);
            return View(production.ToList());
        }

        // GET: Productions/Details/5
        public ActionResult Details(string productID, string workcenterID)
        {
            if (productID == null || workcenterID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production production = db.Production.Find(productID, workcenterID);
            if (production == null)
            {
                return HttpNotFound();
            }
            return View(production);
        }

        // GET: Productions/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Description");
            ViewBag.WorkcenterID = new SelectList(db.Work_center, "WorkcenterID", "WorkcenterName");
            return View();
        }

        // POST: Productions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,WorkcenterID,Quantity")] Production production)
        {
            if (ModelState.IsValid)
            {
                db.Production.Add(production);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Description", production.ProductID);
            ViewBag.WorkcenterID = new SelectList(db.Work_center, "WorkcenterID", "WorkcenterName", production.WorkcenterID);
            return View(production);
        }

        // GET: Productions/Edit/5
        public ActionResult Edit(string productID, string workcenterID)
        {
            if (productID == null || workcenterID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production production = db.Production.Find(productID, workcenterID);
            if (production == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Description", production.ProductID);
            ViewBag.WorkcenterID = new SelectList(db.Work_center, "WorkcenterID", "WorkcenterName", production.WorkcenterID);
            return View(production);
        }

        // POST: Productions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,WorkcenterID,Quantity")] Production production)
        {
            if (ModelState.IsValid)
            {
                db.Entry(production).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Description", production.ProductID);
            ViewBag.WorkcenterID = new SelectList(db.Work_center, "WorkcenterID", "WorkcenterName", production.WorkcenterID);
            return View(production);
        }

        // GET: Productions/Delete/5
        public ActionResult Delete(string productID, string workcenterID)
        {
            if (productID == null || workcenterID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production production = db.Production.Find(productID, workcenterID);
            if (production == null)
            {
                return HttpNotFound();
            }
            return View(production);
        }

        // POST: Productions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string productID, string workcenterID)
        {
            Production production = db.Production.Find(productID, workcenterID);
            db.Production.Remove(production);
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
