using KJPFit.Data;
using KJPFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Services
{
    public class WorkoutService
    {
        private readonly Guid _userId;

        public WorkoutService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateWorkout(WorkoutCreate model)/*, int workoutId) */// watch FK video again for this method 
        {
            var entity =
                new Workout()
                {
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Workouts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<WorkoutListItem> GetWorkout()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Workouts
                        //.Where(e => e.StatId == _userId)
                        .Select(
                            e =>
                                new WorkoutListItem
                                {
                                    
                                }
                        );

                return query.ToArray();
            }
        }
        public WorkoutDetails GetWorkoutById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Workouts
                        .Single(e => e.WorkoutId == id); /*&& e.UserId == _userId);*/
                return
                    new WorkoutDetails
                    {
                        
                    };
            }
        }
        public bool UpdateWorkout(WorkoutEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Workouts
                        .Single(e => e.WorkoutId == model.WorkoutId); // && e.UserId == _userId);

                //entity.Weight = (int)model.Weight;
                //entity.WeightDate = DateTimeOffset.Now;
                //entity.GoalMessage = model.GoalMessage;


                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteWorkout(int workoutId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Workouts
                        .Single(e => e.WorkoutId == workoutId); // && e.UserId == _userId);

                ctx.Workouts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
