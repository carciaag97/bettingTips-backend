using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using iSoft.FLEETMANAGEMENT.Backend.Core.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Utils
{
    public class JobService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public JobService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var databaseContext = scope.ServiceProvider.GetRequiredService<ResellDbContext>();
                var _unitOfWork = scope.ServiceProvider.GetRequiredService<EfUnitOfWork>();

                await Task.Delay(TimeSpan.FromMinutes(2), stoppingToken);

                var currentTickets = await _unitOfWork._ticketRepository.GetTicketsAsync();

                foreach (var currentTicket in currentTickets)
                {
                    var statistics = await _unitOfWork._statisticsRepository.GetByCategoryIdAsync(currentTicket.CategoryId);

                    if (statistics == null)
                    {
                        statistics = new Statistics { CategoryId = currentTicket.CategoryId };
                        _unitOfWork._statisticsRepository.Add(statistics);
                    }

                    var totalTickets = currentTickets.Count(t => t.CategoryId == currentTicket.CategoryId && (t.StateTypeId == 1 || t.StateTypeId == 3) && t.isActive);
                    var resultInCash = currentTickets.Where(t => t.CategoryId == currentTicket.CategoryId && (t.StateTypeId == 1 || t.StateTypeId == 3) && t.isActive)
                                                     .Sum(t => t.ReturnInCash);

                    statistics.TotalTickets = totalTickets;
                    statistics.ResultInCash = resultInCash;

                    _unitOfWork._statisticsRepository.Update(statistics);
                }

                await _unitOfWork.SaveAsync();
            }
        }
    }


}
