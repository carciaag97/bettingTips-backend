using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Entities
{
    public class Team:BaseEntity
    {
        public string Name { get; set; }
        public string Base64Photo { get; set; }
    }
}
