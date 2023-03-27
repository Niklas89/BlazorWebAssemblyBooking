using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRoomBooking.Shared
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public bool Availability { get; set; }
        public Guid CreationUserId { get; set; }
        public Guid ModificationUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public Guid? IdImage { get; set; }
        public string? NameImage { get; set; }
        public byte[]? ContentImage { get; set; }
        public string? ExtensionImage { get; set; }
    }
}
