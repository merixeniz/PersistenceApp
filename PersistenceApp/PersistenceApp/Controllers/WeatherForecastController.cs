using Application.Extensions;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using PersistenceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersistenceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDistributedCache _cache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
                                         IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SetCachedRecord()
        {
            var person = new Person { Id = 1, DateOfBirth = new DateTime(1994, 10, 28), Name = "Szymon", LastName = "Oles", Profession = "Developer" };
            var key = "simon";

            await _cache.SetRecordAsync(key, person);
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<Person>> GetCachedRecord()
        {
            var key = "simon";
            var person = await _cache.GetRecordAsync<Person>(key);
            return Ok(person);
        }

        [HttpPost("[action]")]
        public IActionResult SamplePost([FromBody] ItemDto dto)
        {
            return Ok();
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<ItemDto>> SampleGet()
        {
            var dtos = new List<ItemDto>
            {
                new ItemDto { Id = 1, Name = "Rafał" },
                new ItemDto { Id = 1, Name = "Andrzej" }
            };

            return Ok(dtos);
        }




    }
}
