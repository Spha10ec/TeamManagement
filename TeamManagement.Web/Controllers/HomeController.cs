using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamManagement.BL;
using TeamManagement.Web.Models;

namespace TeamManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(PersonalDetailsModel model)
        {
            if(ModelState.IsValid)
            {
                var insertUser = new PersonalDetailsBL();
                var insertUserModel = new TeamManagement.BO.PersonalDetail
                {
                    FirstName = model.FirstName,
                    IdNumber = model.IdNumber,
                    Surname = model.LastName
                };
                insertUser.Insert(insertUserModel);
            }
            return View();
        }
    }
}