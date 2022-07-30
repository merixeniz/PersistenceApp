using System;
using Application.Services;
using Entities.ServiceBus;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PersistenceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AzureController : ControllerBase
    {
        private readonly ILogger<AzureController> _logger;
        private readonly IBus _bus;
        private readonly Worker _worker;

        public AzureController(ILogger<AzureController> logger, IBus bus, Worker worker)
        {
            _logger = logger;
            _bus = bus;
            _worker = worker;
        }

        [HttpGet("[action]")]
        public IActionResult ServiceBusSend()
        {
            var message = new Message
            {
                Id = Guid.NewGuid(),
                Body = $"Some message at {DateTime.Now}"
            };

            _logger.LogInformation(message.Body);

            _bus.Publish(message);

            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult FunctionResponse(string data)
        {

            return Ok();
        }
    }
}
