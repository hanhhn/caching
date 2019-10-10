using Microsoft.Extensions.Caching.Distributed;
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
        void Set(string key, string value);
        Task SetAsync(string key, string value, CancellationToken token = default);
    }
}