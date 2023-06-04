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
    public class Raw_MaterialsController : Controller
    {
        private S3G2PVFEntities db = new S3G2PVFEntities();

        // GET: Raw_Materials
        public ActionResult Index()
        {
            return View(db.Raw_Materials.ToList());
        }

        // GET: Raw_Materials/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raw_Materials raw_Materials = db.Raw_Materials.Find(id);
            if (raw_Materials == null)
            {
                return HttpNotFound();
            }
            return View(raw_Materials);
        }

        // GET: Raw_Materials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Raw_Materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaterialID,MaterialName,Cost,UnitOfMeasure")] Raw_Materials raw_Materials)
        {
            if (ModelState.IsValid)
            {
                db.Raw_Materials.Add(raw_Materials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(raw_Materials);
        }

        // GET: Raw_Materials/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raw_Materials raw_Materials = db.Raw_Materials.Find(id);
            if (raw_Materials == null)
            {
                return HttpNotFound();
            }
            return View(raw_Materials);
        }

        // POST: Raw_Materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaterialID,MaterialName,Cost,UnitOfMeasure")] Raw_Materials raw_Materials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raw_Materials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raw_Materials);
        }

        // GET: Raw_Materials/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raw_Materials raw_Materials = db.Raw_Materials.Find(id);
            if (raw_Materials == null)
            {
                return HttpNotFound();
            }
            return View(raw_Materials);
        }

        // POST: Raw_Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Raw_Materials raw_Materials = db.Raw_Materials.Find(id);
            db.Raw_Materials.Remove(raw_Materials);
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
