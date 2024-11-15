﻿using Microsoft.AspNetCore.Http;
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

        [HttpGet("{name}")]
        public IActionResult GetSubscriptionByName([FromRoute] string name)
        {
            return Ok(_subscriptionService.GetSubscriptionByName(name));
        }
    }
}
