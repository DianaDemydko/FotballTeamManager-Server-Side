using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.BLL.DTO;
using ServerApp.BLL.Interfaces;

namespace ServerApp.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<GameDTO>> GetGames()
        {
            return gameService.GetGames().ToList();
        }

        [HttpPatch("[action]/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateGamePlace(int id, [FromBody] int placeId)
        {
            try
            {
                gameService.ChangePlace(id, placeId);
                return Ok();
            } catch
            {
                return NotFound();
            }

        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateGame([FromBody] GameDTO newGame)
        {
            try
            {
                gameService.CreateGame(newGame);
                return Ok();
            } catch
            {
                return BadRequest();
            }
            
        }

        [HttpDelete("[action]/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteGame(int id)
        {
            try
            {
                gameService.DeleteGame(id);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
    }
}
