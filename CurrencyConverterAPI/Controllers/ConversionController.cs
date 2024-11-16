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
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;
        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetConversionHistory()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            
            return Ok(_conversionService.GetConversionHistoryByUserId(userId));
        }

        [HttpPost("CalculateConversion")]
        [Authorize]
        public IActionResult CalculateConversion([FromBody] ConversionForAddDTO conversionDTO)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

            return Ok(_conversionService.Convert(userId, conversionDTO));
        }

        
    }
}
