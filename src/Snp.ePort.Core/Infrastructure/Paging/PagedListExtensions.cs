using Snp.ePort.Core.Infrastructure.Engine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snp.ePort.Core.Infrastructure.Paging
{
    public static class PagedListExtensions
    {
        private static bool IsValid(int pageIndex, int pageSize)
        {
            return pageIndex >= 0 && pageSize >= 1;
        }

        public static PagedList<TSource> ToPagedList<TSource>(this IQueryable<TSource> query, int pageIndex, int pageSize)
        {
            if (!IsValid(pageIndex, pageSize))
                throw new ArgumentException(string.Format("Something wrong with pageIndex: {0} or pageSize: {1}", pageIndex, pageSize));


            int totalRecord = query.Count();
            var source = query.Skip(pageIndex * pageSize).Take(pageSize).AsEnumerable();

            return new PagedList<TSource>(source, pageIndex, pageSize, totalRecord);
        }
    }
}
