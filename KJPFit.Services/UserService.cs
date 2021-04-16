using KJPFit.Data;
using KJPFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Services
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    HeightInInches = model.HeightInInches,
                    Joined = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.KJPUser.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserListItem> GetUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .KJPUser
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new UserListItem
                                {
                                    UserId = e.UserId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    HeightInInches = e.HeightInInches,
                                    Joined = e.Joined
                                }
                        );

                return query.ToArray();
            }
        }
        public UserDetail GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .KJPUser
                        .Single(e => e.UserId == id && e.OwnerId == _userId);
                return
                    new UserDetail
                    {
                        UserId = entity.UserId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        HeightInInches = entity.HeightInInches,
                        Joined = entity.Joined,
                        Modified = entity.Modified
                    };
            }
        }
        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .KJPUser
                        .Single(e => e.UserId == model.UserId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.HeightInInches = (int)model.HeightInInches;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
