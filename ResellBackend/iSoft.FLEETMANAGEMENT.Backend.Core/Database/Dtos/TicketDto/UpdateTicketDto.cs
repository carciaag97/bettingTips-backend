using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Dtos.TicketDto
{
    public class UpdateTicketDto
    {
        public int Id { get; set; }
        public int StateTypeId { get; set; }
    }
}
