using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApp.Models
{
    [Table("Games")]
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Details { get; set; }

        public DateTime Date { get; set; }

        public int? PlaceId { get; set; }

        public int? TypeId { get; set; }

        public int? TeamId { get; set; }

        public Place Place { get; set; }
        public GamesType Type { get; set; }
        public Team Team { get; set; }
    }
}
