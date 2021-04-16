using KJPFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KJPFit.WebMVC.Controllers
{
    [Authorize]
    public class StatController : Controller
    {
        // GET: Stat
        public ActionResult Index()
        {
            var model = new StatListItem[0];
            return View(model);
        }
    }
}