
namespace ApsideBookingRoomApp.Client.Services
{
    public interface IBookingService
    {
        List<BookingDto> Bookings { get; set; }
        event Action BookingsChanged;
        Task GetBookings();
        Task GetBookingsClient();
        Task Create(BookingDto booking);
        Task<List<BookingDto>> Read();
        Task Update(BookingDto itemToUpdate);
        Task Delete(BookingDto itemToDelete);

    }
}
