
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomBooking.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Room>>>> GetRooms()
        {
            var result = await _roomService.GetRooms();
            return Ok(result);
        }
    }
}
