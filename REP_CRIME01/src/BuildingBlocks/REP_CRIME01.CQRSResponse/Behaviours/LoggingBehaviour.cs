using MediatR;
using Microsoft.Extensions.Logging;
using REP_CRIME01.CQRSResponse.Responses;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace REP_CRIME01.CQRSResponse.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : BaseResponse, new()
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType().FullName;
            _logger.LogInformation($"{requestName} is starting...");

            var timer = Stopwatch.StartNew();
            var response = await next();
            timer.Stop();

            if (!response.IsSuccess)
            {
                _logger.LogWarning($"{requestName} has finished with status {response.Status}.");
            }
                
            _logger.LogInformation($"{requestName} has finished in {timer.ElapsedMilliseconds}ms.");
            return response;
        }
    }
}
