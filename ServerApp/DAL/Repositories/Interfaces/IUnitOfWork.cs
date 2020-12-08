using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Models;

namespace ServerApp.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<User> UserRepository { get; }
        GenericRepository<Attendance> AttendanceRepository { get; }
        GenericRepository<AttendanceStatus> AttendanceStatusRepository { get; }
        GenericRepository<Game> GameRepository { get; }
        GenericRepository<GamesType> GamesTypeRepository { get; }
        GenericRepository<Place> PlaceRepository { get; }
        GenericRepository<Team> TeamRepository { get; }
        GenericRepository<Role> RoleRepository { get; }

        void SaveChanges();
    }
}
