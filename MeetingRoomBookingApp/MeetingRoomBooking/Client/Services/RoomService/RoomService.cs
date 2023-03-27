namespace MeetingRoomBooking.Client.Services.RoomService
{
    public class RoomService : IRoomService
    {
        private readonly HttpClient _http;

        public RoomService(HttpClient http)
        {
            _http = http;
        }

        public List<Room> Rooms { get; set; } = new List<Room>();
        

        public Guid GetFirstRoomId()
        {
            Guid roomId;

            if (Rooms == null || Rooms.Count == 0)
                roomId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            else 
                roomId = Rooms.Select(r => r.Id).First();

            return roomId;
        }

        public async Task GetRooms()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Room>>>("api/Room");
            if (response != null && response.Data != null)
                Rooms = response.Data;
        }
    }
}
