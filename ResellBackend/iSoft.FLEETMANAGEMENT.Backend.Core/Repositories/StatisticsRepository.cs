using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Repositories
{
    public class StatisticsRepository : BaseRepository<Statistics>
    {
        public ResellDbContext _resellDbContext { get; set; }
        public StatisticsRepository(ResellDbContext resellDbContext) : base(resellDbContext)
        {
            _resellDbContext = resellDbContext;
        }

        public async Task<Statistics> GetStatisticsWithMatchingTicketsAsync(int statisticsId)
        {
            var statistics = await _resellDbContext.Statistics
                .Include(s => s.Category)
                    .ThenInclude(c => c.Tickets)
                .FirstOrDefaultAsync(s => s.Id == statisticsId);

            if (statistics != null)
            {
                statistics.Category.Tickets = statistics.Category.Tickets
                    .Where(t => (t.StateTypeId == 1 || t.StateTypeId == 3) && t.isActive)
                    .ToList();
            }

            return statistics;
        }

        public async Task<Statistics> GetByCategoryIdAsync(int categoryId)
        {
            return await _resellDbContext.Statistics
                .Where(s => s.CategoryId == categoryId)
                .FirstOrDefaultAsync();
        }


    }
}
