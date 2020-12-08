using ServerApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.BLL.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }

        public string Details { get; set; }

        public DateTime Date { get; set; }

        public int? PlaceId { get; set; }

        public int? TypeId { get; set; }

        public int? TeamId { get; set; }

        public PlaceDTO Place { get; set; }
        public GamesTypeDTO Type { get; set; }
        public TeamDTO Team { get; set; }
    }
}
