using ResellBackendCore.Database.Dtos.TicketDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Dtos.CategoryDto
{
    public class GetCategoryDtoWithTickets
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<GetTicketDto> Tickets { get; set; }
    }
}
