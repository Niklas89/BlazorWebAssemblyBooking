namespace ApsideBookingRoomApp.Server.Services
{
    public class BookingService : IBookingService
    {
        private readonly DataContext _context;

        public BookingService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Booking>>> GetBookings()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return new ServiceResponse<List<Booking>>
            {
                Data = bookings
            };

        }
    }
}
