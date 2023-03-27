namespace MeetingRoomBooking.Server.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<UserDto>>> GetUsers();
        Task<ServiceResponse<UserDto>> CreateUser(UserDto userDto);
        Task<ServiceResponse<bool>> DeleteUser(Guid userId);
        Task<ServiceResponse<UserDto>> UpdateUser(UserDto userDto);

    }
}
