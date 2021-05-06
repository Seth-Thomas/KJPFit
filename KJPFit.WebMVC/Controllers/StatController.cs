using KJPFit.Data;
using KJPFit.Models;
using KJPFit.Services;
using Microsoft.AspNet.Identity;
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
        public ActionResult Index()
        {
            var statId = Guid.Parse(User.Identity.GetUserId());
            var service = new StatService(statId); 
            var model = service.GetStat();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StatCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateStatService();

            if (service.CreateStat(model))
            {
                TempData["SaveResult"] = "Stats added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Stats could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateStatService();
            var model = svc.GetStatById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateStatService();
            var detail = service.GetStatById(id);
            var model =
                new StatEdit
                {
                    StatId = detail.StatId,
                    Weight = detail.Weight,
                    WeightDate = detail.WeightDate,
                    GoalMessage = detail.GoalMessage
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StatEdit model)
        {
            if (!ModelState.IsValid) 
                
                return View(model);

            if (model.StatId != id)
            {
                ModelState.AddModelError("", "Id Doesn't Match");
                return View(model);
            }

            var service = CreateStatService();

            if (service.UpdateStat(model))
            {
                TempData["SaveResult"] = "Stat info was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Stat info could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateStatService();
            var model = svc.GetStatById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStat(int id)
        {
            var service = CreateStatService();

            service.DeleteStat(id);

            TempData["SaveResult"] = "Stats were deleted";

            return RedirectToAction("Index");
        }

        private StatService CreateStatService()
        {
            var statId = Guid.Parse(User.Identity.GetUserId());
            var service = new StatService(statId);
            return service;
        }
    }

}
