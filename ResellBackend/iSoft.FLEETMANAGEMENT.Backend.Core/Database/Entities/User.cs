using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Entities
{
    public class User:BaseEntity
    {
        public User()
        {
            Tickets= new List<Ticket>();
            News = new List<News>();
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } = "Admin";

        public ICollection<Ticket> Tickets { get; set; }
        public List<News> News { get; set; }
    }
}
