using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Crime.Application.Models;

namespace REP_CRIME01.Crime.Application.EventFeatures.Queries
{
    public static partial class GetCrimeEvents
    {
        const int maxPageSize = 50;

        public record Query : IRequest<Response>
        {
            private int _pageSize = 10;

            public string SearchPhrase { get; init; }
            public int PageIndex { get; init; } = 1;
            public int PageSize
            { 
                get => _pageSize;
                init
                {
                    _pageSize = (value > maxPageSize) ? maxPageSize : value;
                }
            }
            public string OrderBy { get; init; } = CrimeEventsOrder.EVENTDATE_DESC.ToString();
        }

        public record Response : BaseResponse<PaginatedResult<CrimeEventVM>> { }
    }
}
