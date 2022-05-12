using System;
using System.Collections.Generic;

namespace BlazorBooking.Shared
{
    public partial class Room
    {
        public Room()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int IdRoom { get; set; }
        public string Name { get; set; } = null!;
        public int MaxParticipant { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
