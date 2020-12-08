using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Services.DTO
{
    public class UserDTO
    {
       
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string TShirtSize { get; set; }

        public int? TeamId { get; set; }

        public int? RoleId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public TeamDTO Team { get; set; }

        public RoleDTO Role { get; set; }
    }
}
