namespace MeetingRoomBooking.Server.Services.UserRoleService
{
    public interface IUserRoleService
    {
        Task<ServiceResponse<List<UserRole>>> GetUserRoles();
    }
}
