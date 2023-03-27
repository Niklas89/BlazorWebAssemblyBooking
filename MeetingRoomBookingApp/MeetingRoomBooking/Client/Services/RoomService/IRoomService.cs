namespace MeetingRoomBooking.Client.Services.RoomService
{
    public interface IRoomService
    {
        List<Room> Rooms { get; set; }
        Task GetRooms();
        Guid GetFirstRoomId();
    }
}
