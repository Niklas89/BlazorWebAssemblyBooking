namespace MeetingRoomBooking.Server.Services.ImageRoomService
{
    public interface IImageRoomService
    {
        Task<ServiceResponse<List<RoomDto>>> GetRooms();
        Task<ServiceResponse<RoomDto>> CreateRoom(RoomDto room);
        Task<ServiceResponse<bool>> DeleteRoom(Guid id);
        Task<ServiceResponse<RoomDto>> UpdateRoom(RoomDto room);
    }
}
