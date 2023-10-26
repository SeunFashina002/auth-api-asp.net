using System.ComponentModel.DataAnnotations;

namespace AuthApi.Models
{
    public class User
    {
        [Required(ErrorMessage = "username field is required")]
        public string Username { get; set; }

        // *stores only hashed passwords
        [Required(ErrorMessage = "password field is required")]
        public string Password { get; set; }
    }
}
