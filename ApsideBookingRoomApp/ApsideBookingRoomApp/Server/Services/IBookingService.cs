namespace ApsideBookingRoomApp.Server.Services
{
    public interface IBookingService
    {
        Task<ServiceResponse<List<BookingDto>>> GetBookings();
    }
}
