using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomBooking.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;


        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Role>>>> GetRoles()
        {
            var result = await _roleService.GetRoles();
            return Ok(result);
        }
    }
}
