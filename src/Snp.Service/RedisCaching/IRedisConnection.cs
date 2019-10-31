using StackExchange.Redis;
using System;
using System.Net;

namespace Snp.ePort.Service.RedisCaching
{
    public interface IRedisConnection : IDisposable
    {
        IDatabase GetDatabase(int db);

        IServer GetServer(EndPoint endPoint);

        EndPoint[] GetEndPoints();

        void FlushDatabase(RedisDatabaseNumber db);
    }
}
