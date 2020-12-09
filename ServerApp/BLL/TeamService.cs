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
        public void AddPlayer(int teamId, int userId)
        {
            User userToUpdate = UnitOfWork.UserRepository.GetByID(userId);
            userToUpdate.TeamId = teamId;
            UnitOfWork.UserRepository.Update(userToUpdate);
            UnitOfWork.SaveChanges();
        }
        public void RemovePlayer(int userId)
        {
            User userToUpdate = UnitOfWork.UserRepository.GetByID(userId);
            userToUpdate.TeamId = null;
            UnitOfWork.UserRepository.Update(userToUpdate);
            UnitOfWork.SaveChanges();
        }

        public void RemoveTeam(int teamId)
        {
            UnitOfWork.TeamRepository.Delete(teamId);
            UnitOfWork.SaveChanges();
        }
        public void ChangeTeamName(int teamId, string newTeamName)
        {
            Team teamToUpdate = UnitOfWork.TeamRepository.GetByID(teamId);
            teamToUpdate.Name = newTeamName;
            UnitOfWork.TeamRepository.Update(teamToUpdate);
            UnitOfWork.SaveChanges();
        }

        public IEnumerable<UserDTO> GetAllTeamMembers(int teamId)
        {
            IEnumerable<User> users = UnitOfWork.UserRepository.Get(item => item.TeamId == teamId, null, "Team,Role");

            return _mapper.Map<IEnumerable<UserDTO>>(users);
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
