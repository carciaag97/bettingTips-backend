using ResellBackendCore.Database.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Dtos.TicketDto
{
    public class AddTicketDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Stake { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
