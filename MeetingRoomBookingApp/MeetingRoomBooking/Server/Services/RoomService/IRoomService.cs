namespace MeetingRoomBooking.Server.Services.RoomService
{
    public interface IRoomService
    {
        Task<ServiceResponse<List<Room>>> GetRooms();
    }
}
