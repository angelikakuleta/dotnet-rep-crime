namespace REP_CRIME01.Crime.Common.Models
{
    public record CrimeEventsQueryString
    {
        private const int maxPageSize = 50;

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
}
