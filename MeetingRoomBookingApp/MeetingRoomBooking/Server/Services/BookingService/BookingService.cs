namespace MeetingRoomBooking.Server.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly BookingRoomContext _context;

        public BookingService(BookingRoomContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<BookingDto>>> GetBookings()
        {
            List<BookingDto> bookings = new List<BookingDto>();

            bookings = await _context.Bookings.Select(b => new BookingDto
            {
                Id = b.Id,
                Subject = b.Subject,
                StartDate = b.StartDate,
                EndDate = b.EndDate,
                Comment = b.Comment,
                CreationUserId = b.CreationUserId,
                ModificationUserId = b.ModificationUserId,
                CreationDate = b.CreationDate,
                ModificationDate = b.ModificationDate,
                NameRoom = b.IdRoomNavigation.Name,
                CapacityRoom = b.IdRoomNavigation.Capacity,
                IdRoom = b.IdRoom,
                IsAllDay = b.IsAllDay,
                RecurrenceId = b.RecurrenceId,
                RecurrenceRule = b.RecurrenceRule,
                RecurrenceExceptions = b.RecurrenceExceptions,
                NameUser = b.CreationUser.FullName,
                MailUser = b.CreationUser.Mail
            }).ToListAsync();
            Console.WriteLine(bookings);
            return new ServiceResponse<List<BookingDto>>
            {
                Data = bookings
            };

        }


        public async Task<ServiceResponse<BookingDto>> CreateBooking(BookingDto booking)
        {
            Booking book = new Booking
            {
                Subject = booking.Subject,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Comment = booking.Comment,
                CreationUserId = booking.CreationUserId,
                ModificationUserId = booking.ModificationUserId,
                CreationDate = booking.CreationDate,
                ModificationDate = booking.ModificationDate,
                IsAllDay = booking.IsAllDay,
                RecurrenceId = booking.RecurrenceId,
                RecurrenceRule = booking.RecurrenceRule,
                RecurrenceExceptions = booking.RecurrenceExceptions,
                IdRoom = booking.IdRoom,
            };

            _context.Bookings.Add(book);
            await _context.SaveChangesAsync();

            return new ServiceResponse<BookingDto> { Data = booking };
        }

        public async Task<ServiceResponse<bool>> DeleteBooking(Guid bookingId)
        {
            var dbBooking = await _context.Bookings.FindAsync(bookingId);
            if (dbBooking == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Booking not found."
                };
            }

            _context.Bookings.Remove(dbBooking);

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<BookingDto>> UpdateBooking(BookingDto booking)
        {
            // Select the booking field from the database (dbBooking) that corresponds to the booking I want to update
            var dbBooking = await _context.Bookings.FirstOrDefaultAsync(p => p.Id == booking.Id);

            if (dbBooking == null)
            {
                return new ServiceResponse<BookingDto>
                {
                    Success = false,
                    Message = "No reservation found in the database"
                };
            }

            // Select only the fields from the database that we need to update
            dbBooking.Subject = booking.Subject;
            dbBooking.StartDate = booking.StartDate;
            dbBooking.EndDate = booking.EndDate;
            dbBooking.Comment = booking.Comment;
            dbBooking.ModificationUserId = booking.ModificationUserId;
            dbBooking.ModificationDate = booking.ModificationDate;
            dbBooking.IsAllDay = booking.IsAllDay;
            dbBooking.IdRoom = booking.IdRoom;
            dbBooking.RecurrenceId = booking.RecurrenceId;
            dbBooking.RecurrenceRule = booking.RecurrenceRule;
            dbBooking.RecurrenceExceptions = booking.RecurrenceExceptions;

            _context.Bookings.Update(dbBooking);
            await _context.SaveChangesAsync();

            return new ServiceResponse<BookingDto> { Data = booking };
        }
    }
}
