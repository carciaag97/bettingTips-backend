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
    public class MatchRepository:BaseRepository<Match>
    {
        public ResellDbContext _resellDbContext { get; set; }
        public MatchRepository(ResellDbContext resellDbContext) : base(resellDbContext)
        {
            _resellDbContext = resellDbContext;
        }

        public async Task<Match> GetMatchByIdAsync(int matchId)
        {
            var result = await _resellDbContext.Matches
                .Where(t => t.Id == matchId)
                .SingleOrDefaultAsync();
            return result;
        }
    }
}
