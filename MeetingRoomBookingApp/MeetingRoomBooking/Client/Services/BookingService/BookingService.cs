namespace MeetingRoomBooking.Client.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _http;

        public BookingService(HttpClient http)
        {
            _http = http;
        }
        public List<BookingDto> Bookings { get; set; } = new List<BookingDto>();
        public string Message { get; set; } = "Loading of bookings on the calendar...";

        // Get all bookings corresponding to the selected room
        public async Task GetBookings(Guid roomId)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<BookingDto>>>("api/Booking");
            if (response != null && response.Data != null)
                Bookings = response.Data.Where(b => b.IdRoom.Equals(roomId)).ToList();
        }

        // Add a new booking 
        public async Task CreateBooking(BookingDto booking, Guid selectedRoomId, string roomName, int capacityRoom)
        {
            
            var book = new BookingDto
            {
                Subject = booking.Subject,
                StartDate = DateTime.Parse(booking.StartDate.ToString("yyyy MM dd, HH:mm")),
                EndDate = DateTime.Parse(booking.EndDate.ToString("yyyy MM dd, HH:mm")),
                Comment = booking.Comment,
                CreationUserId = Guid.Parse("B444AE48-1CF9-EC11-A843-00155DFF5915"),
                ModificationUserId = Guid.Parse("B444AE48-1CF9-EC11-A843-00155DFF5915"),
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                NameRoom = roomName,
                CapacityRoom = capacityRoom,
                IdRoom = selectedRoomId,
                IsAllDay = booking.IsAllDay,
                RecurrenceId = string.IsNullOrEmpty(booking.RecurrenceRule) ? null : Guid.NewGuid(),
                RecurrenceRule = string.IsNullOrEmpty(booking.RecurrenceRule) ? null : booking.RecurrenceRule,
                RecurrenceExceptions = string.IsNullOrEmpty(booking.RecurrenceExceptions) ? null : booking.RecurrenceExceptions,
                NameUser = "Niklas",
                MailUser = "niklas@email.com"
            };

            HttpResponseMessage response = await _http.PostAsJsonAsync("api/booking", book);
        }

        // Update existing booking
        public async Task UpdateBooking(BookingDto booking)
        {
            var book = new BookingDto
            {
                Id = booking.Id,
                Subject = booking.Subject,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Comment = booking.Comment,
                CreationUserId = booking.CreationUserId,
                ModificationUserId = booking.ModificationUserId,
                CreationDate = booking.CreationDate,
                ModificationDate = DateTime.Now,
                IsAllDay = booking.IsAllDay,
                RecurrenceId = string.IsNullOrEmpty(booking.RecurrenceRule) ? null : booking.RecurrenceId != null ? booking.RecurrenceId : Guid.NewGuid(),
                RecurrenceRule = string.IsNullOrEmpty(booking.RecurrenceRule) ? null : booking.RecurrenceRule,
                RecurrenceExceptions = string.IsNullOrEmpty(booking.RecurrenceExceptions) ? null : booking.RecurrenceExceptions,
                IdRoom = booking.IdRoom,
                NameRoom = booking.NameRoom,
                CapacityRoom = booking.CapacityRoom,
                NameUser = booking.NameUser,
                MailUser = booking.MailUser
            };

            var result = await _http.PutAsJsonAsync($"api/booking", book);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<BookingDto>>();

        }

        // Using the BookingEditor component with custom window opener: same method for add and update
        public async Task SaveBooking(BookingDto booking, Guid selectedRoomId, string roomName, int capacityRoom)
        {
            var matchingItem = Bookings.Find(a => a.Id == booking.Id);

            if (matchingItem != null)
                await UpdateBooking(booking);
            else
                await CreateBooking(booking, selectedRoomId, roomName, capacityRoom);
        }

        // Delete booking from the database and from the list of bookings on the client side
        public async Task DeleteBooking(BookingDto booking)
        {

            var result = await _http.DeleteAsync($"api/booking/{booking.Id}");

            // Remove the booking from the list of bookings locally
            var target = Bookings.FirstOrDefault(a => a.Id == booking.Id);
            if (target != null)
            {
                Bookings.Remove(target);
            }

            

        }
    }
}
