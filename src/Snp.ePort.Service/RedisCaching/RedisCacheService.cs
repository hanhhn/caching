using Microsoft.Extensions.Caching.Distributed;
using Snp.ePort.Core.Infrastructure.Service;

namespace Snp.ePort.Service.RedisCaching
{
    public class RedisCacheService : BaseService, IRedisCacheService
    {
        public RedisCacheService(IDistributedCache cache) : base(cache)
        {
        }
    }
}
