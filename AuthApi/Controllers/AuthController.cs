using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthApi.DTO;
using AuthApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static User user = new();

        [HttpPost("register")]
        public ActionResult<User> Register(SignUpDTO req)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(req.Password);
            user.Username = req.Username;
            user.Email = req.Email;
            user.Password = passwordHash;

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(LoginDTO req)
        {
            if (
                user.Username != req.Username
                || !BCrypt.Net.BCrypt.Verify(req.Password, user.Password)
            )
            {
                return BadRequest("username or password is incorrect");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new() { new(ClaimTypes.Name, user.Username) };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("jwt:Token").Value!)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
