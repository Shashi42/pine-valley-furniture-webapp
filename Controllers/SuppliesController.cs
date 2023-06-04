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
    public class SuppliesController : Controller
    {
        private S3G2PVFEntities db = new S3G2PVFEntities();

        // GET: Supplies
        public ActionResult Index()
        {
            var supplies = db.Supplies.Include(s => s.Raw_Materials).Include(s => s.Vendor);
            return View(supplies.ToList());
        }

        // GET: Supplies/Details/5
        public ActionResult Details(int? vendorID, string materialID)
        {
            if (vendorID == null || materialID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplies supplies = db.Supplies.Find(vendorID, materialID);
            if (supplies == null)
            {
                return HttpNotFound();
            }
            return View(supplies);
        }

        // GET: Supplies/Create
        public ActionResult Create()
        {
            ViewBag.MaterialID = new SelectList(db.Raw_Materials, "MaterialID", "MaterialName");
            ViewBag.VendorID = new SelectList(db.Vendor, "VendorID", "VendorName");
            return View();
        }

        // POST: Supplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorID,MaterialID,SupplyUnitPrice")] Supplies supplies)
        {
            if (ModelState.IsValid)
            {
                db.Supplies.Add(supplies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaterialID = new SelectList(db.Raw_Materials, "MaterialID", "MaterialName", supplies.MaterialID);
            ViewBag.VendorID = new SelectList(db.Vendor, "VendorID", "VendorName", supplies.VendorID);
            return View(supplies);
        }

        // GET: Supplies/Edit/5
        public ActionResult Edit(int? vendorID, string materialID)
        {
            if (vendorID == null || materialID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplies supplies = db.Supplies.Find(vendorID, materialID);
            if (supplies == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaterialID = new SelectList(db.Raw_Materials, "MaterialID", "MaterialName", supplies.MaterialID);
            ViewBag.VendorID = new SelectList(db.Vendor, "VendorID", "VendorName", supplies.VendorID);
            return View(supplies);
        }

        // POST: Supplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorID,MaterialID,SupplyUnitPrice")] Supplies supplies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaterialID = new SelectList(db.Raw_Materials, "MaterialID", "MaterialName", supplies.MaterialID);
            ViewBag.VendorID = new SelectList(db.Vendor, "VendorID", "VendorName", supplies.VendorID);
            return View(supplies);
        }

        // GET: Supplies/Delete/5
        public ActionResult Delete(int? vendorID, string materialID)
        {
            if (vendorID == null || materialID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplies supplies = db.Supplies.Find(vendorID, materialID);
            if (supplies == null)
            {
                return HttpNotFound();
            }
            return View(supplies);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? vendorID, string materialID)
        {
            Supplies supplies = db.Supplies.Find(vendorID, materialID);
            db.Supplies.Remove(supplies);
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
