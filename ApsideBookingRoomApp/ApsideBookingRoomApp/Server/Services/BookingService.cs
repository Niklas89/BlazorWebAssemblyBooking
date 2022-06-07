namespace ApsideBookingRoomApp.Server.Services
{
    public class BookingService : IBookingService
    {
        private readonly DataContext _context;

        public BookingService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<BookingDto>>> GetBookings()
        {
            var bookings = await _context.Bookings.Select(b => new BookingDto
            {
                IdBooking = b.IdBooking,
                Subject = b.Subject,
                StartDate = b.StartDate,
                EndDate = b.EndDate,
                Comment = b.Comment,
                IdRoom = b.IdRoom,
                IsAllDay = false,
                RecurrenceRule = "",
                RecurrenceExceptions = new List<DateTime>(),
                RecurrenceId = Guid.NewGuid()
        }).ToListAsync();
            return new ServiceResponse<List<BookingDto>>
            {
                Data = bookings
            };

        }

        public async Task<ServiceResponse<BookingDto>> CreateBooking(BookingDto booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return new ServiceResponse<BookingDto> { Data = booking };
        }
    }
}
