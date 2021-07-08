using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Police.Common.Models;
using System;

namespace REP_CRIME01.Police.Application.CaseFeatures.Queries
{
    public static partial class GetCasesByLawEnforcementId
    {
        public record Query : IRequest<Response>
        {
            public Guid LawEnforcementId { get; init; }
            public CasesQueryString QueryString { get; init; }
        }

        public record Response : BaseResponse<PaginatedResult<CaseVM>> { }
    }
}
