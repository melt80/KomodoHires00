using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoHires.Models.Team;

namespace KomodoHires.Services.MockServices
{
    class MockTeamService : ITeamService
    {
        public bool ReturnValue { get; set; }
        public int CallCount { get; set; }

        public bool CreateTeam(TeamCreate model)
        {
            CallCount++;
            return ReturnValue;
        }

        public bool DeleteTeam(int teamID)
        {
            CallCount--;
            return ReturnValue;
        }

        public TeamDetail GetTeamById(int teamId)
        {
            CallCount++;
            return new TeamDetail { TeamID = teamId };
        }

        public IEnumerable<TeamListItem> GetTeams()
        {
            CallCount++;
            var @return = new List<TeamListItem>
            {
                new TeamListItem { TeamID = 1 }
            };
            return @return;
        }

        public bool UpdateTeam(TeamEdit model)
        {
            return ReturnValue;
        }
    }
}
