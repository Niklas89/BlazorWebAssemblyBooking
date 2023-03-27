using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MeetingRoomBooking.Shared
{
    public class UserDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The full name is required")]
        public string FullName { get; set; } = null!;

        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress]
        public string Mail { get; set; } = null!;

        public Guid IdUserRole { get; set; }

        [Required(ErrorMessage = "The role is required")]
        public byte IdRole { get; set; }

        [Required(ErrorMessage = "The role is required")]
        public string RoleName { get; set; } = null!;

        public UserDto ShallowCopy()
        {
            return (UserDto)this.MemberwiseClone();
        }
    }
}
