using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using System;

namespace REP_CRIME01.Crime.Application.EventFeatures.Commands
{
    public static partial class AssignCrimeEventToPolice
    {
        public record Command : IRequest<Response>
        {
            public Guid Id { get; init; }
            public string Description { get; init; }
            public string LawEnforcementCode { get; init; }
        }

        public record Response : BaseResponse { }
    }
}
