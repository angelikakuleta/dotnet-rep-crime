using MassTransit;
using Microsoft.Extensions.Logging;
using REP_CRIME01.EventBus.Messages;
using System.Threading.Tasks;

namespace REP_CRIME01.CrimeFeedback.EventHandlers
{
    public class CrimeEventAssignedNotificationHandler : IConsumer<CrimeEventAssignedNotification>
    {
        private readonly ILogger<CrimeEventAssignedNotificationHandler> _logger;

        public CrimeEventAssignedNotificationHandler(ILogger<CrimeEventAssignedNotificationHandler> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<CrimeEventAssignedNotification> context)
        {
            _logger.LogInformation($"{nameof(CrimeEventAssignedNotification)} message consumed successfully.");
            _logger.LogInformation($"Sending email to {context.Message.ReportingPersonEmail}...");

            return Task.CompletedTask;
        }
    }
}