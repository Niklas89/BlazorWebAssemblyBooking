namespace MeetingRoomBooking.Client.Services.UserRoleService
{
    public class UserRoleService : IUserRoleService
    {
        private readonly HttpClient _http;

        public UserRoleService(HttpClient http)
        {
            _http = http;
        }

        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();

        public async Task GetUserRoles()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<UserRole>>>("api/UserRole");
            if (response != null && response.Data != null)
                UserRoles = response.Data;

        }
    }
}
