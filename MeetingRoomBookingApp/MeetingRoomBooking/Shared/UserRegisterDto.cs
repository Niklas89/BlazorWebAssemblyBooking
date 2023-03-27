using System.ComponentModel.DataAnnotations;

namespace MeetingRoomBooking.Shared
{
    public class UserRegisterDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Mail { get; set; } = string.Empty;
        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
