namespace MeetingRoomBooking.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<Guid>> Register(User user, string password);
        Task<bool> UserExists(string email);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<ServiceResponse<bool>> ChangePassword(Guid userId, string newPassword);
    }
}
