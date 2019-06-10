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
    public class TeamNamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeamNames
        public ActionResult Index()
        {
            return View(db.TeamNames.ToList());
        }

        // GET: TeamNames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamNames teamNames = db.TeamNames.Find(id);
            if (teamNames == null)
            {
                return HttpNotFound();
            }
            return View(teamNames);
        }

        // GET: TeamNames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamId,TeamName")] TeamNames teamNames)
        {
            if (ModelState.IsValid)
            {
                db.TeamNames.Add(teamNames);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamNames);
        }

        // GET: TeamNames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamNames teamNames = db.TeamNames.Find(id);
            if (teamNames == null)
            {
                return HttpNotFound();
            }
            return View(teamNames);
        }

        // POST: TeamNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamId,TeamName")] TeamNames teamNames)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamNames).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teamNames);
        }

        // GET: TeamNames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamNames teamNames = db.TeamNames.Find(id);
            if (teamNames == null)
            {
                return HttpNotFound();
            }
            return View(teamNames);
        }

        // POST: TeamNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamNames teamNames = db.TeamNames.Find(id);
            db.TeamNames.Remove(teamNames);
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
