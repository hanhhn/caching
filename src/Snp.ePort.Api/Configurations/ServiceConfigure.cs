using Microsoft.Extensions.DependencyInjection;
using Snp.ePort.Service.Service;

namespace Snp.ePort.Api.Configurations
{
    public static class ServiceConfigure
    {
        public static void AddCustomServices(this IServiceCollection service)
        {
            service.AddServices();
        }
    }
}