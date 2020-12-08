using ServerApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.BLL.DTO
{
    public class AttendanceDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int GameId { get; set; }
        public int AttendanceStatusId { get; set; }

        public UserDTO User { get; set; }
        public GameDTO Game { get; set; }

        public AttendanceStatusDTO AttendanceStatus { get; set; }
    }
}
