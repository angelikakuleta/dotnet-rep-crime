namespace REP_CRIME01.Police.Common.Models
{
    public record LawEnforcementsQueryString
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
        public string OrderBy { get; init; } = LawEnforcementsOrder.CODE.ToString();
    }
}
