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
    public class ExerciseController : Controller
    {
        // GET: Exercise
        public ActionResult Index()
        {
            var exerciseId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExerciseService(exerciseId);
            var model = service.GetExercise();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExerciseCreate model/* int statId*/)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateExerciseService();

            if (service.CreateExercise(model/* statId*/))
            {
                TempData["SaveResult"] = "Exercise added! Add more!.";
                return RedirectToAction("Index"); // this will want to return to same screen to they can select more exercises
            };

            ModelState.AddModelError("", "Exercise could not be added.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateExerciseService();
            var model = svc.GetExerciseById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateExerciseService();
            var detail = service.GetExerciseById(id);
            var model =
                new ExerciseEdit
                {
                    ExerciseId = detail.ExerciseId,
                    Sets = detail.Sets,
                    Reps = detail.Reps,
                    Weight = detail.Weight,
                    DistanceInMiles = detail.DistanceInMiles
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ExerciseEdit model)
        {
            if (!ModelState.IsValid)

                return View(model);

            if (model.ExerciseId != id)
            {
                ModelState.AddModelError("", "Id Doesn't Match");
                return View(model);
            }

            var service = CreateExerciseService();

            if (service.UpdateExercise(model))
            {
                TempData["SaveResult"] = "Exercise info was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Exercise info could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateExerciseService();
            var model = svc.GetExerciseById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteExercise(int id)
        {
            var service = CreateExerciseService();

            service.DeleteExercise(id);

            TempData["SaveResult"] = "Exercise was deleted";

            return RedirectToAction("Index");
        }
        private ExerciseService CreateExerciseService()
        {
            var exerciseId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExerciseService(exerciseId);
            return service;
        }
    }
}




        