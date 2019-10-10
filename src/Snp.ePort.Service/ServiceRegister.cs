using Microsoft.Extensions.DependencyInjection;
using Snp.ePort.Service.RedisCaching;

namespace Snp.ePort.Service.Service
{
    public static class ServiceRegister
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddTransient<IRedisCacheService, RedisCacheService>();
        }
    }
}