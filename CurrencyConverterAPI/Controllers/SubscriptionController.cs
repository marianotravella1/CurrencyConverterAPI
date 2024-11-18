using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CurrencyConverterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public IActionResult GetAlSubscriptions()
        {
            return Ok(_subscriptionService.GetAllSubscriptions());
        }

        [HttpGet("{id}")]
        public IActionResult GetSubscriptionById([FromRoute] int id)
        {
            return Ok(_subscriptionService.GetSubscriptionById(id));
        }
    }
}
