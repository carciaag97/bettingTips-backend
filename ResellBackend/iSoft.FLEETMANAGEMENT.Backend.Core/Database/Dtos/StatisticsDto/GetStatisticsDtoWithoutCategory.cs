﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Dtos.StatisticsDto
{
    public class GetStatisticsDtoWithoutCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalTickets { get; set; }
        public double ResultInCash { get; set; }
        public int CategoryId { get; set; }
    }
}
