using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResellBackendCore.Database.Dtos.TicketDto;
using ResellBackendCore.Services;

namespace ResellBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/ticket")]
    public class TicketController :BaseController
    {
        public TicketService ticketService { get; set; }
        public TicketController(TicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpPost("create-ticket")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> CreateTicket([FromBody] AddTicketDto ticketDto)
        {
            try
            {
                var result = await ticketService.CreateTicket(ticketDto);
                return Ok(result);
            }catch(Exception ex)
            {
                return  BadRequest(ex.Message);
            }
        }

        [HttpPost("get-ticket-by-id")]
        [AllowAnonymous]
        public async Task<ActionResult> GetTicketByIdAsync([FromQuery] int ticketId)
        {
            try
            {
                var result = await ticketService.GetTicketByIdAsync(ticketId);
                return Ok(result);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
