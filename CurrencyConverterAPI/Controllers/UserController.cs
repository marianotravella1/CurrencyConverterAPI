using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Security.Claims;

namespace CurrencyConverterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPost("SignUp")]
        public IActionResult AddUser([FromBody] UserForCreationDTO userForCreationDTO)
        {
            _userService.AddUser(userForCreationDTO);
            return Created();
        }
        [Authorize]
        [HttpGet("UserDetails")]
        public IActionResult GetUserDetails()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            return Ok(_userService.GetUserById(userId));
        }

    }
}
