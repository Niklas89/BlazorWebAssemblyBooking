namespace MeetingRoomBooking.Server.Services.UserRoleService
{
    public class UserRoleService : IUserRoleService
    {

        private readonly BookingRoomContext _context;

        public UserRoleService(BookingRoomContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<UserRole>>> GetUserRoles()
        {
            var uhr = await _context.UserRoles.ToListAsync();
            return new ServiceResponse<List<UserRole>>
            {
                Data = uhr
            };
        }

    }
}