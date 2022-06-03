using System;
using System.Collections.Generic;

namespace ApsideBookingRoomApp.Shared
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid IdRoom { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public string? Image { get; set; }
        public bool Availability { get; set; }
        public byte[] RowVersion { get; set; } = null!;
        public Guid CreationUserId { get; set; }
        public Guid ModificationUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
