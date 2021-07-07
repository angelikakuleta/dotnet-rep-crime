using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using System;

namespace REP_CRIME01.Police.Application.CaseFeatures.Commands
{
    public static partial class UpdateCase
    {
        public record Command : IRequest<Response>
        {
            public Guid Id { get; set; }
            public DateTime CrimeDate { get; init; }
            public string Description { get; init; }
            public string LawEnforcementCode { get; init; }
        }

        public record Response : BaseResponse<Guid> { }
    }
}
