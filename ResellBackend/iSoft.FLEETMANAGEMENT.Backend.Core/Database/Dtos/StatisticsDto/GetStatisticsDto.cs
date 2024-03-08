using ResellBackendCore.Database.Dtos.CategoryDto;
using ResellBackendCore.Database.Dtos.TicketDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Dtos.StatisticsDto
{
    public class GetStatisticsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalTickets { get; set; }
        public double ResultInCash { get; set; }
        public GetCategoryDtoWithTickets CategoryDto { get; set; }
     
    }
}
