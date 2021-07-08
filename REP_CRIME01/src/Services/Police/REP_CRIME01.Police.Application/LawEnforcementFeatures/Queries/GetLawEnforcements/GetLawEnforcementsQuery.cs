using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Police.Common.Models;

namespace REP_CRIME01.Police.Application.LawEnforcementFeatures.Queries
{
    public static partial class GetLawEnforcements
    {
        public record Query : IRequest<Response>
        {
            public LawEnforcementsQueryString QueryString { get; init; }
        }

        public record Response : BaseResponse<PaginatedResult<LawEnforcementVM>> { }
    }
}
