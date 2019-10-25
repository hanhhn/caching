using Microsoft.Extensions.Caching.Distributed;
using Snp.ePort.Core.Infrastructure.Service;
using StackExchange.Redis;

namespace Snp.ePort.Service.RedisCaching
{
    public class RedisCacheService : BaseService, IRedisCacheService
    {
        //private readonly IRedisConnection _connection;
        //private readonly IDatabase _db;

        public RedisCacheService(IDistributedCache cache) : base(cache)
        {
        }
    }
}
