using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Crime.Common.Models;
using System;

namespace REP_CRIME01.Crime.Application.EventFeatures.Commands
{
    public static partial class UpdateCrimeEvent
    {
        public record Command : IRequest<Response>
        {
            public Guid Id { get; init; }
            public UpdateCrimeEventDto UpdateCrimeEventDto { get; init; }
        }

        public record Response : BaseResponse { }
    }
}
