
namespace ApsideBookingRoomApp.Client.Services
{
    public interface IBookingService
    {
        List<BookingDto> Bookings { get; set; }
        Task GetBookings();
    }
}
