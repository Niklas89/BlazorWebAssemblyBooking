namespace MeetingRoomBooking.Client.Services.UserService
{
    public interface IUserService
    {
        List<UserDto> Users { get; set; }
        Task GetUsers();
        Task CreateUser(UserDto user);
        Task UpdateUser(UserDto user);
        Task DeleteUser(UserDto user);

    }
}
