using System;
using System.Collections.Generic;

namespace REP_CRIME01.Crime.Application.Responses
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public long TotalItemsCount { get; set; }
        public long? ItemFrom { get; set; }
        public long? ItemTo { get; set; }    

        public PaginatedResult(List<T> items, long count, int pageIndex, int pageSize)
        {
            if (count < 0 || pageIndex < 1 || pageSize < 1)
            {
                throw new ArgumentException();
            }

            Items = items;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalItemsCount = count;
            ItemFrom = pageSize * (pageIndex - 1) + 1;
            ItemFrom = ItemFrom <= TotalItemsCount ? ItemFrom : null;
            ItemTo = ItemFrom != null ? Math.Min((long)(ItemFrom + pageSize - 1), TotalItemsCount) : null;
        }     
    }
}
