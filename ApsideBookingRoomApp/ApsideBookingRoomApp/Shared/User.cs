using System;
using System.Collections.Generic;

namespace ApsideBookingRoomApp.Shared
{
    public partial class User
    {
        public User()
        {
            IdBookings = new HashSet<Booking>();
            IdRoles = new HashSet<Role>();
        }

        public Guid IdUser { get; set; }
        public string FullName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public byte[] RowVersion { get; set; } = null!;

        public virtual ICollection<Booking> IdBookings { get; set; }
        public virtual ICollection<Role> IdRoles { get; set; }
    }
}
