using Microsoft.Extensions.Caching.Distributed;
using Snp.Core.BaseDto;
using Snp.Core.Exeptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snp.Core.Infrastructure.Service
{
    public class BaseService : IBaseService
    {
        private readonly IDistributedCache _cache;

        public BaseService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public virtual string Get(string key)
        {
            return _cache.GetString(key);
        }

        public virtual Task<string> GetAsync(string key, CancellationToken token = default)
        {
            return _cache.GetStringAsync(key);
        }

        public virtual void Refresh(string key)
        {
            _cache.Refresh(key);
        }

        public virtual Task RefreshAsync(string key, CancellationToken token = default)
        {
            return _cache.RefreshAsync(key, token);
        }

        public virtual void Remove(string key)
        {
            _cache.Refresh(key);
        }

        public virtual Task RemoveAsync(string key, CancellationToken token = default)
        {
            return _cache.RemoveAsync(key, token);
        }

        public virtual void Set(CacheDto cache)
        {
            if(cache == null)
            {
                throw new InformationException("Param invalid!");
            }

            var options = new DistributedCacheEntryOptions();
            options.SetSlidingExpiration(cache.ExpireTime <= 0 ? TimeSpan.FromDays(30) : TimeSpan.FromDays(cache.ExpireTime));
            _cache.SetString(cache.Key, cache.Value, options);
        }

        public virtual Task SetAsync(CacheDto cache)
        {
            if (cache == null)
            {
                throw new InformationException("Param invalid!");
            }

            var options = new DistributedCacheEntryOptions();
            options.SetSlidingExpiration(cache.ExpireTime <= 0 ? TimeSpan.FromDays(30) : TimeSpan.FromDays(cache.ExpireTime));
            return _cache.SetStringAsync(cache.Key, cache.Value, options, cache.Token);
        }
    }
}