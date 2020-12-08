using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApp.Models
{
    [Table("Attendance")]
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int GameId { get; set; }
        public int AttendanceStatusId { get; set; }

        public User User { get; set; }
        public Game Game { get; set; }

        public AttendanceStatus AttendanceStatus { get; set; }
    }
}
