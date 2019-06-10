using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Genzeon.Models;
using Genzeon.ViewModels;

namespace Genzeon.Controllers
{
    public class TechesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teches
        public ActionResult Index()
        {
            return View(db.Teches.ToList());
        }

        // GET: Teches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tech tech = db.Teches.Find(id);
            if (tech == null)
            {
                return HttpNotFound();
            }
            return View(tech);
        }

        // GET: Teches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TechId,TechName")] Tech tech)
        {
            if (ModelState.IsValid)
            {
                db.Teches.Add(tech);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tech);
        }

        // GET: Teches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tech tech = db.Teches.Find(id);
            if (tech == null)
            {
                return HttpNotFound();
            }
            return View(tech);
        }

        // POST: Teches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TechId,TechName")] Tech tech)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tech).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tech);
        }

        // GET: Teches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tech tech = db.Teches.Find(id);
            if (tech == null)
            {
                return HttpNotFound();
            }
            return View(tech);
        }

        // POST: Teches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tech tech = db.Teches.Find(id);
            db.Teches.Remove(tech);
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
