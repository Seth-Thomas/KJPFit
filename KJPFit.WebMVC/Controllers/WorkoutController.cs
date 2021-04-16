using KJPFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KJPFit.WebMVC.Controllers
{
    public class WorkoutController : Controller
    {
        [Authorize]
        // GET: Workout
        public ActionResult Index()
        {
            var model = new WorkoutListItem[0];
            return View(model);
        }
    }
}