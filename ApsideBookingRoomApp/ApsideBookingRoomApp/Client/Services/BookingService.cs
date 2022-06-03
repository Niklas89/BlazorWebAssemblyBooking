
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

        public async Task GetBookings()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<BookingDto>>>("api/Booking");
            if (response != null && response.Data != null)
                Bookings = response.Data;
        }
    }
}
