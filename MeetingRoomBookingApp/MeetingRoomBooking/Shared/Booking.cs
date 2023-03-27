using System;
using System.Collections.Generic;

namespace MeetingRoomBooking.Shared
{
    public partial class Booking
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
        public byte[] RowVersion { get; set; }
        public Guid CreationUserId { get; set; }
        public Guid ModificationUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool IsAllDay { get; set; }
        public Guid? RecurrenceId { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceExceptions { get; set; }
        public Guid IdRoom { get; set; }

        public virtual User CreationUser { get; set; }
        public virtual Room IdRoomNavigation { get; set; }
    }
}
