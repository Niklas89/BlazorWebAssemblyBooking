using System;
using System.Collections.Generic;

namespace BlazorBooking.Shared
{
    public partial class Employee
    {
        public Employee()
        {
            IdAppointments = new HashSet<Appointment>();
        }

        public int IdEmployee { get; set; }
        public string Lastname { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Mail { get; set; } = null!;

        public virtual ICollection<Appointment> IdAppointments { get; set; }
    }
}
