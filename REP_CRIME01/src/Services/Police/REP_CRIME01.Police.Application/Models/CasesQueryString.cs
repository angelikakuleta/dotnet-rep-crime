namespace REP_CRIME01.Police.Application.Models
{
    public record CasesQueryString
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
        public string OrderBy { get; init; } = CasesOrder.CRIMEDATE_DESC.ToString();
    }
}
