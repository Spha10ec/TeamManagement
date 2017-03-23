using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamManagement.Web.Models;

namespace TeamManagement.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class PlayerController : Controller
    {
        //
        // GET: /Player/
        public ActionResult Index()
        {
            var model = new PlayerDetailsModel();
            model.displayErrorBlock = false;
            return View(model);
        }
	}
}