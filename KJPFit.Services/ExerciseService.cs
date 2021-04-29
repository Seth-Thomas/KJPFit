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

        // Changed UserStatId from StatId. Unsure of this.
        public bool CreateExercise(ExerciseCreate model/*, int exerciseId*/) // watch FK video again for this method 
        {
            var entity =
                new Exercise()
                {
                    //OwnerId = _userId,
                    ExerciseId = model.ExerciseId, /*exerciseId,*/ // relate to FK video 
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
                        //.Where(e => e.StatId == _userId)
                        .Select(
                            e =>
                                new ExerciseListItem
                                {
                                    ExerciseId = e.ExerciseId, //issue later?
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
        public IEnumerable<Exercise> GetExerciseNameList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Exercises
                        //.Where(e => e.StatId == _userId)
                        .Select(
                            e =>
                                new Exercise
                                {
                                    ExerciseName = e.ExerciseName,
                                    //Sets = e.Sets,
                                    //Reps = e.Reps,
                                    //Weight = e.Weight,
                                }
                        );

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
                        .Single(e => e.ExerciseId == id); /*&& e.UserId == _userId);*/
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
                        .Single(e => e.ExerciseId == model.ExerciseId); // && e.UserId == _userId);

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
                        .Single(e => e.ExerciseId == exerciseId); // && e.UserId == _userId);

                ctx.Exercises.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
