using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.GeneralTemplate.Application.Common.Settings;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Data;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.GeneralTemplate;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Identity;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Metadata;
#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Player;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Player;
#endif
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Data;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Data.Cache;
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
#if IncludePlayerInfrastructure
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<IGeneralTemplateRepository, GeneralTemplateRepository>();
#endif

        CacheSettings? cacheSettings = configuration
           .GetSection(CacheSettings.SectionKey)
           .Get<CacheSettings>();

        if (cacheSettings?.Enabled ?? false)
        {
            // data
#if IncludePlayerInfrastructure
            services.AddScoped<FootballPositionRepository>();
            services.AddScoped<IFootballPositionRepository, FootballPositionCacheRepository>();
            services.AddScoped<GameStyleRepository>();
            services.AddScoped<IGameStyleRepository, GameStyleCacheRepository>();
            services.AddScoped<StatCategoryRepository>();
            services.AddScoped<IStatCategoryRepository, StatCategoryCacheRepository>();
            services.AddScoped<StatSkillRepository>();
            services.AddScoped<IStatSkillRepository, StatSkillCacheRepository>();
            services.AddScoped<StatTypeRepository>();
            services.AddScoped<IStatTypeRepository, StatTypeCacheRepository>();
            services.AddScoped<WorkingFootRepository>();
            services.AddScoped<IWorkingFootRepository, WorkingFootCacheRepository>();
#endif
        }
        else
        {
            // data
#if IncludePlayerInfrastructure
            services.AddScoped<IFootballPositionRepository, FootballPositionRepository>();
            services.AddScoped<IGameStyleRepository, GameStyleRepository>();
            services.AddScoped<IStatCategoryRepository, StatCategoryRepository>();
            services.AddScoped<IStatSkillRepository, StatSkillRepository>();
            services.AddScoped<IStatTypeRepository, StatTypeRepository>();
            services.AddScoped<IWorkingFootRepository, WorkingFootRepository>();
#endif
        }

        return services;
    }
}
