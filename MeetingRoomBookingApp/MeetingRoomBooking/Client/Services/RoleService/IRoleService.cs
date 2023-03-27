namespace MeetingRoomBooking.Client.Services.RoleService 
{ 
    public interface IRoleService
    {
        List<Role> Roles { get; set; }
        Task GetRoles();

        byte GetFirstRoleId();
    }
}
