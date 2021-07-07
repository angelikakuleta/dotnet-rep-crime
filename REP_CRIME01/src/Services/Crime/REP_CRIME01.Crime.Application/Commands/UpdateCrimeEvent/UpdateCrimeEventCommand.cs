using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using System;

namespace REP_CRIME01.Crime.Application.Commands
{
    public static partial class UpdateCrimeEvent
    {
        public record Command : IRequest<Response>
        {
            public Guid Id { get; init; }
            public DateTime EventDate { get; init; }
            public string EventType { get; init; }
            public string Description { get; init; }
            public string City { get; init; }
            public string Street { get; init; }
            public string ReportingPersonEmail { get; init; }
        }

        public record Response : BaseResponse { }
    }
}
