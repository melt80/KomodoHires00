using KomodoHires.Models.Team;
using KomodoHires.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KomodoHires.WebApi.Controllers
{
    public class TeamController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            TeamService teamService = CreateTeamService();
            var teams = teamService.GetTeams();
            return Ok(teams);
        }

        public IHttpActionResult Get(int id)
        {
            TeamService teamService = CreateTeamService();
            var team = teamService.GetTeamById(id);
            return Ok(team);
        }

        private TeamService CreateTeamService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var teamService = new TeamService(userId);
            return teamService;
        }

        public IHttpActionResult Post(TeamCreate team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateTeamService();
            if (!service.CreateTeam(team))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(TeamEdit team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateTeamService();
            if (!service.UpdateTeam(team))
                return InternalServerError();
            
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateTeamService();
            
            if (!service.DeleteTeam(id))
                return InternalServerError();
            
            return Ok();
        }
    }
}
