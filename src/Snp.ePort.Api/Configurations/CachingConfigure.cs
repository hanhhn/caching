﻿using Microsoft.AspNetCore.Hosting;
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
                        options.Configuration = "localhost:6379";
                    });
                    break;

                default:
                    services.AddDistributedMemoryCache();
                    break;
            }

        }
    }
}
