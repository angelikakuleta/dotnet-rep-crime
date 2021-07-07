using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using System;

namespace REP_CRIME01.Police.Application.CaseFeatures.Commands
{
    public static partial class CreateCase
    {
        public record Command : IRequest<Response>
        {
            public Guid CrimeReportId { get; init; }
            public DateTime DateReported { get; init; }
            public DateTime CrimeDate { get; init; }
            public string Description { get; init; }
            public string LawEnforcementCode { get; init; }
        }

        public record Response : BaseResponse<Guid> { }
    }
}
