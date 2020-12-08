using ServerApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Services.DTO;
using ServerApp.Repositories.Interfaces;
using ServerApp.Repositories;
using AutoMapper;
using ServerApp.Models;

namespace ServerApp.Services
{
    public class TeamService : ITeamServise
    {
        private bool disposed = false;
        private readonly IMapper _mapper;

        public IUnitOfWork UnitOfWork { get; set; }

        public TeamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.UnitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public IEnumerable<TeamDTO> GetAllTeams()
        {
            IEnumerable<Team> teams = UnitOfWork.TeamRepository.Get();
            return _mapper.Map<IEnumerable<TeamDTO>>(teams);
        }

        public void CreateTeam(TeamDTO teamDTO)
        {
            Team teamEntity = _mapper.Map<Team>(teamDTO);
            UnitOfWork.TeamRepository.Insert(teamEntity);
            UnitOfWork.SaveChanges();
        }
        public void AddPlayer(int teamId, UserDTO userDTO)
        {

        }
        public void RemovePlayer(int teamId, UserDTO userDTO)
        {

        }

        public void RemoveTeam(int teamId)
        {

        }
        public void ChangeTeamName(int teamId, string newTeamName)
        {

        }

        public IEnumerable<UserDTO> GetAllTeamMembers(int teamId)
        {
            return null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
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
