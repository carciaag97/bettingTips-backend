using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using ResellBackendCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.FLEETMANAGEMENT.Backend.Core.UnitOfWork
{
    public class EfUnitOfWork
    {
        private ResellDbContext _context;

        public CategoryRepository _categoryRepository { get; set; }
        public MatchRepository _matchRepository { get; set; }
        public NewsRepository _newsRepository { get; set; }
        public StatisticsRepository _statisticsRepository { get; set; }
        public TeamRepository _teamRepository { get; set; }
        public TicketRepository _ticketRepository { get; set; }
        public UserRepository _userRepository { get; set; }
        public TicketMatchRepository _ticketMatchRepository { get; set; }


        public EfUnitOfWork(
    
         CategoryRepository categoryRepository,
         MatchRepository matchRepository,
         NewsRepository newsRepository,
         StatisticsRepository statisticsRepository,
         TeamRepository teamRepository,
         TicketRepository ticketRepository,
         ResellDbContext context,
         UserRepository userRepository,
         TicketMatchRepository ticketMatchRepository)
        {
            _categoryRepository = categoryRepository;
            _matchRepository = matchRepository;
            _newsRepository = newsRepository;
            _statisticsRepository = statisticsRepository;
            _teamRepository = teamRepository;
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
            _context = context;
            _ticketMatchRepository = ticketMatchRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
