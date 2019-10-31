using Microsoft.Extensions.DependencyInjection;
using Snp.Service.RedisCaching;

namespace Snp.Service.Service
{
    public static class ServiceRegister
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddTransient<IRedisCacheService, RedisCacheService>();
        }
    }
}