using KJPFit.Models;
using KJPFit.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KJPFit.WebMVC.Controllers
{
    [Authorize]
    [RoutePrefix("api/KJPFit")]
    public class KJPFitController : ApiController
        
    {
        private bool SetStarState(int workoutId, bool newState)
        {
            // Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutService(userId);

            // Get the workout
            var detail = service.GetWorkoutById(workoutId);

            // Create the WorkoutEdit model instance with the new star state
            var updatedWorkout =
                new WorkoutEdit
                {
                    WorkoutId = detail.WorkoutId,
                    WorkoutName = detail.WorkoutName,
                    
                    IsFavorited = newState
                };

            // Return a value indicating whether the update succeeded
            return service.UpdateWorkout(updatedWorkout);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}
