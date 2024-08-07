using API_Clean.Domain.Entities;
using API_Clean.Dto;
using API_Clean.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API_Clean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _confing;
        private readonly ProductDbContext _productDbContext;

        public AuthController(IConfiguration config,ProductDbContext context)
        {
            _confing = config;
            _productDbContext = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<Users>> Register(UserDto request)
        {
            string hashedpass = BCrypt.Net.BCrypt.HashPassword(request.Password);
            Users newuser = new Users { Username = request.Username, HashedPassword = hashedpass };
            try
            {
                _productDbContext.Users.Add(newuser);
                _productDbContext.SaveChanges();
                return Ok(newuser);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPost("login")]
        public async Task<ActionResult<Users>> Login(UserDto request)
        {
            if (check(request.Username))
            {
                Users sample = _productDbContext.Users.FirstOrDefault(p=>p.Username == request.Username);
                if (BCrypt.Net.BCrypt.Verify(request.Password, sample.HashedPassword))
                {
                    string token = CreateToken(sample);
                    return Ok(token);
                }
                else
                    return BadRequest("wrong password");
            }
            else
            {
                return BadRequest();
            }
        }


        [Authorize(Policy = "Valid")]
        [HttpPost("logout")]
        public async Task<ActionResult<Users>> Logout()
        {
             await HttpContext.SignOutAsync();
            return Ok();
        }
        private bool check(string user)
        {
            if (_productDbContext.Users.FirstOrDefault(p=>p.Username == user) != null)
            {
                return true;
            }
            return false;
        }
        private string CreateToken(Users user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("MyRole", "User"),
                new Claim("Username",user.Username),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confing.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync("MyCookieAuth", claimPrincipal);

            return jwt;
        }
    }
}
