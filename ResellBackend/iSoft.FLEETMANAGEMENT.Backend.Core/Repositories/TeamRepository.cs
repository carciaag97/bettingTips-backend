using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using ResellBackendCore.Database.Dtos.TeamDto;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Repositories
{
    public class TeamRepository:BaseRepository<Team>
    {
        public ResellDbContext _resellDbContext { get; set; }
        public TeamRepository(ResellDbContext resellDbContext) : base(resellDbContext)
        {
            _resellDbContext = resellDbContext;
        }


        public async Task<List<Team>> GetTeamsAsync(string param)
        {
            return await _resellDbContext.Teams
                .Where(team => EF.Functions.Like(team.Name, $"%{param}%")&&!team.IsDeleted)
                .ToListAsync();
        
        }

        public async Task<GetTeamDto> GetTeamDtoAsyncById(int teamId)
        {
            var dto = new GetTeamDto()
            {
                Name = await _resellDbContext.Teams.Where(t => t.Id == teamId).Select(t => t.Name).SingleOrDefaultAsync(),
                Base64Photo= await _resellDbContext.Teams.Where(tm=>tm.Id == teamId).Select(tm=>tm.Base64Photo).SingleOrDefaultAsync()
            };
            return dto;
        }
    }
}
