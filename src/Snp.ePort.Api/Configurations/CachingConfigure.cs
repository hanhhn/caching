using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Snp.ePort.Api.Configurations
{
    public static class CachingConfigure
    {
        public static void AddCaching(this IServiceCollection services, IWebHostEnvironment hostContext, IConfiguration config)
        {
            switch(config["CacheMode"])
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
                    services.AddStackExchangeRedisCache(options =>
                    {
                        options.Configuration = "139.180.222.250:6379";
                        options.InstanceName = "*";
                        options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions
                        {
                            Password = "@eport2019",
                        };
                    });
                    break;

                default:
                    services.AddDistributedMemoryCache();
                    break;
            }

        }
    }
}
