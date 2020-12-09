using AutoMapper;
using ServerApp.BLL.DTO;
using ServerApp.BLL.Interfaces;
using ServerApp.Models;
using ServerApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.BLL
{
    public class GameService: IGameService
    {
        private bool disposed = false;
        private readonly IMapper _mapper;
        public IUnitOfWork UnitOfWork { get; set; }


        public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this.UnitOfWork = unitOfWork;
        }

        public IEnumerable<GameDTO> GetGames()
        {
            return _mapper.Map<IEnumerable<GameDTO>>(UnitOfWork.GameRepository.Get());
        }

        public void CreateGame(GameDTO newGame)
        {
            UnitOfWork.GameRepository.Insert(_mapper.Map<Game>(newGame));
            UnitOfWork.SaveChanges();
        }

        public void ChangePlace(int gameId, int placeId)
        {
            Game gameToUpdate = UnitOfWork.GameRepository.GetByID(gameId);
            gameToUpdate.PlaceId = placeId;
            UnitOfWork.GameRepository.Update(gameToUpdate);
            UnitOfWork.SaveChanges();
        }

        public void DeleteGame(int gameId)
        {
            UnitOfWork.GameRepository.Delete(gameId);
            UnitOfWork.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    UnitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
