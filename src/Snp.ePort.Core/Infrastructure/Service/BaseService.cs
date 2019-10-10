using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snp.ePort.Core.Infrastructure.Service
{
    public class BaseService : IBaseService
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions options;

        public BaseService(IDistributedCache cache)
        {
            _cache = cache;
            options = new DistributedCacheEntryOptions();
            options.SetSlidingExpiration(TimeSpan.FromSeconds(30));
        }

        public string Get(string key)
        {
            return _cache.GetString(key);
        }

        public Task<string> GetAsync(string key, CancellationToken token = default)
        {
            return _cache.GetStringAsync(key);
        }

        public void Refresh(string key)
        {
            _cache.Refresh(key);
        }

        public Task RefreshAsync(string key, CancellationToken token = default)
        {
            return _cache.RefreshAsync(key, token);
        }

        public void Remove(string key)
        {
            _cache.Refresh(key);
        }

        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            return _cache.RemoveAsync(key, token);
        }

        public void Set(string key, string value)
        {
            _cache.SetString(key, value, options);
        }

        public Task SetAsync(string key, string value, CancellationToken token = default)
        {
            return _cache.SetStringAsync(key, value, options, token);
        }
    }
}