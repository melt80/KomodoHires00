using KomodoHires.Data;
using KomodoHires.Models.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoHires.Services
{
    public class ContractService
    {
        private readonly Guid _userId;

        public ContractService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateContract(ContractCreate model)
        {
            var entity =
                new Contract()
                {
                    OwnerID = _userId,
                    DeveloperID = model.DeveloperID,
                    TeamID = model.TeamID,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Contracts.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public ContractDetail GetContractById(int contractId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contracts
                        .Single(e => e.ContractID == contractId && e.OwnerID == _userId);
                return
                    new ContractDetail
                    {
                        ContractID = entity.ContractID,
                        DeveloperID = entity.DeveloperID,
                        TeamID = entity.TeamID,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }

        }

        public IEnumerable<ContractListItem> GetContracts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Contracts
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new ContractListItem
                                {
                                    ContractID = e.ContractID,
                                    DeveloperID = e.DeveloperID,
                                    TeamID = e.TeamID,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();

            }
        }

        public bool UpdateContract(ContractEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contracts
                        .Single(e => e.ContractID == model.ContractID && e.OwnerID == _userId);

                entity.DeveloperID = model.DeveloperID;
                entity.TeamID = model.TeamID;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteContract(int contractID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contracts
                        .Single(e => e.ContractID == contractID && e.OwnerID == _userId);

                ctx.Contracts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
