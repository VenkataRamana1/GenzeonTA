using Genzeon.Models;
using Genzeon.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Genzeon.Controllers
{
    //[Authorize(Roles = "SuperAdmin")]
    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationRoleManager _roleManager;
        public RoleController()
        {
        }

        public RoleController(ApplicationRoleManager roleManager)
        {

            RoleManager = roleManager;
        }

        public ApplicationRoleManager RoleManager
        {

            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public ActionResult Index()
        {
            List<RoleViewModel> list = new List<RoleViewModel>();
            foreach (var role in RoleManager.Roles)
                list.Add(new RoleViewModel(role));
            return View(list);
        }

        public ActionResult AddNewRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddNewRole(RoleViewModel model)
        {
            var role = new ApplicationRole() { Name = model.Name };
            await RoleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditRole(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditRole([Bind(Include = "Id,Name")] RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleViewModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(roleViewModel);
        }


        public async Task<ActionResult> DeleteRole(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }


        [HttpPost, ActionName("DeleteRole")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
    }
}