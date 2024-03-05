using ResellBackendCore.Database.Dtos.MatchDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Dtos.TicketMatchDto
{
    public class ListTicketMatchDto
    {
        public int MatchId { get; set; }
        public GetMatchDto Match { get; set; }
    }
}
