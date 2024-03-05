using AutoMapper;
using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using iSoft.FLEETMANAGEMENT.Backend.Core.UnitOfWork;
using ResellBackendCore.Database.Dtos.MatchDto;
using ResellBackendCore.Database.Dtos.TicketDto;
using ResellBackendCore.Database.Dtos.TicketMatchDto;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Services
{
    public class TicketService
    {
        public EfUnitOfWork efUnitOfWork { get; set; }
        public ResellDbContext resellDbContext { get; set; }
        private readonly IMapper _mapper;

        public TicketService(EfUnitOfWork efUnitOfWork, ResellDbContext resellDbContext, IMapper mapper)
        {
            this.efUnitOfWork = efUnitOfWork;
            this.resellDbContext = resellDbContext;
            _mapper = mapper;
        }


        public async Task<GetTicketDto> CreateTicket(AddTicketDto addticket)
        {
            var ticket = _mapper.Map<Ticket>(addticket);
            efUnitOfWork._ticketRepository.Add(ticket);
            await efUnitOfWork.SaveAsync();
            return  _mapper.Map<GetTicketDto>(ticket);
            
        }

        public async Task<GetTicketDto> GetTicketByIdAsync(int ticketId)
        {
            var ticket = await efUnitOfWork._ticketRepository.GetTicketWithMatchesAsync(ticketId);

            var ticketDto = new GetTicketDto
            {
                // Maparea directă a proprietăților fără a utiliza _mapper
                Title = ticket.Title,
                Description = ticket.Description,
                TotalOdd = ticket.TotalOdd,
                StateTypeId = ticket.StateTypeId,
                ReturnInCash = ticket.ReturnInCash,
                Stake = ticket.Stake,
                isActive = ticket.isActive,
                UserId = ticket.UserId,
                CategoryId = ticket.CategoryId,
                // Maparea listei Matches utilizând o expresie lambda
                Matches = ticket.Matches.Select(tm => new ListTicketMatchDto
                {
                    MatchId = tm.MatchId,
                    Match = new GetMatchDto
                    {
                        Id = tm.Match.Id,
                        HomeTeamId = tm.Match.HomeTeamId,
                        AwayTeamId = tm.Match.AwayTeamId,
                        League = tm.Match.League,
                        Tip = tm.Match.Tip,
                        Odd = tm.Match.Odd,
                        StartTime = tm.Match.StartTime
                    }
                }).ToList()
            };

            return ticketDto;
        }
    }
}
