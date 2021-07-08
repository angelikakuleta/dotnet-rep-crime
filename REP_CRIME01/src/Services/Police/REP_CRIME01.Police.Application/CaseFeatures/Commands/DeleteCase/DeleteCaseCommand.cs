using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using System;

namespace REP_CRIME01.Police.Application.CaseFeatures.Commands
{
    public static partial class DeleteCase
    {
        public record Command : IRequest<Response>
        {
            public Guid Id { get; init; }
        }

        public record Response : BaseResponse { }
    }
}
