using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Empoyee.Models;

namespace Empoyee.Controllers
{
    public class EmpolyeesController : Controller
    {
        private EmpoyeeContext db = new EmpoyeeContext();

        // GET: Empolyees
        public ActionResult Index()
        {
            var list = db.Empolyees.ToList();
            
            return View(list);
        }

        // GET: Empolyees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empolyee empolyee = db.Empolyees.Find(id);
            if (empolyee == null)
            {
                return HttpNotFound();
            }
            return View(empolyee);
        }

        // GET: Empolyees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empolyees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Fullname,Department")] Empolyee empolyee)
        {
            if (ModelState.IsValid)
            {
                db.Empolyees.Add(empolyee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empolyee);
        }

        // GET: Empolyees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empolyee empolyee = db.Empolyees.Find(id);
            if (empolyee == null)
            {
                return HttpNotFound();
            }
            return View(empolyee);
        }

        // POST: Empolyees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Fullname,Department")] Empolyee empolyee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empolyee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empolyee);
        }

        // GET: Empolyees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empolyee empolyee = db.Empolyees.Find(id);
            if (empolyee == null)
            {
                return HttpNotFound();
            }
            return View(empolyee);
        }

        // POST: Empolyees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empolyee empolyee = db.Empolyees.Find(id);
            db.Empolyees.Remove(empolyee);
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
