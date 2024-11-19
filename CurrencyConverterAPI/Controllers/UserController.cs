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
            try
            {
                _userService.AddUser(userForCreationDTO);
                return Created();
            }
            catch
            {   
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("UserDetails")]
        public IActionResult GetUserDetails()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            return Ok(_userService.GetUserById(userId));
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_userService.GetUserById(id));
        }



        [Authorize]
        [HttpPut("{subscriptionId}")]
        public IActionResult UpdateSubscription([FromRoute]int subscriptionId)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

            try
            {
                _userService.UpdateUser(userId, subscriptionId);
                return Ok(new { message = "Subscription updated successfully." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

    }
}
