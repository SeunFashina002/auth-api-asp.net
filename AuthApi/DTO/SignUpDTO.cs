using System.ComponentModel.DataAnnotations;

namespace AuthApi.DTO
{
    public class SignUpDTO
    {
        [Required(ErrorMessage = "username field is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "username field is required")]
        [EmailAddress(ErrorMessage = "enter a valid email address")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "password cannot be less than 8 characters")]
        [Required(ErrorMessage = "password field is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "confirm password field is required")]
        [Compare(nameof(Password), ErrorMessage = "confirm password and password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
