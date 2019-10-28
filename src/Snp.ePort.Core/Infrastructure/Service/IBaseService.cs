using Microsoft.Extensions.Caching.Distributed;
using Snp.ePort.Core.BaseDto;
using System.Threading;
using System.Threading.Tasks;

namespace Snp.ePort.Core.Infrastructure.Service
{
    public interface IBaseService
    {
        string Get(string key);
        Task<string> GetAsync(string key, CancellationToken token = default);
        void Refresh(string key);
        Task RefreshAsync(string key, CancellationToken token = default);
        void Remove(string key);
        Task RemoveAsync(string key, CancellationToken token = default);
        void Set(CacheDto cache);
        Task SetAsync(CacheDto cache);
    }
}