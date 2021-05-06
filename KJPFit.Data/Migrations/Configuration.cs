namespace KJPFit.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KJPFit.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "KJPFit.Data.ApplicationDbContext";
        }

        protected override void Seed(KJPFit.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
                context.Exercises.AddOrUpdate(
                  p => p.ExerciseName,
            new Exercise { ExerciseName = "Bench Press" },
                  new Exercise { ExerciseName = "Incline Bench Press" },
                  new Exercise { ExerciseName = "Decline Bench Press" },
                  new Exercise { ExerciseName = "Lat Pulldown" },
                  new Exercise { ExerciseName = "Lat Row" },
                  new Exercise { ExerciseName = "Pullup" },
                  new Exercise { ExerciseName = "Bicep Barbell Curl" },
                  new Exercise { ExerciseName = "Hammer Curl" },
                  new Exercise { ExerciseName = "Concentration Curl" },
                  new Exercise { ExerciseName = "Overhead Tricep Extension" },
                  new Exercise { ExerciseName = "Tricep Pushdown" },
                  new Exercise { ExerciseName = "Close-Grip Bench Press" },
                  new Exercise { ExerciseName = "Side Lateral Raise" },
                  new Exercise { ExerciseName = "Front Raise" },
                  new Exercise { ExerciseName = "Rear Delt Fly" },
                  new Exercise { ExerciseName = "Squat" },
                  new Exercise { ExerciseName = "Dumbbbell Lunge" },
                  new Exercise { ExerciseName = "Hamstring Curl" },
                  new Exercise { ExerciseName = "Crunches" },
                  new Exercise { ExerciseName = "Side Crunches" },
                  new Exercise { ExerciseName = "Leg Lifts" },
                  new Exercise { ExerciseName = "Treadmill" },
                  new Exercise { ExerciseName = "Eliptical" },
                  new Exercise { ExerciseName = "StairMaster" }
               );
            
        }
    }
}
