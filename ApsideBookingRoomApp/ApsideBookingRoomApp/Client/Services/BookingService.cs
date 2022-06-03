
namespace ApsideBookingRoomApp.Client.Services
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _http;

        public BookingService(HttpClient http)
        {
            _http = http;
        }
        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public async Task GetBookings()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Booking>>>("api/Booking");
            if (response != null && response.Data != null)
                Bookings = response.Data;
        }
    }
}
