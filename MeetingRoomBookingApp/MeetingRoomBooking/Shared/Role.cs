using System;
using System.Collections.Generic;

namespace MeetingRoomBooking.Shared
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public byte Id { get; set; }
        public string RoleName { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
