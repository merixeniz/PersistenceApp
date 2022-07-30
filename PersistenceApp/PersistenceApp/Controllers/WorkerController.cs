using System.Threading;
using System.Threading.Tasks;
using Application.Services;
using Application.Services.BackgroundJobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace PersistenceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly ControlledWorker _worker;

        public WorkerController(ControlledWorker worker)
        {
            _worker = worker;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> StartBackgroundService()
        {
            await _worker.StartAsync(new CancellationToken());
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> StopBackgroundService()
        {
            await _worker.StopAsync(new CancellationToken());
            return Ok();
        }
    }
}
