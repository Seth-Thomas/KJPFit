using KJPFit.Data;
using KJPFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Services
{
    public class ExerciseService
    {
        private readonly Guid _userId;

        public ExerciseService(Guid userId)
        {
            _userId = userId;
        }

        
        public bool CreateExercise(ExerciseCreate model) 
        {
            var entity =
                new Exercise()
                {
                    WorkoutId = model.WorkoutId,
                    ExerciseName = model.ExerciseName,
                    Sets = model.Sets,
                    Reps = model.Reps,
                    Weight = model.Weight,
                    DistanceInMiles = model.DistanceInMiles
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Exercises.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ExerciseListItem> GetExercise()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Exercises
                        .Select(
                            e =>
                                new ExerciseListItem
                                {
                                    ExerciseId = e.ExerciseId, 
                                    ExerciseName = e.ExerciseName,
                                    Sets = e.Sets,
                                    Reps = e.Reps,
                                    Weight = e.Weight,
                                    DistanceInMiles = e.DistanceInMiles
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<ExerciseListItem> GetExercisesByWorkoutId(int workoutId) 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundItems =
                    ctx.Workouts.Single(w => w.WorkoutId == workoutId).Exercises
                    .Select(e => new ExerciseListItem
                    {
                        ExerciseId = e.ExerciseId,
                        ExerciseName = e.ExerciseName,
                        Sets = e.Sets,
                        Reps = e.Reps,
                        Weight = e.Weight,
                        DistanceInMiles = e.DistanceInMiles
                    }
                    );
                return foundItems.ToArray();
            }
        }
        public IEnumerable<Exercise> GetExerciseNameList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Exercises
                        .Select(
                            e => e.ExerciseName
                        ).Distinct();

                return ctx.Exercises.ToList();
            }
        }
        public ExerciseDetails GetExerciseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exercises
                        .Single(e => e.ExerciseId == id); 
                return
                    new ExerciseDetails
                    {
                        ExerciseId = entity.ExerciseId,
                        ExerciseName = entity.ExerciseName,
                        Sets = entity.Sets,
                        Reps = entity.Reps,
                        Weight = entity.Weight,
                        DistanceInMiles = entity.DistanceInMiles

                    };
            }
        }
        public bool UpdateExercise(ExerciseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exercises
                        .Single(e => e.ExerciseId == model.ExerciseId);
                entity.WorkoutId = model.WorkoutId;
                if(model.ExerciseName != null)
                entity.ExerciseName = model.ExerciseName;
                entity.Sets = model.Sets;
                entity.Reps = model.Reps;
                entity.Weight = model.Weight;
                entity.DistanceInMiles = model.DistanceInMiles;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteExercise(int exerciseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exercises
                        .Single(e => e.ExerciseId == exerciseId);

                ctx.Exercises.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
