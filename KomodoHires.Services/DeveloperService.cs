using KomodoHires.Data;
using KomodoHires.Models.Developer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoHires.Services
{
    public class DeveloperService
    {
        private readonly Guid _userId;

        public DeveloperService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDeveloper(DeveloperCreate model)
        {
            var entity =
                new Developer()
                {
                    OwnerID = _userId,
                    Name = model.Name,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Developers.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<DeveloperListItem> GetDevelopers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Developers
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new DeveloperListItem
                                {
                                    DeveloperID = e.DeveloperID,
                                    Name = e.Name,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();

            }
        }

        public bool UpdateDeveloper(DeveloperEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Developers
                        .Single(e => e.DeveloperID == model.DeveloperID && e.OwnerID == _userId);

                entity.Name = model.Name;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDeveloper(int developerID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Developers
                        .Single(e => e.DeveloperID == developerID && e.OwnerID == _userId);

                ctx.Developers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
