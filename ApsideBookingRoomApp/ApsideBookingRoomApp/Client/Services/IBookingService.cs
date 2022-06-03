
namespace ApsideBookingRoomApp.Client.Services
{
    public interface IBookingService
    {
        List<Booking> Bookings { get; set; }
        Task GetBookings();
    }
}
