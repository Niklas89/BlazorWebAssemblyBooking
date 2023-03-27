namespace MeetingRoomBooking.Server.Services.SettingService
{
    public class SettingService : ISettingService
    {

        private readonly BookingRoomContext _context;

        public SettingService(BookingRoomContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Setting>>> GetSettings()
        {
            var settings = await _context.Settings.ToListAsync();
            return new ServiceResponse<List<Setting>>
            {
                Data = settings
            };
        }
    }
}
