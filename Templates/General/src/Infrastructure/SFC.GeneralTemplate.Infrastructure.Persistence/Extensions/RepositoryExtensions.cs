using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.GeneralTemplate.Application.Common.Settings;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.GeneralTemplate;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Identity;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Metadata;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.GeneralTemplate;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Identity;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Metadata;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Extensions;
public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
        services.AddScoped<IMetadataRepository, MetadataRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGeneralTemplateRepository, GeneralTemplateRepository>();

        CacheSettings? cacheSettings = configuration
           .GetSection(CacheSettings.SectionKey)
           .Get<CacheSettings>();

        if (cacheSettings?.Enabled ?? false)
        {
            // data
            // example: services.AddScoped<FormationRepository>();
            // example: services.AddScoped<IFormationRepository, FormationCacheRepository>();
        }
        else
        {
            // data
            // example: services.AddScoped<IFormationRepository, FormationRepository>();
        }

        return services;
    }
}
