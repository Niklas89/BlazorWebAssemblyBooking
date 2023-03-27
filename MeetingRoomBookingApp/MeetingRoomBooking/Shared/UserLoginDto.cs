using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRoomBooking.Shared
{
    public class UserLoginDto
    {
        [Required]
        public string Mail { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}