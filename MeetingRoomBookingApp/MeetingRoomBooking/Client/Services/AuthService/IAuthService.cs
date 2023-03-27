namespace MeetingRoomBooking.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<Guid>> Register(UserRegisterDto request);
        Task<ServiceResponse<string>> Login(UserLoginDto request);
        Task<ServiceResponse<bool>> ChangePassword(UserChangePasswordDto request);
    }
}
