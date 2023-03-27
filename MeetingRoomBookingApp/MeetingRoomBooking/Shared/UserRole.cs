using System;
using System.Collections.Generic;

namespace MeetingRoomBooking.Shared
{
    public partial class UserRole
    {
        public Guid Id { get; set; }
        public byte IdRole { get; set; }
        public Guid IdUser { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
