using System.Collections.Generic;
using KomodoHires.Models.Team;

namespace KomodoHires.Services
{
    public interface ITeamService
    {
        bool CreateTeam(TeamCreate model);
        bool DeleteTeam(int teamID);
        TeamDetail GetTeamById(int teamId);
        IEnumerable<TeamListItem> GetTeams();
        bool UpdateTeam(TeamEdit model);
    }
}