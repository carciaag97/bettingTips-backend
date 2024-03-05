using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Dtos.MatchDto
{
    public class GetMatchDto
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string League { get; set; }
        public string Tip { get; set; }
        public double Odd { get; set; }
        public DateTime StartTime { get; set; }
    }
}
