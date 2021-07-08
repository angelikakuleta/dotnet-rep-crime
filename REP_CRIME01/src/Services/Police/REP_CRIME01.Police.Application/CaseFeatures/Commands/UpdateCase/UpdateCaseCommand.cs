using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Police.Common.Models;
using System;

namespace REP_CRIME01.Police.Application.CaseFeatures.Commands
{
    public static partial class UpdateCase
    {
        public record Command : IRequest<Response>
        {
            public Guid Id { get; init; }
            public UpdateCaseDto UpdateCaseDto { get; init; }
        }

        public record Response : BaseResponse<Guid> { }
    }
}
