using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Entities
{
    public class Photo:BaseEntity
    {
        public string PhotoPath { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
