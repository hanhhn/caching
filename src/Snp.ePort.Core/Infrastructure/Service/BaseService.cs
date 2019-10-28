using Microsoft.Extensions.Caching.Distributed;
using Snp.ePort.Core.BaseDto;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snp.ePort.Core.Infrastructure.Service
{
    public class BaseService : IBaseService
    {
        private readonly IDistributedCache _cache;

        public BaseService(IDistributedCache cache)
        {
            _cache = cache;
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

        public void Set(CacheDto cache)
        {
            var options = new DistributedCacheEntryOptions();
            options.SetSlidingExpiration(cache.ExpireTime <= 0 ? TimeSpan.FromDays(30) : TimeSpan.FromDays(cache.ExpireTime));
            _cache.SetString(cache.Key, cache.Value, options);
        }

        public Task SetAsync(CacheDto cache)
        {
            var options = new DistributedCacheEntryOptions();
            options.SetSlidingExpiration(cache.ExpireTime <= 0 ? TimeSpan.FromDays(30) : TimeSpan.FromDays(cache.ExpireTime));
            return _cache.SetStringAsync(cache.Key, cache.Value, options, cache.Token);
        }
    }
}