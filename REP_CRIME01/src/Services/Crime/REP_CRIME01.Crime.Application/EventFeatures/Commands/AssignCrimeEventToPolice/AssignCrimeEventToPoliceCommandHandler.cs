 using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Crime.Domain.Contracts;
using REP_CRIME01.Crime.Domain.Entities;
using REP_CRIME01.Crime.Infrastructure.Clients;
using REP_CRIME01.EventBus.Messages;
using REP_CRIME01.Police.Common.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace REP_CRIME01.Crime.Application.EventFeatures.Commands
{
    public static partial class AssignCrimeEventToPolice
    {
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly IRepository<CrimeEvent> _repository;
            private readonly IPoliceClient _policeClient;
            private readonly ILogger<Handler> _logger;
            private readonly IPublishEndpoint _publishEndpoint;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IRepository<CrimeEvent> repository, IPoliceClient policeClient, ILogger<Handler> logger, IPublishEndpoint publishEndpoint)
            {
                _mapper = mapper;
                _repository = repository;
                _policeClient = policeClient;
                _logger = logger;
                _publishEndpoint = publishEndpoint;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _repository.FindByIdAsync(request.Id);
                if (entity is null) return new Response { Status = ResponseStatus.NotFound };

                if (entity.IsLawEnforcementAssigned)
                    return new Response { Status = ResponseStatus.BadQuery, ErrorMessage = "This report has already been processed." };

                var result = await CreateCase(request, entity);
                if (result is null)
                    return new Response { Status = ResponseStatus.BadQuery, ErrorMessage = "The error occured while processing this report." };

                entity.Status = EventStatus.Finished.ToString();
                entity.LawEnforcementCode = request.AssignCrimeEventToPoliceDto.LawEnforcementCode;
                await _repository.UpdateAsync(entity);

                var eventMessage = _mapper.Map<CrimeEventAssignedNotification>(entity);
                await _publishEndpoint.Publish(eventMessage);
                _logger.LogInformation($"{nameof(CrimeEventAssignedNotification)} message has been published.");

                return new Response { Status = ResponseStatus.Success };
            }

            private async Task<Guid?> CreateCase(Command request, CrimeEvent entity)
            {
                var dto = new CreateCaseDto()
                {
                    CrimeReportId = request.Id,
                    DateReported = entity.CreatedDate,
                    CrimeDate = entity.EventDate,
                    Description = request.AssignCrimeEventToPoliceDto.Description,
                    LawEnforcementCode = request.AssignCrimeEventToPoliceDto.LawEnforcementCode
                };

                return await _policeClient.CreateCase(dto);
            }
        }
    }
}
