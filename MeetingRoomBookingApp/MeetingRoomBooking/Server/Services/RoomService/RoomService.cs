namespace MeetingRoomBooking.Server.Services.RoomService
{
    public class RoomService : IRoomService
    {

        private readonly BookingRoomContext _context;

        public RoomService(BookingRoomContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Room>>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return new ServiceResponse<List<Room>>
            {
                Data = rooms
            };
        }

    }
}
