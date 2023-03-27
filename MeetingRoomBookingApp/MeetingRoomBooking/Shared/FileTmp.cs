using System;
using System.Collections.Generic;

namespace MeetingRoomBooking.Shared
{
    public partial class FileTmp
    {
        public FileTmp()
        {
            Rooms = new HashSet<Room>();
        }

        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public string Extension { get; set; }
        public DateTime CreationDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
