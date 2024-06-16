using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SampleOfJWTToken.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SampleOfJWTToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Users user = new Users();
        private readonly IConfiguration _confirguration;

        public AuthController(IConfiguration configuration)
        {
            _confirguration = configuration;
        }

        [HttpPost("register")]
        public ActionResult<Users> Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.UserName = request.Username;
            user.PasswordHash = passwordHash;

            return Ok(user);
        }
        [HttpPost("login")]
        public ActionResult<Users> Login(UserDto request)
        {

            if (user.UserName != request.Username)
            {
                return BadRequest("User Not Found");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong PAssword");
            }
            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(Users user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _confirguration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

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
