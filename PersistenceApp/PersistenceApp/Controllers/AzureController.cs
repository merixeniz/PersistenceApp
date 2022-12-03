using System;
using System.Threading.Tasks;
using Application.Services;
using Entities.ServiceBus;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PersistenceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AzureController : Controller
    {
        private readonly ILogger<AzureController> _logger;
        //private readonly IBus _bus;
        private readonly Worker _worker;

        public AzureController(ILogger<AzureController> logger, /*IBus bus,*/ Worker worker)
        {
            _logger = logger;
            //_bus = bus;
            _worker = worker;

            // https://www.youtube.com/watch?v=8marp1oyY_I
            // https://www.youtube.com/watch?v=qRTx3TrbNbU
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

            //_bus.Publish(message);

            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult FunctionResponse()
        {
            int result = 5;
            return Json(new { result });
            //return Ok();
        }
    }
}
