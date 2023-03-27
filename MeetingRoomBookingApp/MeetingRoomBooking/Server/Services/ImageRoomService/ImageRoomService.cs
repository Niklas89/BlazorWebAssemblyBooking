namespace MeetingRoomBooking.Server.Services.ImageRoomService
{
    public class ImageRoomService : IImageRoomService
    {

        private readonly BookingRoomContext _context;

        public ImageRoomService(BookingRoomContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<RoomDto>>> GetRooms()
        {

            List<RoomDto> rooms = new List<RoomDto>();

            rooms = await _context.Rooms.Select(r => new RoomDto
            {
                Id = r.Id,
                Name = r.Name,
                Capacity = r.Capacity,
                Availability = r.Availability,
                CreationUserId = r.CreationUserId,
                ModificationUserId = r.ModificationUserId,
                CreationDate = r.CreationDate,
                ModificationDate = r.ModificationDate,
                IdImage = r.IdFileNavigation.Id,
                NameImage = r.IdFileNavigation.Name,
                ContentImage = r.IdFileNavigation.Content,
                ExtensionImage = r.IdFileNavigation.Extension
            }).ToListAsync();

            return new ServiceResponse<List<RoomDto>>
            {
                Data = rooms
            };
        }

        public async Task<ServiceResponse<RoomDto>> CreateRoom(RoomDto room)
        {
            // If the created room has an image related to it, insert it, else only create the room
            if (!string.IsNullOrEmpty(room.NameImage) && !string.IsNullOrEmpty(room.ExtensionImage))
            {
                var dbimage = new FileTmp
                {
                    Id = (Guid)room.IdImage,
                    Type = "image",
                    Name = room.NameImage,
                    Content = room.ContentImage,
                    Extension = room.ExtensionImage,
                    CreationDate = room.CreationDate
                };
                _context.FileTmps.Add(dbimage);
            }

            // Create the room. If there is no image related, IdFile will be null
            var dbroom = new Room
            {
                Name = room.Name,
                Capacity = room.Capacity,
                Availability = room.Availability,
                CreationUserId = room.CreationUserId,
                ModificationUserId = room.ModificationUserId,
                CreationDate = room.CreationDate,
                ModificationDate = room.ModificationDate,
                IdFile = room.IdImage
            };
            _context.Rooms.Add(dbroom);

            
            await _context.SaveChangesAsync();

            return new ServiceResponse<RoomDto> { Data = room };
        }


        public async Task<ServiceResponse<RoomDto>> UpdateRoom(RoomDto room)
        {
            if (!string.IsNullOrEmpty(room.NameImage) && !string.IsNullOrEmpty(room.ExtensionImage))
            {
                // Select the image from the database that corresponds to the room that we update
                // Or create a new image if the initial room had no image
                var dbImage = await _context.FileTmps.FirstOrDefaultAsync(img => img.Id == room.IdImage);

                if (dbImage == null)
                {
                    var dbimage = new FileTmp
                    {
                        Id = (Guid)room.IdImage,
                        Type = "image",
                        Name = room.NameImage,
                        Content = room.ContentImage,
                        Extension = room.ExtensionImage,
                        CreationDate = room.ModificationDate
                    };
                    _context.FileTmps.Add(dbimage);
                }
                else
                {
                    dbImage.Name = room.NameImage;
                    dbImage.Content = room.ContentImage;
                    dbImage.Extension = room.ExtensionImage;
                    dbImage.CreationDate = room.ModificationDate;

                    _context.FileTmps.Update(dbImage);
                }
            }
            else
            {
                var dbImage = await _context.FileTmps.FirstOrDefaultAsync(img => img.Id == room.IdImage);

                if (dbImage != null)
                {
                    room.IdImage = null;

                    _context.FileTmps.Remove(dbImage);
                }
            }

            // Select the room field from the database (dbRoom) that corresponds to the room that we update
            var dbRoom = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == room.Id);

            if (dbRoom == null)
            {
                return new ServiceResponse<RoomDto>
                {
                    Success = false,
                    Message = "No room found in the database"
                };
            }

            dbRoom.Name = room.Name;
            dbRoom.Capacity = room.Capacity;
            dbRoom.Availability = room.Availability;
            dbRoom.ModificationDate = room.ModificationDate;
            dbRoom.IdFile = room.IdImage;

            _context.Rooms.Update(dbRoom);

            await _context.SaveChangesAsync();


            return new ServiceResponse<RoomDto> { Data = room };
        }


        public async Task<ServiceResponse<bool>> DeleteRoom(Guid id)
        {
            // Delete the room
            var dbRoom = await _context.Rooms.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (dbRoom != null)
            {
                _context.Rooms.Remove(dbRoom);

            }
            else
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Room not found."
                };
            }


            // Delete the image related to the room if there is one
            var dbImage = await _context.FileTmps.Where(u => u.Id == dbRoom.IdFile).FirstOrDefaultAsync();
            if (dbImage != null)
            {
                _context.FileTmps.Remove(dbImage);

            }

            
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }
    }
}
