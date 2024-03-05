using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResellBackendCore.Database.Dtos.UserDto;
using ResellBackendCore.Services;

namespace ResellBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/users")]
    public class UserController: BaseController
    {
        public UserService _userService { get; set; }
        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [AllowAnonymous]
        [HttpPost("create-user")]
        public async Task<ActionResult> CreateUser([FromBody] AddUserDto user)
        {
            try
            {
                var result =await _userService.AddUser(user);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [AllowAnonymous]
        [HttpGet("get-user-byId")]
        public async Task<ActionResult> GetUserById([FromQuery] int userId)
        {
            try
            {
                var result = await _userService.GetUserDtoByIdAsync(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("delete-user-byId")]
        public async Task<ActionResult> DeleteUserById([FromQuery] int userId)
        {
            try
            {
                await _userService.DeleteUserAsync(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
