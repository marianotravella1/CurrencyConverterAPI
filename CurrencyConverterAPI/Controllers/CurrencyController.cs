using Common.Models;
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

        [HttpGet("{id}")]
        public IActionResult GetCurrencyById([FromRoute] int id)
        {
            return Ok(_currencyService.GetCurrencyById(id));
        }

        [HttpPut("UpdateCI/{id}")]
        public IActionResult UpdateCurrencyCIById([FromRoute] int id, decimal ci)
        {
            try
            {
                _currencyService.UpdateCurrencyCIById(id, ci);
                return Ok("Convertibility index updated successfuly!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateCurrency")]
        public IActionResult CreateCurrency([FromBody]CurrencyForCreationDTO currencyDTO)
        {
            try
            {
                _currencyService.CreateCurrency(currencyDTO);
                return Ok("Currency successfully created and registered");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteCurrency/{id}")]
        public IActionResult DeleteCurrencyById([FromRoute] int id)
        {
            try
            {
                _currencyService.DeleteCurrencyById(id);
                return Ok("Currency deleted successfuly");
            }
            catch
            {
                return BadRequest();
            }

        }

    }
}
