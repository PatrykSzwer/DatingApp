using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "You must provide password with length between 3 and 25 characters.")]
        public string Password { get; set; }
    }
}
