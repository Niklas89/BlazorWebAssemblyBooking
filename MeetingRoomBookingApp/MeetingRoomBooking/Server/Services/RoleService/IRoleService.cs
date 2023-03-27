namespace MeetingRoomBooking.Server.Services.RoleService
{
    public interface IRoleService
    {
        Task<ServiceResponse<List<Role>>> GetRoles();
    }
}
