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
        public bool CreateStat(StatCreate model)
        {
            var entity =
                new Stat()
                {
                    OwnerId = _userId,
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
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new StatListItem
                                {
                                    StatId = e.StatId,
                                    Weight = e.Weight,
                                    WeightDate = e.WeightDate //this may not work
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
                        .Single(e => e.StatId == id && e.OwnerId == _userId);
                return
                    new StatDetails
                    {
                        StatId = entity.StatId,
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
                        .Single(e => e.StatId == model.StatId && e.OwnerId == _userId);

                entity.Weight = (int)model.Weight;
                entity.WeightDate = DateTimeOffset.Now;
                entity.GoalMessage = model.GoalMessage;
                

                return ctx.SaveChanges() == 1;
            }
        }
        //public bool DeleteStat(int statId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Stats
        //                .Single(e => e.StatId == statId && e.OwnerId == _userId);

        //        ctx.Stats.Remove(entity);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}
    }
}

