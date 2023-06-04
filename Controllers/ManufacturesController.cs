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
    public class ManufacturesController : Controller
    {
        private S3G2PVFEntities db = new S3G2PVFEntities();

        // GET: Manufactures
        public ActionResult Index()
        {
            var manufactures = db.Manufactures.Include(m => m.Product).Include(m => m.Raw_Materials);
            return View(manufactures.ToList());
        }

        // GET: Manufactures/Details/5
        public ActionResult Details(string productID, string materialID)
        {
            if (productID == null || materialID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufactures manufactures = db.Manufactures.Find(productID, materialID);
            if (manufactures == null)
            {
                return HttpNotFound();
            }
            return View(manufactures);
        }

        // GET: Manufactures/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Description");
            ViewBag.MaterialID = new SelectList(db.Raw_Materials, "MaterialID", "MaterialName");
            return View();
        }

        // POST: Manufactures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,MaterialID,Quantity")] Manufactures manufactures)
        {
            if (ModelState.IsValid)
            {
                db.Manufactures.Add(manufactures);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Description", manufactures.ProductID);
            ViewBag.MaterialID = new SelectList(db.Raw_Materials, "MaterialID", "MaterialName", manufactures.MaterialID);
            return View(manufactures);
        }

        // GET: Manufactures/Edit/5
        public ActionResult Edit(string productID, string materialID)
        {
            if (productID == null || materialID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufactures manufactures = db.Manufactures.Find(productID, materialID);
            if (manufactures == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Description", manufactures.ProductID);
            ViewBag.MaterialID = new SelectList(db.Raw_Materials, "MaterialID", "MaterialName", manufactures.MaterialID);
            return View(manufactures);
        }

        // POST: Manufactures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,MaterialID,Quantity")] Manufactures manufactures)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manufactures).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Description", manufactures.ProductID);
            ViewBag.MaterialID = new SelectList(db.Raw_Materials, "MaterialID", "MaterialName", manufactures.MaterialID);
            return View(manufactures);
        }

        // GET: Manufactures/Delete/5
        public ActionResult Delete(string productID, string materialID)
        {
            if (productID == null || materialID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufactures manufactures = db.Manufactures.Find(productID, materialID);
            if (manufactures == null)
            {
                return HttpNotFound();
            }
            return View(manufactures);
        }

        // POST: Manufactures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string productID, string materialID)
        {
            Manufactures manufactures = db.Manufactures.Find(productID, materialID);
            db.Manufactures.Remove(manufactures);
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
