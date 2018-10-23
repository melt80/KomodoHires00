using KomodoHires.Models.Developer;
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
    [Authorize]
    public class DeveloperController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            DeveloperService developerService = CreateDeveloperService();
            var developers = developerService.GetDevelopers();
            return Ok(developers);
        }

        public IHttpActionResult Get(int id)
        {
            DeveloperService developerService = CreateDeveloperService();
            var developer = developerService.GetDeveloperById(id);
            return Ok(developer);
        }

        public IHttpActionResult Post(DeveloperCreate developer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateDeveloperService();
            if (!service.CreateDeveloper(developer))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(DeveloperEdit developer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateDeveloperService();
            if (!service.UpdateDeveloper(developer))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateDeveloperService();
            if (!service.DeleteDeveloper(id))
                return InternalServerError();
            return Ok();
        }

        private DeveloperService CreateDeveloperService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var developerService = new DeveloperService(userId);
            return developerService;
        }
    }
}
