using ServerApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.BLL.Interfaces
{
    public interface IGameService : IDisposable
    {
        void CreateGame(GameDTO game);
        void ChangePlace(int gameId, int placeId);
        IEnumerable<GameDTO> GetGames();

        void DeleteGame(int gameId);
    }
}
