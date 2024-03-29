﻿using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Entities
{
    public class Category:BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public Statistics Statistics { get; set; }
    }
}
