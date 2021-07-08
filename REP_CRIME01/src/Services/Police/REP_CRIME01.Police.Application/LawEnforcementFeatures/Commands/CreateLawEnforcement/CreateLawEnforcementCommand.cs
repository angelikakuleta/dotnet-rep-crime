using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Police.Common.Models;
using System;

namespace REP_CRIME01.Police.Application.LawEnforcementFeatures.Commands
{
    public static partial class CreateLawEnforcement
    {
        public record Command : IRequest<Response>
        {
            public CreateLawEnforcementDto CreateLawEnforcementDto { get; init; }
        }

        public record Response : BaseResponse<Guid> { }
    }
}
