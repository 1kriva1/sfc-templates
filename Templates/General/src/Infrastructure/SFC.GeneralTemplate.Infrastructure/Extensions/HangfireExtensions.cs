using Hangfire;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.GeneralTemplate.Infrastructure.Extensions;
using SFC.GeneralTemplate.Infrastructure.Filters.Hangfire;
using SFC.GeneralTemplate.Infrastructure.Settings;

namespace SFC.GeneralTemplate.Infrastructure.Extensions;
public static class HangfireExtensions
{
    public static IServiceCollection AddHangfire(this IServiceCollection services, IConfiguration configuration)
    {
        HangfireSettings settings = configuration.GetHangfireSettings();

        // Add Hangfire services.
        services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("Hangfire"), new() { SchemaName = $"{settings.SchemaNamePrefix}_HangFire" })
                .UseFilter<AutomaticRetryAttribute>(new() { Attempts = settings.Retry.Attempts, DelaysInSeconds = settings.Retry.DelaysInSeconds })
                .UseFilter<LogJobAttribute>(new LogJobAttribute())
            );

        // Add the processing server as IHostedService
        services.AddHangfireServer();

        return services;
    }
}
