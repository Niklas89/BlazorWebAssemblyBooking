namespace MeetingRoomBooking.Client.Services.ImageRoomService
{
    public class ImageRoomService : IImageRoomService
    {
        private readonly HttpClient _http;

        public ImageRoomService(HttpClient http)
        {
            _http = http;
        }
        public List<RoomDto> ImageRooms { get; set; } = new List<RoomDto>();
        public async Task GetRooms()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<RoomDto>>>("api/ImageRoom");
            if (response != null && response.Data != null)
                ImageRooms = response.Data;
        }

        public async Task CreateRoom(RoomDto room)
        {
            // if an image is uploaded, its Id will be needed in order to insert the image related to this room
            Guid? idImage;
            if(string.IsNullOrEmpty(room.NameImage))
            {
                idImage = null;
            } else
            {
                idImage = Guid.NewGuid();
            }
            var newRoom = new RoomDto
            {
                Name = room.Name,
                Capacity = room.Capacity,
                Availability = room.Availability,
                CreationUserId = Guid.Parse("B444AE48-1CF9-EC11-A843-00155DFF5915"),
                ModificationUserId = Guid.Parse("B444AE48-1CF9-EC11-A843-00155DFF5915"),
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                IdImage = idImage, 
                NameImage = room.NameImage,
                ContentImage = room.ContentImage,
                ExtensionImage = room.ExtensionImage
            };

            HttpResponseMessage response = await _http.PostAsJsonAsync("api/ImageRoom", newRoom);
        }

        public async Task UpdateRoom(RoomDto room)
        {
            // update the room with or witout the IdImage if there is an image or not
            Guid? idImage;
            
            if (string.IsNullOrEmpty(room.NameImage) && (room.IdImage == null))
            {
                idImage = null;
            }
            else if (!string.IsNullOrEmpty(room.NameImage) && (room.IdImage == null))
            {
                idImage = Guid.NewGuid();
            }
            else 
            {
                idImage = room.IdImage;
            }

            var newRoom = new RoomDto
            {
                Id = room.Id,
                Name = room.Name,
                Capacity = room.Capacity,
                Availability = room.Availability,
                CreationUserId = room.CreationUserId,
                ModificationUserId = room.ModificationUserId,
                CreationDate = room.CreationDate,
                ModificationDate = DateTime.Now,
                IdImage = idImage,
                NameImage = room.NameImage,
                ContentImage = room.ContentImage,
                ExtensionImage = room.ExtensionImage
            };
            var result = await _http.PutAsJsonAsync($"api/ImageRoom", newRoom);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RoomDto>>();
        }

        public async Task DeleteRoom(RoomDto room)
        {
            var result = await _http.DeleteAsync($"api/ImageRoom/{room.Id}");
            var target = ImageRooms.FirstOrDefault(a => a.Id == room.Id);
            if (target != null)
            {
                ImageRooms.Remove(target);
            }
        }

        public async Task DeleteImageUpdateRoom(RoomDto room)
        {
            room.NameImage = null;
            room.ContentImage = null;
            room.ExtensionImage = null;
            var result = await _http.PutAsJsonAsync($"api/ImageRoom", room);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RoomDto>>();
        }
    }
}
