using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.GeneralTemplate.Application.Common.Settings;
using SFC.GeneralTemplate.Application.Interfaces.Cache;
using SFC.GeneralTemplate.Infrastructure.Cache;
using SFC.GeneralTemplate.Infrastructure.Services.Cache;

namespace SFC.GeneralTemplate.Infrastructure.Extensions;
public static class CacheExtensions
{
    public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.Configure<CacheSettings>(configuration.GetSection(CacheSettings.SectionKey));
        services.AddScoped<ICache, RedisCache>();
        services.AddScoped<IRefreshCache, RefreshCacheService>();

        return services;
    }
}
