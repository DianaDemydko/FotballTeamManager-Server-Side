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

        // GET Team by ID
        [HttpGet("[action]/{id}")]
        public ActionResult<TeamDTO> GetTeamById(int id)
        {
            return teamServise.GetTeamById(id);
        }

        // GET All Team Roles
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<RoleDTO>> GetTeamRoles()
        {
            return teamServise.GetTeamRoles().ToList();
        }

        // GET Team Members
        [HttpGet("[action]/{id}")]
        public ActionResult<IEnumerable<UserDTO>> GetTeamMembers(int id)
        {
            return teamServise.GetAllTeamMembers(id).ToList();
        }

        // POST Create Team
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateTeam([FromBody] TeamDTO team)
        {
            try
            {
                teamServise.CreateTeam(team);
                return Ok();
            } catch
            {
                return BadRequest();
            }
            
        }

        // PUT Change name
        [HttpPatch("[action]/{id}/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ChangeTeamName(int id, string name)
        {
            try
            {
                teamServise.ChangeTeamName(id, name);
                return Ok();
            } catch
            {
                return NotFound();
            }
            
        }

        // PUT Change name
        [HttpPatch("[action]/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RemovePlayer(int userId)
        {
            try
            {
                teamServise.RemovePlayer(userId);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        //PATCH Change role of player in the team
        [HttpPatch("[action]/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ChangePlayerRole(int userId, [FromBody] int roleId)
        {
            try
            {
                teamServise.ChangePlayerRole(userId, roleId);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        //PUT Add player to team
        [HttpPatch("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AddPlayerToTeam(int id, [FromBody] int playerId)
        {
            try
            {
                teamServise.AddPlayer(id, playerId);
                return Ok();
            } catch
            {
                return NotFound();
            }
        }

        // DELETE Delete team
        [HttpDelete("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTeam(int id)
        {
            try
            {
                teamServise.RemoveTeam(id);
                return Ok();
            } catch
            {
                return NotFound();
            }
           
        }
    }
}
