namespace MeetingRoomBooking.Server.Services.BookingService
{
    public interface IBookingService
    {
        Task<ServiceResponse<List<BookingDto>>> GetBookings();
        Task<ServiceResponse<BookingDto>> CreateBooking(BookingDto booking);
        Task<ServiceResponse<bool>> DeleteBooking(Guid bookingId);
        Task<ServiceResponse<BookingDto>> UpdateBooking(BookingDto booking);
    }
}
