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
    public class RequirementDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RequirementDetails
        public ActionResult Index()
        {
            var requirementDatas = db.RequirementDatas.Include(r => r.TeamNames).Include(r => r.Tech);
            return View(requirementDatas.ToList());
        }

        // GET: RequirementDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequirementData requirementData = db.RequirementDatas.Find(id);
            if (requirementData == null)
            {
                return HttpNotFound();
            }
            return View(requirementData);
        }

        // GET: RequirementDetails/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.TeamNames, "TeamId", "TeamName");
            ViewBag.TechId = new SelectList(db.Teches, "TechId", "TechName");
            return View();
        }

        // POST: RequirementDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "jobCode,positionName,skills,requiredSize,experience,jobDescription,uploadedBy,TechId,TeamId")] RequirementData requirementData)
        {
            if (ModelState.IsValid)
            {
                db.RequirementDatas.Add(requirementData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.TeamNames, "TeamId", "TeamName", requirementData.TeamId);
            ViewBag.TechId = new SelectList(db.Teches, "TechId", "TechName", requirementData.TechId);
            return View(requirementData);
        }

        // GET: RequirementDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequirementData requirementData = db.RequirementDatas.Find(id);
            if (requirementData == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.TeamNames, "TeamId", "TeamName", requirementData.TeamId);
            ViewBag.TechId = new SelectList(db.Teches, "TechId", "TechName", requirementData.TechId);
            return View(requirementData);
        }

        // POST: RequirementDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jobCode,positionName,skills,requiredSize,experience,jobDescription,uploadedBy,TechId,TeamId")] RequirementData requirementData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requirementData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.TeamNames, "TeamId", "TeamName", requirementData.TeamId);
            ViewBag.TechId = new SelectList(db.Teches, "TechId", "TechName", requirementData.TechId);
            return View(requirementData);
        }

        // GET: RequirementDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequirementData requirementData = db.RequirementDatas.Find(id);
            if (requirementData == null)
            {
                return HttpNotFound();
            }
            return View(requirementData);
        }

        // POST: RequirementDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequirementData requirementData = db.RequirementDatas.Find(id);
            db.RequirementDatas.Remove(requirementData);
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
