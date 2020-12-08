using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ServerApp.Models;
using ServerApp.Repositories.Interfaces;

namespace ServerApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext context;
        private GenericRepository<User> userRepository;
        private GenericRepository<Attendance> attendanceRepository;
        private GenericRepository<AttendanceStatus> attendanceStatusRepository;
        private GenericRepository<Game> gameRepository;
        private GenericRepository<GamesType> gamesTypeRepository;
        private GenericRepository<Place> placeRepository;
        private GenericRepository<Role> roleRepository;
        private GenericRepository<Team> teamRepository;
        private bool disposed = false;

        public UnitOfWork(RepositoryContext context)
        {
            this.context = context;
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        public GenericRepository<Attendance> AttendanceRepository
        {
            get
            {
                if (this.attendanceRepository == null)
                {
                    this.attendanceRepository = new GenericRepository<Attendance>(context);
                }
                return attendanceRepository;
            }
        }

        public GenericRepository<AttendanceStatus> AttendanceStatusRepository
        {
            get
            {
                if (this.attendanceStatusRepository == null)
                {
                    this.attendanceStatusRepository = new GenericRepository<AttendanceStatus>(context);
                }
                return attendanceStatusRepository;
            }
        }

        public GenericRepository<Game> GameRepository
        {
            get
            {
                if (this.gameRepository == null)
                {
                    this.gameRepository = new GenericRepository<Game>(context);
                }
                return gameRepository;
            }
        }
        public GenericRepository<GamesType> GamesTypeRepository
        {
            get
            {
                if (this.gamesTypeRepository == null)
                {
                    this.gamesTypeRepository = new GenericRepository<GamesType>(context);
                }
                return gamesTypeRepository;
            }
        }
        public GenericRepository<Place> PlaceRepository
        {
            get
            {
                if (this.placeRepository == null)
                {
                    this.placeRepository = new GenericRepository<Place>(context);
                }
                return placeRepository;
            }
        }
        public GenericRepository<Role> RoleRepository
        {
            get
            {
                if (this.roleRepository == null)
                {
                    this.roleRepository = new GenericRepository<Role>(context);
                }
                return roleRepository;
            }
        }
        public GenericRepository<Team> TeamRepository
        {
            get
            {
                if (this.teamRepository == null)
                {
                    this.teamRepository = new GenericRepository<Team>(context);
                }
                return teamRepository;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

    }
}
