using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Entities
{
    public class Match : BaseEntity
    {
        public Match()
        {
            Tickets = new List<TicketMatch>();
        }
        public int HomeTeamId {get;set;}
        public Team HomeTeam {get;set;}
        public int AwayTeamId { get;set;}
        public Team AwayTeam { get; set; }
        public string League { get; set; }
        public string Tip { get; set; }
        public double Odd { get; set; }
        public DateTime StartTime { get; set; }
        public List<TicketMatch> Tickets { get; set; }
    }
}
