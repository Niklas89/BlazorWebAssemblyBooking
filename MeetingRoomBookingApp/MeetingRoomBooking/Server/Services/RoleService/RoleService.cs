namespace MeetingRoomBooking.Server.Services.RoleService
{
    public class RoleService : IRoleService
    {

        private readonly BookingRoomContext _context;

        public RoleService(BookingRoomContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Role>>> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return new ServiceResponse<List<Role>>
            {
                Data = roles
            };
        }

    }
}
