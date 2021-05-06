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

        public int CreateWorkout(WorkoutCreate model)
        {
            using (var ctx = new ApplicationDbContext())

            {
                var thing =
                    ctx
                        .KJPUser
                        .First(e => e.OwnerId == _userId);

                var entity =
                new Workout()
                {
                    UserId = thing.UserId,
                    WorkoutName = model.WorkoutName,
                    Created = DateTimeOffset.Now,
                };

                ctx.Workouts.Add(entity);
                if (ctx.SaveChanges() == 1)
                {
                    return entity.WorkoutId;
                }
                return -1;
            }
        }
        
        public IEnumerable<WorkoutListItem> GetWorkout()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Workouts
                        .Select(
                            e =>
                                new WorkoutListItem
                                {

                                    WorkoutId = e.WorkoutId,
                                    WorkoutName = e.WorkoutName,
                                    CreatedUtc = e.Created,
                                    IsFavorited = e.IsFavorited
                                    

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
                        .Single(e => e.WorkoutId == id);
                return
                    new WorkoutDetails
                    {
                        WorkoutId = entity.WorkoutId,
                        WorkoutName = entity.WorkoutName,
                        CreatedUtc = entity.Created,
                        ModifiedUtc = entity.Modified,
                        Exercises = entity.Exercises

                            .Select(
                                 e => new ExerciseListItem
                                 {
                                     WorkoutId = e.WorkoutId,
                                     ExerciseId = e.ExerciseId,
                                     ExerciseName = e.ExerciseName,
                                     Sets = e.Sets,
                                     Reps = e.Reps,
                                     Weight = e.Weight,
                                     DistanceInMiles = e.DistanceInMiles

                                 }).ToList()
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
                        .Single(e => e.WorkoutId == model.WorkoutId);

                entity.WorkoutName = model.WorkoutName;
                entity.IsFavorited = model.IsFavorited;
                entity.Modified = DateTimeOffset.UtcNow;

                foreach (var exerciseEdit in model.Exercises)
                {
                    var updateExercise = 
                     ctx
                         .Exercises
                         .Single(e => e.ExerciseId == exerciseEdit.ExerciseId);

                    updateExercise.WorkoutId = model.WorkoutId;
                    if (exerciseEdit.ExerciseName != null)
                        updateExercise.ExerciseName = exerciseEdit.ExerciseName;
                    updateExercise.Sets = exerciseEdit.Sets;
                    updateExercise.Reps = exerciseEdit.Reps;
                    updateExercise.Weight = exerciseEdit.Weight;
                    updateExercise.DistanceInMiles = exerciseEdit.DistanceInMiles;
                }


                return ctx.SaveChanges() >= 1;
            }
        }
        public bool DeleteWorkout(int workoutId) 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity  =
                    ctx
                        .Workouts
                        .Single(e => e.WorkoutId == workoutId);
                
                while( entity.Exercises.Count > 0)
                {
                    ctx.Exercises.Remove(entity.Exercises[0]);

                }
                ctx.Workouts.Remove(entity);

                return ctx.SaveChanges() >= 1;
            }
        }
    }
}
