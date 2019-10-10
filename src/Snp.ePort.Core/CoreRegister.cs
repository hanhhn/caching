using Microsoft.Extensions.DependencyInjection;
using Snp.ePort.Core.Infrastructure.Engine;

namespace Snp.ePort.Core
{
    public static class CoreRegister
    {
        public static void AddCoreService(this IServiceCollection services)
        {
            var engine = EngineContext.Current;
            engine.ConfigureServices(services.BuildServiceProvider());
        }
    }
}