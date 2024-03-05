using AutoMapper;
using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using iSoft.FLEETMANAGEMENT.Backend.Core.UnitOfWork;
using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Exceptions;
using ResellBackendCore.Database.Dtos.TeamDto;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Services
{
    public class TeamService
    {
        public EfUnitOfWork efUnitOfWork { get; set; }
        public ResellDbContext resellDbContext { get; set; }
        private readonly IMapper _mapper;

        public TeamService(EfUnitOfWork efUnitOfWork, ResellDbContext resellDbContext, IMapper mapper)
        {
            this.efUnitOfWork = efUnitOfWork;
            this.resellDbContext = resellDbContext;
            _mapper = mapper;
        }

        public async Task<List<Team>> GetListOfTeamByParam(string param)
        {
            var team =await efUnitOfWork._teamRepository.GetTeamsAsync(param);
            if(team == null)
            {
                throw new WrongInputException("Nu exista echipe in baza");
            }
            return team;
        }

        public async Task<GetTeamDto> GetTeamById(int teamId)
        {
            var team = await efUnitOfWork._teamRepository.GetTeamDtoAsyncById(teamId);
            return _mapper.Map<GetTeamDto>(team);
        }

    }
}
