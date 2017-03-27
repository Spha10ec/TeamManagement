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

        #region
        //public JsonResult GetPersonInformations()
        //{
        //    var listOfPlayers = new PlayerDetailsBL();
        //    var playerDetailsList = new List<PlayerDetailsList>();

        //    var playerDetails = listOfPlayers.GetALL();

        //    foreach (var player in playerDetails)
        //    {
        //        playerDetailsList.Add
        //        (
        //             new PlayerDetailsList
        //             {
        //                 Id = player.id,
        //                 DateOfBirth = player.DateOfBirth,
        //                 FirstName = player.FirstName,
        //                 LastName = player.LastName,
        //                 Weight = player.Weight,
        //                 Height = player.Height,
        //                 Notes = player.Notes

        //             });
        //    }
        //    return Json(playerDetailsList, JsonRequestBehavior.AllowGet);
        //}
        #endregion
        public JsonResult GetFeaturesAndScores()
        {
            var playDetails = new PlayDetailsBL();
            var model = new List<TeamFeaturesModel>();
            var teamDetails = new TeamDetailsBL();

            var result = playDetails.GetALL();

            foreach (var detail in result)
            {
                model.Add
                (
                     new TeamFeaturesModel
                     {
                         HomeTeam = teamDetails.GetByID((int)detail.TeamId).TeamName, // Session["HomeTeam"].ToString(),
                         PlayingAgainst = detail.TeamAgainst,
                         Season = teamDetails.GetByID((int)detail.TeamId).SeasonYear,
                         Venue = (detail.Venue ?? "").ToString(),
                         id = detail.Id,
                         AwayTeamScore = (detail.AwayScore ?? "").ToString(),
                         Date = (System.DateTime)detail.FixtureDate,
                         HomeScore = (detail.HomeScore ?? "").ToString()
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
        public ActionResult AddFeatures()
        {
            var teamNameBl = new TeamDetailsBL();
            var model = new TeamFeaturesModel();
          //  var playDetails = new PlayDetailsBL();

            var teamDetails = teamNameBl.GetSingle();
            if (teamDetails != null)
            {
                model.Season = teamDetails.SeasonYear;
                model.HomeTeam = teamDetails.TeamName;
                model.TeamId = teamDetails.Id;
                model.Date = DateTime.Now;
                Session["HomeTeam"] = model.HomeTeam;
                Session["Season"] = model.Season;
            }
            model.successMessage = (TempData["SuccessMessage"] ?? String.Empty).ToString();
            model.errorMessage = (TempData["ErrorMessage"] ?? String.Empty).ToString();
            if (!String.IsNullOrEmpty( model.successMessage))
            {
                model.isSuccessMessage = true;
            }
            if (!String.IsNullOrEmpty(model.errorMessage))
            {
                model.isSuccessMessage = true;
            }
            return View(model);
        }

           [HttpPost]
        public ActionResult UpdateScores(TeamFeaturesModel model)
        {
        //    var errors = ModelState.Values.SelectMany(v => v.Errors);
         //   var errors2 = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
           // if (ModelState.IsValid)
           // {
                var updateScores = new PlayDetailsBL();
                var updateScoresModel = new TeamManagement.BO.PlayDetail
                {
                    HomeScore = model.HomeScore,
                    AwayScore = model.AwayTeamScore,
                    Id =model.id

                };
                string message = updateScores.Update(updateScoresModel);

                if (message.Equals(String.Empty))
                {
                    model.isSuccessMessage = true;
                    TempData["SuccessMessage"] = "Scores successfully updated";
                    return RedirectToAction("AddFeatures");
                }
                else
                {
                    model.isSuccessMessage = false;
                    TempData["ErrorMessage"] = message;
                    return RedirectToAction("AddFeatures");
                }
        //    }

          //  return View();
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
                    TeamId = model.TeamId,
                    FixtureDate = model.Date,
                   // HomeTeam = model.HomeTeam
                    

                };
                string message = addFeature.Insert(addfeatureModel);

                if (message.Equals(String.Empty))
                {
                    model.isSuccessMessage = true;
                    model.errorMessage = "Team Successfully added";
                    return View(model);
                }
                else
                {
                    model.isSuccessMessage = false;
                    model.errorMessage = message;
                    return View(model);
                }
            }
            model.HomeTeam = Session["HomeTeam"].ToString();
            return View(model);
        }


    }

}