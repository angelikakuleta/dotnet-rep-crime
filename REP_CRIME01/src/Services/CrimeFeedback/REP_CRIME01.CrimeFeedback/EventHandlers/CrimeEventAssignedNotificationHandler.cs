using MassTransit;
using Microsoft.Extensions.Logging;
using REP_CRIME01.CrimeFeedback.Services;
using REP_CRIME01.EventBus.Messages;
using System.Threading.Tasks;

namespace REP_CRIME01.CrimeFeedback.EventHandlers
{
    public class CrimeEventAssignedNotificationHandler : IConsumer<CrimeEventAssignedNotification>
    {
        private readonly ILogger<CrimeEventAssignedNotificationHandler> _logger;
        private readonly ISender _sender;

        public CrimeEventAssignedNotificationHandler(ILogger<CrimeEventAssignedNotificationHandler> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        public async Task Consume(ConsumeContext<CrimeEventAssignedNotification> context)
        {
            _logger.LogInformation($"{nameof(CrimeEventAssignedNotification)} message consumed successfully.");
            await _sender.Send(context.Message);
        }
    }
}