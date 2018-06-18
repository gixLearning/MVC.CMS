using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using MVC.CMS.DataContexts;
using MVC.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC.CMS.Controllers
{
    [Authorize(Roles = RoleTypes.Admin)]
    public class RoleController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ContentDBContext dBContext = new ContentDBContext();

        public RoleController() {

        }

        public RoleController(ApplicationUserManager userManager, ApplicationSignInManager signInManager) {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager {
            get {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager {
            get {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set {
                _userManager = value;
            }
        }

        // GET: Role
        public ActionResult Index()
        {
            var model = new RoleViewModel {
                UsersWithRole = UserManager.Users
            };

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var allRoles = RoleManager.Roles.ToList();
            model.RolesList = allRoles.Select(s => new SelectListItem {
                Value = s.Id.ToString(),
                Text = s.Name
            });


            return View(model);
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult UpdateRole(string id, string role)
        {
            var user = UserManager.FindById(id);
            if (user == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));        
            

            try
            {
                // TODO: Add update logic here
                var success = UserManager.AddToRole(user.Id, RoleManager.FindById(role).Name);

                if (success.Succeeded) {
                    return RedirectToAction("Index");
                }                
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("Index");
        }
    }
}
