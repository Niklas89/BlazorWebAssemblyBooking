namespace MeetingRoomBooking.Client.Services.SettingService
{
    public class SettingService : ISettingService
    {
        private readonly HttpClient _http;

        public SettingService(HttpClient http)
        {
            _http = http;
        }

        public List<Setting> Settings { get; set; } = new List<Setting>();

        public async Task GetSettings()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Setting>>>("api/Setting");
            if (response != null && response.Data != null)
                Settings = response.Data;
        }
    }
}
