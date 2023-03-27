using Microsoft.AspNetCore.Mvc;


namespace MeetingRoomBooking.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase

    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<UserDto>>>> GetUsers()
        {
            var result = await _userService.GetUsers();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<UserDto>>> CreateUser(UserDto user)
        {
            var result = await _userService.CreateUser(user);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteUser(Guid id)
        {
            var result = await _userService.DeleteUser(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<UserDto>>> UpdateUser(UserDto user)
        {
            var result = await _userService.UpdateUser(user);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }


}