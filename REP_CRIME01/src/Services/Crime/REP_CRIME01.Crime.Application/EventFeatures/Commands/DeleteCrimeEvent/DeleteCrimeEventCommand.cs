using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using System;

namespace REP_CRIME01.Crime.Application.EventFeatures.Commands
{
    public static partial class DeleteCrimeEvent
    {
        public record Command : IRequest<Response>
        {
            public Guid EventId { get; set; }
        }

        public record Response : BaseResponse { }
    }
}
