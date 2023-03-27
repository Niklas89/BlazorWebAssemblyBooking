namespace MeetingRoomBooking.Client.Services.BookingService
{
    public interface IBookingService
    {
        List<BookingDto> Bookings { get; set; }
        string Message { get; set; }

        Task GetBookings(Guid roomId);
        Task CreateBooking(BookingDto booking, Guid selectedRoomId, string roomName, int capacityRoom);
        Task UpdateBooking(BookingDto booking);
        Task DeleteBooking(BookingDto booking);
        
        // Using the BookingEditor component with custom window opener: same method for add and update
        Task SaveBooking(BookingDto booking, Guid selectedRoomId, string roomName, int capacityRoom);
    }
}
