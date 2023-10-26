using System.ComponentModel.DataAnnotations;

namespace AuthApi.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "username field is required")]
        public string Username { get; set; }

        [MinLength(8, ErrorMessage = "password cannot be less than 8 characters")]
        [Required(ErrorMessage = "password field is required")]
        public string Password { get; set; }
    }
}
