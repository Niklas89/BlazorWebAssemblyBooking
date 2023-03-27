using System;
using System.Collections.Generic;

namespace MeetingRoomBooking.Shared
{
    public partial class Setting
    {
        public string Name { get; set; }
        public byte[] RowVersion { get; set; }
        public string Value { get; set; }
        public byte Type { get; set; }
        public string Description { get; set; }
    }
}
