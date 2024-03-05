using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using ResellBackendCore.Database.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Entities
{
    public class News: BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LinkPhoto { get; set; }
        public string OtherLink { get; set; }
        public int NewsTypeId { get; set; }
    }
}
