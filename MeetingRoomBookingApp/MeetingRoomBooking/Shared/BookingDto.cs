using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MeetingRoomBooking.Shared
{

    public class BookingDto
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "The subject is required")]
        public string Subject { get; set; } = null!;

        [Required(ErrorMessage = "The start date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The end date is required")]
        public DateTime EndDate { get; set; }
        public string? Comment { get; set; }
        public Guid CreationUserId { get; set; }
        public Guid ModificationUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool IsAllDay { get; set; }
        public Guid? RecurrenceId { get; set; }
        public string? RecurrenceRule { get; set; }
        public string? RecurrenceExceptions { get; set; }
        public Guid IdRoom { get; set; }
        public string NameRoom { get; set; } = null!;
        public int CapacityRoom { get; set; }
        public string NameUser { get; set; } = null!;
        public string MailUser { get; set; } = null!;

        public BookingDto ShallowCopy()
        {
            return (BookingDto)this.MemberwiseClone();
        }
    }
}
