using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace REP_CRIME01.CrimeFeedback
{
    public class Worker : IHostedService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IBusControl _bus;

        public Worker(ILogger<Worker> logger, IBusControl bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the bus...");
            return _bus.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping the bus...");
            return _bus.StopAsync(cancellationToken);
        }
    }
}
