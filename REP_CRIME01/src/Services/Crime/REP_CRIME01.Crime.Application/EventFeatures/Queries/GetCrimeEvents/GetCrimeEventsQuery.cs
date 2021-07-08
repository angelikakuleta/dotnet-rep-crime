using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Crime.Common.Models;

namespace REP_CRIME01.Crime.Application.EventFeatures.Queries
{
    public static partial class GetCrimeEvents
    {
        public record Query : IRequest<Response>
        {
            public CrimeEventsQueryString CrimeEventsQueryString { get; init; }
        }

        public record Response : BaseResponse<PaginatedResult<CrimeEventVM>> { }
    }
}
