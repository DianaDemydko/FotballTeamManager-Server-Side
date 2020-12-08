using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Models;
using ServerApp.Services.DTO;
using ServerApp.BLL.DTO;

namespace ServerApp
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<RoleDTO, Role>();
            CreateMap<Role, RoleDTO>();
            CreateMap<TeamDTO, Team>();
            CreateMap<Team, TeamDTO>();
            CreateMap<AttendanceStatus, AttendanceStatusDTO>();
            CreateMap<AttendanceStatusDTO, AttendanceStatus>();
            CreateMap<Attendance, AttendanceDTO>();
            CreateMap<AttendanceDTO, Attendance>();
            CreateMap<Game, GameDTO>();
            CreateMap<GameDTO, Game>();
            CreateMap<Place, PlaceDTO>();
            CreateMap<PlaceDTO, Place>();
            CreateMap<GamesType, GamesTypeDTO>();
            CreateMap<GamesTypeDTO, GamesType>();
        }
    }
}
