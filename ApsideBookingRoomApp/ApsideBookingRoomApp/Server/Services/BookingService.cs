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

        
        public async Task<ServiceResponse<BookingDto>> CreateBooking(BookingDto bookingDto)
        {
            Booking booking = new Booking { Subject = bookingDto.Subject,
                StartDate = bookingDto.StartDate,
                EndDate = bookingDto.EndDate,
                Comment = bookingDto.Comment,
                // RowVersion = null,
                RowVersion = System.Text.Encoding.UTF8.GetBytes("0x00000000000007ED"),
                CreationUserId = Guid.Parse("A57C8CE4-A0F1-485D-9A67-1D3D5E64D765"),
                ModificationUserId = Guid.Parse("A57C8CE4-A0F1-485D-9A67-1D3D5E64D765"),
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                IdRoom = Guid.Parse("E665736C-35C2-419F-8A52-2F93A4C5231A"),
            };
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            //return await GetBookings();

            return new ServiceResponse<BookingDto> { Data = bookingDto };
        } 
    }
}
