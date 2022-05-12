using System;
using System.Collections.Generic;

namespace BlazorBooking.Shared
{
    public partial class Appointment
    {
        public Appointment()
        {
            IdEmployees = new HashSet<Employee>();
        }

        public int IdAppointment { get; set; }
        public DateTime DateHour { get; set; }
        public string EventSubject { get; set; } = null!;
        public int IdRoom { get; set; }

        public virtual Room IdRoomNavigation { get; set; } = null!;

        public virtual ICollection<Employee> IdEmployees { get; set; }
    }
}
