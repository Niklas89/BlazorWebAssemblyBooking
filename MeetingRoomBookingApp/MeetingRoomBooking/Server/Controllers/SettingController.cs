using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomBooking.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Setting>>>> GetSettings()
        {
            var result = await _settingService.GetSettings();
            return Ok(result);
        }
    }
}
