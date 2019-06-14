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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Genzeon.Controllers
{
    [Authorize]
    public class RequirementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        //Requirements List
        public ActionResult RequirementList()
        {
            var Email = HttpContext.User.Identity.GetUserName();
            var totalRequriement = db.RequirementDatas.Count();
            return View(db.RequirementDatas.Where(acc=>acc.Email.Equals(Email)).Include(r => r.TeamNames).Include(r => r.Tech).OrderByDescending(v=>v.Date));
        }

        //Requirements Details by each id
        public ActionResult RequirementInfo(int? id)
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

        //Adding new Requirements
        public ActionResult AddRequirement()
        {
            ViewBag.TeamId = new SelectList(db.TeamNames, "TeamId", "TeamName");
            ViewBag.TechId = new SelectList(db.Teches, "TechId", "TechName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRequirement([Bind(Include = "JobCode,DesignationName,Experience,Location,Qualification,Salary,Vacancies,ShiftType,Description,TechId,TeamId")] RequirementData requirementData)
        {
            var ApplicationUserId = User.Identity.GetUserName();
            requirementData.Email = ApplicationUserId;
            DateTime d = DateTime.Now;
            requirementData.Date = d.ToShortDateString();
            if (ModelState.IsValid)
            {
                db.RequirementDatas.Add(requirementData);
                db.SaveChanges();
                return RedirectToAction("RequirementList");
            }

            ViewBag.TeamId = new SelectList(db.TeamNames, "TeamId", "TeamName", requirementData.TeamId);
            ViewBag.TechId = new SelectList(db.Teches, "TechId", "TechName", requirementData.TechId);
            return View(requirementData);
        }

        // Requirements Edit by using Id
        public ActionResult UpdateRequirement(int? id)
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

        // POST: Requirements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateRequirement([Bind(Include = "JobCode,DesignationName,Experience,Location,Qualification,Salary,Vacancies,ShiftType,Description,Date,TechId,TeamId,Email")] RequirementData requirementData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requirementData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("RequirementList");
            }
            ViewBag.TeamId = new SelectList(db.TeamNames, "TeamId", "TeamName", requirementData.TeamId);
            ViewBag.TechId = new SelectList(db.Teches, "TechId", "TechName", requirementData.TechId);
            return View(requirementData);
        }

        // Delete the Requirement by Id 
        public ActionResult DeleteRequirement(int? id)
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

        [HttpPost, ActionName("DeleteRequirement")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequirementData requirementData = db.RequirementDatas.Find(id);
            db.RequirementDatas.Remove(requirementData);
            db.SaveChanges();
            return RedirectToAction("RequirementList");
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
