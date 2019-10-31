using Microsoft.Extensions.DependencyInjection;
using Snp.Service.Service;

namespace Snp.Api.Configurations
{
    public static class ServiceConfigure
    {
        public static void AddCustomServices(this IServiceCollection service)
        {
            service.AddServices();
        }
    }
}