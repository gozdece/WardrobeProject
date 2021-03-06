using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Service.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmailWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Consumer _consumer;
       
        public Worker(ILogger<Worker> logger,Consumer consumer)
        {
            _logger = logger;
            _consumer = consumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _consumer.BasicConsume();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
