using Microsoft.Extensions.Caching.Distributed;
using Snp.Core.Infrastructure.Service;

namespace Snp.Service.RedisCaching
{
    public class RedisCacheService : BaseService, IRedisCacheService
    {
        public RedisCacheService(IDistributedCache cache) : base(cache)
        {
        }
    }
}
