
namespace ApsideBookingRoomApp.Client.Services
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _http;

        public BookingService(HttpClient http)
        {
            _http = http;
        }
        public List<BookingDto> Bookings { get; set; } = new List<BookingDto>();
        public event Action BookingsChanged;

        public async Task GetBookings()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<BookingDto>>>("api/Booking");
            if (response != null && response.Data != null)
                Bookings = response.Data;
        }

        public async Task GetBookingsClient()
        {
            Bookings = await Read();
        }

        public async Task Create(BookingDto booking)
        {
            var book = new BookingDto
            {
                IdBooking = Guid.NewGuid(),
                Subject = booking.Subject,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Comment = booking.Comment,
                // RowVersion = null,
                RowVersion = System.Text.Encoding.UTF8.GetBytes("0x00000000000007ED"),
                CreationUserId = Guid.Parse("A57C8CE4-A0F1-485D-9A67-1D3D5E64D765"),
                ModificationUserId = Guid.Parse("A57C8CE4-A0F1-485D-9A67-1D3D5E64D765"),
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                IdRoom = Guid.Parse("E665736C-35C2-419F-8A52-2F93A4C5231A"),
            };

            HttpResponseMessage response = await _http.PostAsJsonAsync("api/booking", book);
            //var newBooking = (await response.Content.ReadFromJsonAsync<ServiceResponse<BookingDto>>()).Data;
            //return newBooking;

            var data = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<BookingDto>>>()).Data;
            
            
            await GetBookings();

            BookingsChanged.Invoke();
            //Bookings.Insert(0, itemToInsert);
        }

        public async Task<List<BookingDto>> Read()
        {
            return await Task.FromResult(Bookings);
        }

        public async Task Update(BookingDto itemToUpdate)
        {
            var index = Bookings.FindIndex(i => i.IdBooking == itemToUpdate.IdBooking);
            if (index != -1)
            {
                Bookings[index] = itemToUpdate;
            }
        }

        public async Task Delete(BookingDto itemToDelete)
        {
            if (itemToDelete.RecurrenceId != null)
            {
                // a recurrence exception was deleted, you may want to update
                // the rest of the data source - find an item where theItem.Id == itemToDelete.RecurrenceId
                // and remove the current exception date from the list of its RecurrenceExceptions
            }

            if (!string.IsNullOrEmpty(itemToDelete.RecurrenceRule) && itemToDelete.RecurrenceExceptions?.Count > 0)
            {
                // a recurring appointment was deleted that had exceptions, you may want to
                // delete or update any exceptions from the data source - look for
                // items where theItem.RecurrenceId == itemToDelete.Id
            }

            Bookings.Remove(itemToDelete);
        }
    }
}
