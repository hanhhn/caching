using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Snp.ePort.Core.Exeptions;
using Snp.ePort.Core.Infrastructure.Engine;
using Snp.ePort.Core.Infrastructure.File;
using System.Collections.Generic;

namespace Snp.ePort.Api.Configurations
{
    public static class CachingConfigure
    {
        public static void AddCaching(this IServiceCollection services, IConfiguration config)
        {
            switch (config["CacheMode"])
            {
                case "SQL":
                    services.AddDistributedSqlServerCache(options =>
                    {
                        options.ConnectionString = config["DistCache_ConnectionString"];
                        options.SchemaName = "dbo";
                        options.TableName = "TestCache";
                    });
                    break;

                case "Redis":
                    var fileReader = EngineContext.Current.Resolve<IFileReader>();
                    List<string> connecting = fileReader.ReadAll();

                    if (connecting == null || connecting.Count == 0)
                    {
                        throw new NotFoundException("Can not be found redis connection string");
                    }

                    services.AddStackExchangeRedisCache(options =>
                    {
                        options.Configuration = string.Join(",", connecting);
                    });
                    break;

                default:
                    services.AddDistributedMemoryCache();
                    break;
            }

        }
    }
}
