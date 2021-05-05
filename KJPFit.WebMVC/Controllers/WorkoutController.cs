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
    public class WorkoutController : Controller
    {
        [Authorize]
        // GET: Workout
        public ActionResult Index()
        {
            var workoutId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutService(workoutId);
            var model = service.GetWorkout();
            return View(model);
        }
        public ActionResult Create()
        {
            
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkoutCreate model)
        {
            if (!ModelState.IsValid)
            
                return View(model);

            var service = CreateWorkoutService();
            var thing = service.CreateWorkout(model);
            
            if ( thing != -1)
            {
                
                TempData["SaveResult"] = "Workout Created.";
                return RedirectToAction("AddExerciseToWorkout", "Exercise", new {id = thing }); 
            };

            ModelState.AddModelError("", "Workout could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateWorkoutService();
            var model = svc.GetWorkoutById(id);

            return View(model);
        }
        public ActionResult Edit(int id) 
        {
            var service = CreateWorkoutService();
            var detail = service.GetWorkoutById(id);
            var model =
                new WorkoutEdit
                {
                    WorkoutId = detail.WorkoutId,
                    WorkoutName = detail.WorkoutName,
                    IsFavorited = detail.IsFavorited,
                    Exercises = detail.Exercises
                    .Select(
                                 e => new ExerciseEdit
                                 {
                                     WorkoutId = e.WorkoutId,
                                     ExerciseId = e.ExerciseId,
                                     ExerciseName = e.ExerciseName, // this needs to be drop down in views
                                     Sets = e.Sets,
                                     Reps = e.Reps,
                                     Weight = e.Weight,
                                     DistanceInMiles = e.DistanceInMiles

                                 }).ToList()


                };
            return View(model); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkoutEdit model)
        {
            if (!ModelState.IsValid)

                return View(model);

            if (model.WorkoutId != id)
            {
                ModelState.AddModelError("", "Id Doesn't Match");
                return View(model);
            }

            var service = CreateWorkoutService();

            if (service.UpdateWorkout(model))
            {
                TempData["SaveResult"] = "Workout info was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Workout info could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWorkoutService();
            var model = svc.GetWorkoutById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWorkout(int id)
        {
            var service = CreateWorkoutService();

            service.DeleteWorkout(id);

            TempData["SaveResult"] = "Workout was deleted";

            return RedirectToAction("Index");
        }
        private WorkoutService CreateWorkoutService()
        {
            var workoutId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutService(workoutId);
            return service;
        }
    }
}