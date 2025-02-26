using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.GeneralTemplate.Application.Common.Settings;

namespace SFC.GeneralTemplate.Infrastructure.Extensions;
public static class RedisExtensions
{
    public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        CacheSettings settings = configuration.GetCacheSettings();

        return services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = $"{settings.InstanceName}:";
        });
    }
}
