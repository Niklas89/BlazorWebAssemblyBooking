using System;
using System.Collections.Generic;

namespace MeetingRoomBooking.Shared
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool Availability { get; set; }
        public byte[] RowVersion { get; set; }
        public Guid CreationUserId { get; set; }
        public Guid ModificationUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public Guid? IdFile { get; set; }

        public virtual FileTmp IdFileNavigation { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
