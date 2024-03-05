using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using ResellBackendCore.Database.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Entities
{
    public class Ticket:BaseEntity
    {
        public Ticket()
        {
            Matches = new List<TicketMatch>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public double TotalOdd { get; set; } = 1;
        public int StateTypeId { get; set; } = 2;
        public double ReturnInCash { get; set; } = 1;
        public double Stake { get; set; }
        public bool isActive { get; set; } = false;
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<TicketMatch> Matches { get; set; }
        
    }
}
