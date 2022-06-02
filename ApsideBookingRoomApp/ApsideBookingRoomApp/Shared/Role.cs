using System;
using System.Collections.Generic;

namespace ApsideBookingRoomApp.Server
{
    public partial class Role
    {
        public Role()
        {
            IdUsers = new HashSet<User>();
        }

        public byte IdRole { get; set; }
        public string RoleName { get; set; } = null!;
        public byte[] RowVersion { get; set; } = null!;

        public virtual ICollection<User> IdUsers { get; set; }
    }
}
