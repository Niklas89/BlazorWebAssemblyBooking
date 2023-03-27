using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomBooking.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageRoomController : ControllerBase
    {
        private readonly IImageRoomService _imageRoomService;

        public ImageRoomController(IImageRoomService imageRoomService)
        {
            _imageRoomService = imageRoomService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<RoomDto>>>> GetRooms()
        {
            var result = await _imageRoomService.GetRooms();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<RoomDto>>> CreateRoom(RoomDto room)
        {
            var result = await _imageRoomService.CreateRoom(room);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<RoomDto>>> UpdateRoom(RoomDto room)
        {
            var result = await _imageRoomService.UpdateRoom(room);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteRoom(Guid id)
        {
            var result = await _imageRoomService.DeleteRoom(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
