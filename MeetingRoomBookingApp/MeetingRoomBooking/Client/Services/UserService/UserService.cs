namespace MeetingRoomBooking.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }
        public List<UserDto> Users { get; set; } = new List<UserDto>();
        public async Task GetUsers()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<UserDto>>>("api/User");
            if (response != null && response.Data != null)
                Users = response.Data;
        }

        public async Task CreateUser(UserDto userDto)
        {

            var user = new UserDto
            {
                FullName = userDto.FullName,
                Password = "User1234",
                Mail = userDto.Mail,
                IdUserRole = Guid.NewGuid(),
                IdRole = userDto.IdRole,
                RoleName = userDto.RoleName

            };

            HttpResponseMessage response = await _http.PostAsJsonAsync("api/User", user);


        }

        public async Task UpdateUser(UserDto userDto)
            {

            var user = new UserDto
            {
                Id = userDto.Id,
                FullName = userDto.FullName,
                Mail = userDto.Mail,
                IdUserRole = userDto.IdUserRole,
                IdRole = userDto.IdRole,
                RoleName = userDto.RoleName


            };


            var result = await _http.PutAsJsonAsync($"api/User", userDto);
                var content = await result.Content.ReadFromJsonAsync<ServiceResponse<UserDto>>();

        }

        public async Task DeleteUser(UserDto userDto)
        {

            var result = await _http.DeleteAsync($"api/User/{userDto.Id}"); 

            var target = Users.FirstOrDefault(a => a.Id == userDto.Id); 
            if (target != null)
            {
                Users.Remove(target);
            }

        }



    }
}
