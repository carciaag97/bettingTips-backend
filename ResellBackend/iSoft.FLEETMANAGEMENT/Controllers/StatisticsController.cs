using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResellBackendCore.Database.Dtos.StatisticsDto;
using ResellBackendCore.Services;

namespace ResellBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/statistics")]
    public class StatisticsController:BaseController
    {
        public StatisticsService _statisticsService { get; set; }

        public StatisticsController(StatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpPost("create-statistics")]
        [AllowAnonymous]
        public async Task<ActionResult> CreateStatistics([FromBody] AddStatisticsDto addStatisticsDto)
        {
            try {
                var result = await _statisticsService.CreateStatistics(addStatisticsDto);
                return Ok(result);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpGet("get-statistics-byId")]
        [AllowAnonymous]
        public async Task<ActionResult> GetStatisticsById([FromQuery] int statisticsId)
        {
            try
            {
                var result = await _statisticsService.GetStatisticsWithMatchingTicketsAsync(statisticsId);
                return Ok(result);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
