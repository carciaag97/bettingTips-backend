using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Entities
{
    public class TicketMatch:BaseEntity
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
    }
}
