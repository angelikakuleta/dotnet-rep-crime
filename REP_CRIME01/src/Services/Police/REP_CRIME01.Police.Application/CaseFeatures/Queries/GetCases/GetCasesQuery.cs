using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Police.Application.Models;

namespace REP_CRIME01.Police.Application.CaseFeatures.Queries
{
    public static partial class GetCases
    {
        public record Query : IRequest<Response>
        {
            public CasesQueryString QueryString { get; init; }
        }

        public record Response : BaseResponse<PaginatedResult<CaseVM>> { }
    }
}
