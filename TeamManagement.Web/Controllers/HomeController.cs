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
     [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Error()
        {
            string errorMessage = TempData["ErrorMessage"].ToString();
            return View("Error", errorMessage);
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

        public JsonResult GetFeaturesAndScores()
        {
            var playDetails = new PlayDetailsBL();
            var model = new List<TeamFeaturesModel>();

            var result = playDetails.GetALL();

            foreach (var detail in result)
            {
                model.Add
                (
                     new TeamFeaturesModel
                     {
                         HomeTeam = Session["HomeTeam"].ToString(),
                         PlayingAgainst = detail.TeamAgainst,
                         Season = Session["Season"].ToString(),
                         Venue = detail.Venue,
                         
                         AwayTeamScore = detail.AwayScore.ToString(),
                         Date = (System.DateTime)detail.FixtureDate,
                         HomeScore = detail.HomeScore.ToString()                        
                     });
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(PersonalDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                var insertUser = new PersonalDetailsBL();
                var insertUserModel = new TeamManagement.BO.PersonalDetail
                {
                    FirstName = model.FirstName,
                    IdNumber = model.IdNumber,
                    Surname = model.LastName
                };
                string message = insertUser.Insert(insertUserModel);

                if (message.Equals(String.Empty))
                {
                    model.successMessage = true;
                    model.errorMessage = "Record Successfully updated";
                    return View(model);
                }
                else
                {
                    model.successMessage = false;
                    model.errorMessage = message;
                    return View(model);
                }
            }
            return View();
        }

         [Authorize(Roles = "Admin")]
        public ActionResult AddTeam()
        {
            return View();
        }

         [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddTeam(TeamModel model)
        {
            if (ModelState.IsValid)
            {
                var addUseraddANewTeam = new TeamDetailsBL();
                var addUseraddANewTeamModel = new TeamManagement.BO.Team
                {
                    Motto = model.Motto,
                    SeasonYear = model.SeasonYear,
                    SportCode = model.SportCode,
                    TeamName = model.TeamName
                };
                string message = addUseraddANewTeam.Insert(addUseraddANewTeamModel);

                if (message.Equals(String.Empty))
                {
                    model.successMessage = true;
                    model.errorMessage = "Team Successfully added";
                    return View(model);
                }
                else
                {
                    model.successMessage = false;
                    model.errorMessage = message;
                    return View(model);
                }
            }

            return View();
        }


         [HttpGet]
        public ActionResult AddFeatures ()
         {
             var teamNameBl = new TeamDetailsBL();
             var model = new TeamFeaturesModel();

             var teamDetails = teamNameBl.GetSingle();
             if (teamDetails != null)
             {
                 model.Season = teamDetails.SeasonYear;
                 model.HomeTeam = teamDetails.TeamName;
                 model.TeamId = teamDetails.Id;

                 Session["HomeTeam"] = model.HomeTeam;
                 Session["Season"] = model.Season;
             }
             return View(model);
         }
         [HttpPost]
         public ActionResult AddFeatures(TeamFeaturesModel model)
         {
             if (ModelState.IsValid)
             {
                 var addFeature = new PlayDetailsBL();
                 var addfeatureModel = new TeamManagement.BO.PlayDetail
                 {
                    Season = model.Season,
                    TeamAgainst = model.PlayingAgainst,
                    Venue = model.Venue,
                    TeamId = model.TeamId

                 };
                 string message = addFeature.Insert(addfeatureModel);

                 if (message.Equals(String.Empty))
                 {
                     model.successMessage = true;
                     model.errorMessage = "Team Successfully added";
                     return View(model);
                 }
                 else
                 {
                     model.successMessage = false;
                     model.errorMessage = message;
                     return View(model);
                 }
             }

             return View();
         }
    }

}