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
        // GET Teams
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<TeamDTO>> GetTeams()
        {
            return teamServise.GetAllTeams().ToList();
        }

        // GET Team Members
        [HttpGet("[action]/{id}")]
        public ActionResult<IEnumerable<UserDTO>> GetTeamMembers(int id)
        {
            return teamServise.GetAllTeamMembers(id).ToList();
        }

        // POST Create Team
        [HttpPost("[action]")]
        public void CreateTeam([FromBody] TeamDTO team)
        {
            teamServise.CreateTeam(team);
        }

        // PUT Change name
        [HttpPatch("[action]/{id}/{name}")]
        public void ChangeTeamName(int id, string name)
        {
            teamServise.ChangeTeamName(id, name);
        }

        //PUT Add player to team
        [HttpPut("[action]/{id}")]
        public void AddPlayerToTeam(int id, [FromBody] int playerId)
        {
            teamServise.AddPlayer(id, playerId);
        }

        // DELETE Delete team
        [HttpDelete("[action]/{id}")]
        public void DeleteTeam(int id)
        {
            teamServise.RemoveTeam(id);
        }
    }
}
