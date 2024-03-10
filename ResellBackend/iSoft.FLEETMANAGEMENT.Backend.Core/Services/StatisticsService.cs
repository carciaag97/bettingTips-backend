using AutoMapper;
using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using iSoft.FLEETMANAGEMENT.Backend.Core.UnitOfWork;
using ResellBackendCore.Database.Dtos.CategoryDto;
using ResellBackendCore.Database.Dtos.StatisticsDto;
using ResellBackendCore.Database.Dtos.TicketDto;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Services
{
    public class StatisticsService
    {
        public EfUnitOfWork efUnitOfWork { get; set; }
        public ResellDbContext resellDbContext { get; set; }
        private readonly IMapper _mapper;

        public StatisticsService(EfUnitOfWork efUnitOfWork, ResellDbContext resellDbContext, IMapper mapper)
        {
            this.efUnitOfWork = efUnitOfWork;
            this.resellDbContext = resellDbContext;
            _mapper = mapper;
        }

        public async Task<GetCategoryDtoWithTickets> CreateStatistics(AddStatisticsDto addStatisticsDto)
        {
            var statistics = _mapper.Map<Statistics>(addStatisticsDto);
            efUnitOfWork._statisticsRepository.Add(statistics);
            await efUnitOfWork.SaveAsync();
            return _mapper.Map<GetCategoryDtoWithTickets>(statistics);
        }

        public async Task<GetStatisticsDto> GetStatisticsWithMatchingTicketsAsync(int statisticsId)
        {
            var statistics = await efUnitOfWork._statisticsRepository.GetStatisticsWithMatchingTicketsAsync(statisticsId);

            var statisticsDto = new GetStatisticsDto
            {
                Id = statistics.Id,
                Title = statistics.Title,
                TotalTickets = statistics.TotalTickets,
                ResultInCash = statistics.ResultInCash,
                CategoryDto = _mapper.Map<GetCategoryDtoWithTickets>(statistics.Category)
            };

       
            statisticsDto.CategoryDto.Tickets = statistics.Category.Tickets
                .Select(ticket => _mapper.Map<GetTicketDto>(ticket)).ToList();

            return statisticsDto;
        }



    }
}
