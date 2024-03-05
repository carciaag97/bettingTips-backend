using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResellBackendCore.Database.Dtos.TicketMatchDto;
using ResellBackendCore.Services;

namespace ResellBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/ticketmatch")]
    public class TicketMatchController:BaseController
    {
        public TicketMatchService _ticketmatchService { get; set; }
        public TicketMatchController(TicketMatchService ticketMatchService)
        {
            _ticketmatchService = ticketMatchService;
        }


        [HttpPost("add-match-to-ticket")]
        [AllowAnonymous]
        public async Task<ActionResult> AddTicketMatch([FromBody] AddTicketMatchDto addDto)
        {
            try
            {
                var result = await _ticketmatchService.CreateTicketMatch(addDto);
                return Ok(result);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
