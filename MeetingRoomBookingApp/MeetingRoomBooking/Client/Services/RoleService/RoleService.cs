namespace MeetingRoomBooking.Client.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _http;

        public RoleService(HttpClient http)
        {
            _http = http;
        }

        public List<Role> Roles { get; set; } = new List<Role>();

        public byte GetFirstRoleId()
        {
            byte roleId;

            if (Roles == null || Roles.Count == 0)
                roleId = 1;
            else
                roleId = Roles.Select(r => r.Id).First();

            return roleId;
        }

        public async Task GetRoles()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Role>>>("api/Role");
            if (response != null && response.Data != null)
                Roles = response.Data;

        }
    }
}
