using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        public static User user = new();

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto req)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(req.Password);
            user.Username = req.Username;
            user.Password = passwordHash;

            return Ok(user);
        }
    }
}
