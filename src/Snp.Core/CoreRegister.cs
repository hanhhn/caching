using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Snp.Core.Infrastructure.Engine;
using Snp.Core.Infrastructure.File;

namespace Snp.Core
{
    public static class CoreRegister
    {
        public static void AddCoreService(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IFileReader>(f => new FileReader(config["Connection"]));

            EngineContext.Current.ConfigureServices(services.BuildServiceProvider());
        }
    }
}