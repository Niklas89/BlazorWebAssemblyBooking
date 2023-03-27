using System;
using System.Collections.Generic;

namespace MeetingRoomBooking.Shared
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            UserRoles = new HashSet<UserRole>();
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Mail { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
