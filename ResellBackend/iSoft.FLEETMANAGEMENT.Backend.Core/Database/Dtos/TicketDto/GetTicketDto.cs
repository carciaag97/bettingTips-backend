using ResellBackendCore.Database.Dtos.TicketMatchDto;
using ResellBackendCore.Database.Entities;
using ResellBackendCore.Database.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Dtos.TicketDto
{
    public class GetTicketDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double TotalOdd { get; set; }
        public int StateTypeId { get; set; }
        public double ReturnInCash { get; set; }
        public double Stake { get; set; }
        public bool isActive { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public List<ListTicketMatchDto> Matches { get; set; }
    }
}
