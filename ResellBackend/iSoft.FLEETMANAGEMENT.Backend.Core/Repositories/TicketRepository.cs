using AutoMapper;
using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using ResellBackendCore.Database.Dtos.TicketDto;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>
    {
        private readonly IMapper _mapper;

        public ResellDbContext _resellDbContext { get; set; }
        public TicketRepository(ResellDbContext resellDbContext,IMapper mapper) : base(resellDbContext)
        {
            _resellDbContext = resellDbContext;
            _mapper = mapper;
        }

        public async Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            var result = await _resellDbContext.Tickets
                .Where(t => t.Id == ticketId)
                .SingleOrDefaultAsync();
            return result;
        }

        public async Task<Ticket> GetTicketWithMatchesAsync(int ticketId)
        {
            var ticket = await _resellDbContext.Tickets
                .Include(t => t.User)
                .Include(t => t.Category)
                .Include(t => t.Matches)
                    .ThenInclude(tm => tm.Match)
                .FirstOrDefaultAsync(t => t.Id == ticketId);

            return ticket;
        }



    }
}
