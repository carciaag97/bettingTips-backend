using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResellBackendCore.Database.Dtos.MatchDto;
using ResellBackendCore.Services;

namespace ResellBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/match")]
    public class MatchController: BaseController
    {
        public MatchService matchService { get; set; }
        public MatchController(MatchService match)
        {
            matchService = match;
        }

        [HttpPost("create-match")]
        [AllowAnonymous]
        public async Task<ActionResult> CreateMatch([FromBody] AddMatchDto addMatchDto)
        {
            try
            {
                var result = await matchService.AddMatch(addMatchDto);
                return Ok(result);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
