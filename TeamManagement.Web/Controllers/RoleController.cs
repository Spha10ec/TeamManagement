using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamManagement.Web.Models;

namespace TeamManagement.Web.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {


              //  if (!isAdminUser())
             //   {
                    //return RedirectToAction("Index", "Home");
              //  }
            }
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            ApplicationDbContext context = new ApplicationDbContext();
            var Roles = context.Roles.ToList();
            return View(Roles);  
        }
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {


                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            ApplicationDbContext context = new ApplicationDbContext();
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public bool isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }    
	}
}