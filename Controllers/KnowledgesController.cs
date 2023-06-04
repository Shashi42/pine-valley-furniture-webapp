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
    public class KnowledgesController : Controller
    {
        private S3G2PVFEntities db = new S3G2PVFEntities();

        // GET: Knowledges
        public ActionResult Index()
        {
            var knowledge = db.Knowledge.Include(k => k.Employee).Include(k => k.Skill);
            return View(knowledge.ToList());
        }

        // GET: Knowledges/Details/5
        public ActionResult Details(string employeeID, string skillID)
        {
            if (employeeID == null || skillID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knowledge knowledge = db.Knowledge.Find(employeeID, skillID);
            if (knowledge == null)
            {
                return HttpNotFound();
            }
            return View(knowledge);
        }

        // GET: Knowledges/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "NAME");
            ViewBag.SkillID = new SelectList(db.Skill, "SkillID", "Description");
            return View();
        }

        // POST: Knowledges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,SkillID,Rating")] Knowledge knowledge)
        {
            if (ModelState.IsValid)
            {
                db.Knowledge.Add(knowledge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "NAME", knowledge.EmployeeID);
            ViewBag.SkillID = new SelectList(db.Skill, "SkillID", "Description", knowledge.SkillID);
            return View(knowledge);
        }

        // GET: Knowledges/Edit/5
        public ActionResult Edit(string employeeID, string skillID)
        {
            if (employeeID == null || skillID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knowledge knowledge = db.Knowledge.Find(employeeID, skillID);
            if (knowledge == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "NAME", knowledge.EmployeeID);
            ViewBag.SkillID = new SelectList(db.Skill, "SkillID", "Description", knowledge.SkillID);
            return View(knowledge);
        }

        // POST: Knowledges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,SkillID,Rating")] Knowledge knowledge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knowledge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "NAME", knowledge.EmployeeID);
            ViewBag.SkillID = new SelectList(db.Skill, "SkillID", "Description", knowledge.SkillID);
            return View(knowledge);
        }

        // GET: Knowledges/Delete/5
        public ActionResult Delete(string employeeID, string skillID)
        {
            if (employeeID == null || skillID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knowledge knowledge = db.Knowledge.Find(employeeID, skillID);
            if (knowledge == null)
            {
                return HttpNotFound();
            }
            return View(knowledge);
        }

        // POST: Knowledges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string employeeID, string skillID)
        {
            Knowledge knowledge = db.Knowledge.Find(employeeID, skillID);
            db.Knowledge.Remove(knowledge);
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
