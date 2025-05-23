using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.GeneralTemplate.Application.Common.Settings;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Common;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Data;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.GeneralTemplate.General;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Identity.General;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Metadata;
#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Player.General;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Player;
#endif
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Common;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Data;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Data.Cache;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.GeneralTemplate.General;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Identity;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Metadata;
#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Team.General;
#endif
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Team.Data;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Team.Data.Cache;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Team.Player;
#endif

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
#if IncludeTeamInfrastructure
        services.AddScoped<ITeamRepository, TeamRepository>();
#endif
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
        services.AddScoped<ITeamPlayerRepository, TeamPlayerRepository>();
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
#if IncludeTeamInfrastructure
            services.AddScoped<ShirtRepository>();
            services.AddScoped<IShirtRepository, ShirtCacheRepository>();            
#endif
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
            // team
            services.AddScoped<TeamPlayerStatusRepository>();
            services.AddScoped<ITeamPlayerStatusRepository, TeamPlayerStatusCacheRepository>();
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
#if IncludeTeamInfrastructure
            services.AddScoped<IShirtRepository, ShirtRepository>();            
#endif
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
            // team
            services.AddScoped<ITeamPlayerStatusRepository, TeamPlayerStatusRepository>();
#endif
        }

        return services;
    }
}
