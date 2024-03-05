using AutoMapper;
using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using iSoft.FLEETMANAGEMENT.Backend.Core.UnitOfWork;
using ResellBackendCore.Database.Dtos.TicketMatchDto;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Services
{
    public class TicketMatchService
    {
        public EfUnitOfWork efUnitOfWork { get; set; }
        public ResellDbContext resellDbContext { get; set; }
        private readonly IMapper _mapper;

        public TicketMatchService(EfUnitOfWork efUnitOfWork, ResellDbContext resellDbContext, IMapper mapper)
        {
            this.efUnitOfWork = efUnitOfWork;
            this.resellDbContext = resellDbContext;
            _mapper = mapper;
        }

        public async Task<GetTicketMatchDto> CreateTicketMatch(AddTicketMatchDto addTicketMatch)
        {
            var addticket = _mapper.Map<TicketMatch>(addTicketMatch);
            efUnitOfWork._ticketMatchRepository.Add(addticket);
            await efUnitOfWork.SaveAsync();

            var match = await efUnitOfWork._matchRepository.GetMatchByIdAsync(addticket.MatchId);
            var ticket = await efUnitOfWork._ticketRepository.GetTicketByIdAsync(addticket.TicketId);
            ticket.TotalOdd *= match.Odd;
            ticket.ReturnInCash = ticket.TotalOdd * ticket.Stake;

            await efUnitOfWork.SaveAsync();
            
            return _mapper.Map<GetTicketMatchDto>(addticket);
        }
    }
}
