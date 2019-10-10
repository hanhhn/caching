using System.Collections.Generic;

namespace Snp.ePort.Core.Infrastructure.Paging
{
    public class PagedList<T> : IPagedList<T>
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalRecord { get; private set; }
        public int TotalPage { get; private set; }
        public IEnumerable<T> DataSource { get; private set; }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalRecord)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalRecord = totalRecord;
            TotalPage = TotalRecord / pageSize;

            if (TotalRecord % pageSize > 0)
                TotalPage++;

            DataSource = source;
        }
    }
}