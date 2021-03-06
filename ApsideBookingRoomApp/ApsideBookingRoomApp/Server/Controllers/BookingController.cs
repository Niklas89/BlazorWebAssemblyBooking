
using Microsoft.AspNetCore.Mvc;

namespace ApsideBookingRoomApp.Server.Controllers
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
    }
}
