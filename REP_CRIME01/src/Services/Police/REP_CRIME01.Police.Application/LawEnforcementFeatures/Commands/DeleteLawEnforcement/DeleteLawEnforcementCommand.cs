using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using System;

namespace REP_CRIME01.Police.Application.LawEnforcementFeatures.Commands
{
    public static partial class DeleteLawEnforcement
    {
        public record Command : IRequest<Response>
        {
            public Guid Id { get; set; }
        }

        public record Response : BaseResponse { }
    }
}
