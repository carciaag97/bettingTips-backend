using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Entities
{
    public class Statistics: BaseEntity
    {
        public int TotalTickets { get; set; }
        public double ResultInCash { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
