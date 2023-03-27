namespace MeetingRoomBooking.Client.Services.ImageRoomService
{
    public interface IImageRoomService
    {
        List<RoomDto> ImageRooms { get; set; }
        Task GetRooms();
        Task CreateRoom(RoomDto room); 
        Task UpdateRoom(RoomDto room);
        Task DeleteRoom(RoomDto room);
        Task DeleteImageUpdateRoom(RoomDto room);
    }
}
