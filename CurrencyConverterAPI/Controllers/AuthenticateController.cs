using Common.Models;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CurrencyConverterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        public AuthenticateController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody]CredentialsDTO credentialsDto)
        {
            User? user = _userService.AuthUser(credentialsDto);

            if (user == null)
            {
                return Unauthorized();
            }

            SymmetricSecurityKey securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]!));
            SigningCredentials credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            List<Claim> claimsForToken = new List<Claim>()
            {
                new Claim("sub", user.UserId.ToString()),
                new Claim("given_name", user.Username)
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddMinutes(int.Parse(_config["Authentication:MinToExpireJWT"]!)),
              credentials);


            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken) });
        }
    }
}
