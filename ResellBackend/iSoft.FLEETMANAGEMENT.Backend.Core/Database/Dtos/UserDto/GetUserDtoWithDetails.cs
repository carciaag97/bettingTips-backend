using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Dtos.UserDto
{
    public class GetUserDtoWithDetails
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } 

        public ICollection<Ticket> Tickets { get; set; }
        public List<News> News { get; set; }
    }
}
