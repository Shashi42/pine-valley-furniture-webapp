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
    public class BusinessesController : Controller
    {
        private S3G2PVFEntities db = new S3G2PVFEntities();

        // GET: Businesses
        public ActionResult Index()
        {
            var business = db.Business.Include(b => b.Customer).Include(b => b.Territory);
            return View(business.ToList());
        }

        // GET: Businesses/Details/5
        public ActionResult Details(string customerID, int? territoryID)
        {
            if (customerID == null || territoryID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business business = db.Business.Find(customerID, territoryID);
            if (business == null)
            {
                return HttpNotFound();
            }
            return View(business);
        }

        // GET: Businesses/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "Name");
            ViewBag.TerritoryID = new SelectList(db.Territory, "TerritoryID", "TerritoryName");
            return View();
        }

        // POST: Businesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,TerritoryID,BusinessValue")] Business business)
        {
            if (ModelState.IsValid)
            {
                db.Business.Add(business);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "Name", business.CustomerID);
            ViewBag.TerritoryID = new SelectList(db.Territory, "TerritoryID", "TerritoryName", business.TerritoryID);
            return View(business);
        }

        // GET: Businesses/Edit/5
        public ActionResult Edit(string customerID, int? territoryID)
        {
            if (customerID == null || territoryID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business business = db.Business.Find(customerID, territoryID);
            if (business == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "Name", business.CustomerID);
            ViewBag.TerritoryID = new SelectList(db.Territory, "TerritoryID", "TerritoryName", business.TerritoryID);
            return View(business);
        }

        // POST: Businesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,TerritoryID,BusinessValue")] Business business)
        {
            if (ModelState.IsValid)
            {
                db.Entry(business).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "Name", business.CustomerID);
            ViewBag.TerritoryID = new SelectList(db.Territory, "TerritoryID", "TerritoryName", business.TerritoryID);
            return View(business);
        }

        // GET: Businesses/Delete/5
        public ActionResult Delete(string customerID, int? territoryID)
        {
            if (customerID == null || territoryID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business business = db.Business.Find(customerID, territoryID);
            if (business == null)
            {
                return HttpNotFound();
            }
            return View(business);
        }

        // POST: Businesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string customerID, int? territoryID)
        {
            Business business = db.Business.Find(customerID, territoryID);
            db.Business.Remove(business);
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
