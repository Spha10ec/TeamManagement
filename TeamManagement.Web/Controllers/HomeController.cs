using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
        public ActionResult Error()
        {
            string errorMessage = TempData["ErrorMessage"].ToString();
            return View("Error",errorMessage);
        }
        public JsonResult GetPersonInformations()
        {
            var listOfPlayers = new PlayerDetailsBL();
            var playerDetailsList = new List<PlayerDetailsList>();

            var playerDetails = listOfPlayers.GetALL();

            foreach (var player in playerDetails)
            {
                playerDetailsList.Add
                (
                     new PlayerDetailsList
                     {
                         Id = player.id,
                         DateOfBirth = player.DateOfBirth,
                         FirstName = player.FirstName,
                         LastName = player.LastName,
                         Weight = player.Weight,
                         Height = player.Height,
                         Notes = player.Notes

                     });
            }
            return Json(playerDetailsList, JsonRequestBehavior.AllowGet);
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
              string message = insertUser.Insert(insertUserModel);
             
                if(message.Equals(String.Empty))
                {
                    model.successMessage = true;
                    model.errorMessage = "Record Successfully updated";
                    return View(model);
                }
                else
                {
                    model.successMessage = false;
                    model.errorMessage =message;
                    return View(model);
                }
            }
            return View();
        }
    }
}