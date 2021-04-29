using KJPFit.Data;
using KJPFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Services
{
    public class StatService
    {
        private readonly Guid _userId;

        public StatService(Guid userId)
        {
            _userId = userId;
        }

        
        public bool CreateStat(StatCreate model) // watch FK video again for this method 
        {

            var context = new ApplicationDbContext();
            var user = context.KJPUser.Single(e => e.OwnerId == _userId);
            

            var entity =
                new Stat()
                {
                    UserStatId = user.UserId,
                    Weight= model.Weight,
                    WeightDate = DateTimeOffset.Now,
                    GoalMessage = model.GoalMessage
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Stats.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<StatListItem> GetStat()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Stats
                        //.Where(e => e.StatId == _userId)
                        .Select(
                            e =>
                                new StatListItem
                                {
                                    StatId = e.StatId, 
                                    FirstName= e.User.FirstName,
                                    LastName = e.User.LastName,
                                    HeightInInches = e.User.HeightInInches,
                                    Weight = e.Weight,   
                                    WeightDate = e.WeightDate,
                                    GoalMessage = e.GoalMessage
                                }
                        );

                return query.ToArray();
            }
        }
        public StatDetails GetStatById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stats
                        .Single(e => e.StatId == id); /*&& e.UserId == _userId);*/
                return
                    new StatDetails
                    {
                        StatId = entity.StatId,
                        FirstName = entity.User.FirstName,
                        LastName = entity.User.LastName,
                        HeightInInches = entity.User.HeightInInches,
                        Weight = entity.Weight,
                        WeightDate = entity.WeightDate,
                        GoalMessage = entity.GoalMessage
                    };
            }
        }
        public bool UpdateStat(StatEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stats
                        .Single(e => e.StatId == model.StatId); // && e.UserId == _userId);

                entity.Weight = (int)model.Weight;
                entity.WeightDate = DateTimeOffset.Now;
                entity.GoalMessage = model.GoalMessage;
                

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteStat(int statId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stats
                        .Single(e => e.StatId == statId); // && e.UserId == _userId);

                ctx.Stats.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

