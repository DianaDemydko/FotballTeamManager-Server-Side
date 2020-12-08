using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Services.DTO;
using ServerApp.Services.Interfaces;

namespace ServerApp.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamServise teamServise;
        public TeamsController(ITeamServise teamServise)
        {
            this.teamServise = teamServise;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<TeamDTO>> Get()
        {
            return teamServise.GetAllTeams().ToList();
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody] TeamDTO team)
        {
            teamServise.CreateTeam(team);
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
