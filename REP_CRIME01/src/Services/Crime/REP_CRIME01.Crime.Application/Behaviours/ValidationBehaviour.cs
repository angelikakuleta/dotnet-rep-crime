using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using REP_CRIME01.Crime.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REP_CRIME01.Crime.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TResponse : BaseResponse, new()
    {       
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<ValidationBehaviour<TRequest, TResponse>> _logger;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors.Select(x => x.ErrorMessage)).Where(f => f is not null).ToList();

                if (failures.Count > 0)
                    return new TResponse { Status = ResponseStatus.ValidationError, ErrorMessage = failures };
            }

            _logger.LogInformation("Validation successful for {request}.", request.GetType());
            return await next();
        }
    }
}
