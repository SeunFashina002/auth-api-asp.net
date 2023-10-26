using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Models
{
    public class UserDto
    {
        [Required(ErrorMessage = "username field is required")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "password field is required")]
        public required string Password { get; set; }

        public required string ConfirmPassword { get; set; }
    }
}
