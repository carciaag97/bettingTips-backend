using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResellBackendCore.Services;

namespace ResellBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/teams")]
    public class TeamController : BaseController
    {
        public TeamService _teamService { get; set; }
        public TeamController(TeamService teamService)
        {
            _teamService = teamService;
        }


        [HttpGet("list-of-teams")]
        [AllowAnonymous]
        public async Task<ActionResult> GetListOfTeam([FromQuery] string param)
        {
            try
            {
                var result = await _teamService.GetListOfTeamByParam(param);
                return Ok(result);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("get-team-by-id-async")]
        [AllowAnonymous]
        public async Task<ActionResult> GetTeamByIdAsync([FromQuery] int teamId)
        {
            try
            {
                var result = await _teamService.GetTeamById(teamId);
                return Ok(result);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
