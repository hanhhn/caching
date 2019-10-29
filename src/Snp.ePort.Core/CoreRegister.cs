using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Snp.ePort.Core.Infrastructure.Engine;
using Snp.ePort.Core.Infrastructure.File;

namespace Snp.ePort.Core
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