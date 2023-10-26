using System.ComponentModel.DataAnnotations;

namespace AuthApi.Models
{
    public class User
    {
        [Required(ErrorMessage = "username field is required")]
        [MinLength(3, ErrorMessage = "username cannot be less than 3 characters")]
        [StringLength(15, ErrorMessage = "username cannot be more than 15 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "username field is required")]
        [EmailAddress(ErrorMessage = "enter a valid email address")]
        public string Email { get; set; }

        // *stores only hashed passwords
        [Required(ErrorMessage = "password field is required")]
        [MinLength(8, ErrorMessage = "password cannot be less than 8 characters")]
        public string Password { get; set; }
    }
}
