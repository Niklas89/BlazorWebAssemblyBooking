using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomBooking.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BookingDto>>>> GetBookings()
        {
            var result = await _bookingService.GetBookings();
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<BookingDto>>> CreateBooking(BookingDto booking)
        {
            var result = await _bookingService.CreateBooking(booking);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteBooking(Guid id)
        {
            var result = await _bookingService.DeleteBooking(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<BookingDto>>> UpdateBooking(BookingDto booking)
        {
            var result = await _bookingService.UpdateBooking(booking);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
