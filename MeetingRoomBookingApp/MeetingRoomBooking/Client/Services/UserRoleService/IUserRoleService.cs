namespace MeetingRoomBooking.Client.Services.UserRoleService
{
    public interface IUserRoleService
    {
        List<UserRole> UserRoles { get; set; }
        Task GetUserRoles();
    }
}
