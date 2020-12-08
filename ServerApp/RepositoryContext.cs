using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ServerApp
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<GamesType> GamesTypes { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<AttendanceStatus> AttendanceStatuses { get; set; }
        public DbSet<Attendance> Attendance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Inital data to Roles table
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "Player"
            }, new Role
            {
                Id = 2,
                Name = "Goal Keeper"
            }, new Role
            {
                Id = 3,
                Name = "Trainer"
            }, new Role
            {
                Id = 4,
                Name = "Legioner"
            }, new Role
            {
                Id = 5,
                Name = "Game Coordinator(Administrator)"
            });

            //Inital data to GamesType table
            modelBuilder.Entity<GamesType>().HasData(new GamesType
            {
                Id = 1,
                Name = "Training with Trainer"
            }, new GamesType
            {
                Id = 2,
                Name = "Training"
            }, new GamesType
            {
                Id = 3,
                Name = "Friend Game"
            }, new GamesType
            {
                Id = 4,
                Name = "League Game"
            });

            //Inital data to AttendanceStatuses table
            modelBuilder.Entity<AttendanceStatus>().HasData(new AttendanceStatus
            {
                Id = 1,
                Name = "Attend"
            }, new AttendanceStatus
            {
                Id = 2,
                Name = "Not Attend"
            }, new AttendanceStatus
            {
                Id = 3,
                Name = "Don't know"
            });

            //Inital data to Users table
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Admin",
                Surname = "Admin",
                Email = "admin@gmail.com",
                RoleId = 5,
                Password = "admin"
            }); ; ;
        }

    }
}
