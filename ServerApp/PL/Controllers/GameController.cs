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
        public void UpdateGamePlace(int id, [FromBody] int placeId)
        {
            gameService.ChangePlace(id, placeId);
        }

        [HttpPost("[action]")]
        public void  CreateGame([FromBody] GameDTO newGame)
        {
            gameService.CreateGame(newGame);
        }

        [HttpDelete("[action]/{id:int}")]
        public void DeleteGame(int id)
        {
            gameService.DeleteGame(id);
        }
    }
}
