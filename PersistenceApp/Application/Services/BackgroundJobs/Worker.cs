﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        // Starts when app process starts, no control over it
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Worker message log at {DateTime.Now}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}