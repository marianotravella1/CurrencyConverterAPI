using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CurrencyConverterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public IActionResult GetAllCurrencies()
        {
            return Ok(_currencyService.GetAllCurrencies());
        }

        [HttpGet("{code}")]
        public IActionResult GetCurrencyByCode([FromRoute] string code)
        {
            return Ok(_currencyService.GetCurrencyByCode(code));
        }

    }
}
