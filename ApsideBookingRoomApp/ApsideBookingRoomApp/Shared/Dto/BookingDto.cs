using System;
using System.Collections.Generic;

namespace ApsideBookingRoomApp.Shared.Dto
{
    public partial class BookingDto
    {
        public BookingDto()
        {
            IdUsers = new HashSet<User>();
        }

        public Guid IdBooking { get; set; }
        public string Subject { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Comment { get; set; }
        public byte[] RowVersion { get; set; } = null!;
        public Guid CreationUserId { get; set; }
        public Guid ModificationUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public Guid IdRoom { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public List<DateTime> RecurrenceExceptions { get; set; }
        public Guid? RecurrenceId { get; set; }

        public virtual Room IdRoomNavigation { get; set; } = null!;

        public virtual ICollection<User> IdUsers { get; set; }
    }
}
