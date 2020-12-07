using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApp.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "User name is required")]
        [StringLength(60, ErrorMessage = "User name cannot be longer that 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "User surname is required")]
        [StringLength(150, ErrorMessage = "User surname cannot be longer that 150 characters")]
        public string Surname { get; set; }

        public string TShirtSize { get; set; }

        public int? TeamId { get; set; }

        public int? RoleId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Team Team { get; set; }

        public Role Role { get; set; }
    }
}
