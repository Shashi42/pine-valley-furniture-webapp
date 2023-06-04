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
    public class OrderLinesController : Controller
    {
        private S3G2PVFEntities db = new S3G2PVFEntities();

        // GET: OrderLines
        public ActionResult Index()
        {
            var orderLine = db.OrderLine.Include(o => o.Order).Include(o => o.Product);
            return View(orderLine.ToList());
        }

        // GET: OrderLines/Details/5
        public ActionResult Details(string productID, string orderID)
        {
            if (productID == null || orderID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderLine = db.OrderLine.Find(productID, orderID);
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            return View(orderLine);
        }

        // GET: OrderLines/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Order, "OrderID", "CustomerID");
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Description");
            return View();
        }

        // POST: OrderLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,OrderID,OrderedQuantity")] OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                db.OrderLine.Add(orderLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Order, "OrderID", "CustomerID", orderLine.OrderID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Description", orderLine.ProductID);
            return View(orderLine);
        }

        // GET: OrderLines/Edit/5
        public ActionResult Edit(string productID, string orderID)
        {
            if (productID == null || orderID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderLine = db.OrderLine.Find(productID, orderID);
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Order, "OrderID", "CustomerID", orderLine.OrderID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Description", orderLine.ProductID);
            return View(orderLine);
        }

        // POST: OrderLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,OrderID,OrderedQuantity")] OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Order, "OrderID", "CustomerID", orderLine.OrderID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Description", orderLine.ProductID);
            return View(orderLine);
        }

        // GET: OrderLines/Delete/5
        public ActionResult Delete(string productID, string orderID)
        {
            if (productID == null || orderID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderLine = db.OrderLine.Find(productID, orderID);
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            return View(orderLine);
        }

        // POST: OrderLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string productID, string orderID)
        {
            OrderLine orderLine = db.OrderLine.Find(productID, orderID);
            db.OrderLine.Remove(orderLine);
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
