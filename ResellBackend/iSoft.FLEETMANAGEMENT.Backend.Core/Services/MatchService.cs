using AutoMapper;
using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using iSoft.FLEETMANAGEMENT.Backend.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResellBackendCore.Database.Dtos.MatchDto;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Services
{
    public class MatchService
    {
        public EfUnitOfWork _efUnitOfWork { get; set; }
        public ResellDbContext _resellDbContext { get; set; }
        private readonly IMapper _mapper;
        private readonly ILogger<MatchService> _logger;

        public MatchService(EfUnitOfWork efUnitOfWork, ResellDbContext resellDbContext, IMapper mapper,ILogger<MatchService> logger)
        {
            _efUnitOfWork = efUnitOfWork;
            _resellDbContext = resellDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetMatchDto> AddMatch(AddMatchDto addmatch)
        {
            try
            {
                var match = _mapper.Map<Match>(addmatch);
                _efUnitOfWork._matchRepository.Add(match);
                await _efUnitOfWork.SaveAsync();
                return _mapper.Map<GetMatchDto>(match);
            }
            catch (Exception ex)
            {  
                _logger.LogError(ex, "O eroare a apărut în timpul adăugării unui meci.");
                throw;
            }
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
