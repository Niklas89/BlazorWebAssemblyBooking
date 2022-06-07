
namespace ApsideBookingRoomApp.Client.Services
{
    public interface IBookingService
    {
        List<BookingDto> Bookings { get; set; }
        Task GetBookings();
        Task GetBookingsClient();
        Task<BookingDto> Create(BookingDto itemToInsert);
        Task<List<BookingDto>> Read();
        Task Update(BookingDto itemToUpdate);
        Task Delete(BookingDto itemToDelete);

    }
}
