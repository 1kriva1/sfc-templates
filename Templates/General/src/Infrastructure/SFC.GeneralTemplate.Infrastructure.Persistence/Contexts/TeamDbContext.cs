#if IncludeTeamInfrastructure
using Microsoft.EntityFrameworkCore;

using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;
using SFC.GeneralTemplate.Infrastructure.Persistence.Interceptors;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;
using SFC.GeneralTemplate.Domain.Entities.Team.General;
using SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Team.General;
#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Entities.Team.Data;
using SFC.GeneralTemplate.Domain.Entities.Team.Player;
using SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Team.Data;
using SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Team.Player;
#endif

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;
public class TeamDbContext(
    DbContextOptions<TeamDbContext> options,
    AuditableEntitySaveChangesInterceptor auditableInterceptor,
    DataEntitySaveChangesInterceptor dataEntityInterceptor,
    UserEntitySaveChangesInterceptor userEntityInterceptor,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<TeamDbContext>(options, eventsInterceptor), ITeamDbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableInterceptor = auditableInterceptor;
    private readonly DataEntitySaveChangesInterceptor _dataEntityInterceptor = dataEntityInterceptor;
    private readonly UserEntitySaveChangesInterceptor _userEntityInterceptor = userEntityInterceptor;

    #region General

    public IQueryable<TeamEntity> Teams => Set<TeamEntity>();

    public IQueryable<TeamGeneralProfile> GeneralProfiles => Set<TeamGeneralProfile>();

    public IQueryable<TeamFinancialProfile> FinancialProfiles => Set<TeamFinancialProfile>();

    public IQueryable<TeamAvailability> Availability => Set<TeamAvailability>();

    public IQueryable<TeamTag> Tags => Set<TeamTag>();

    public IQueryable<TeamShirt> Shirts => Set<TeamShirt>();

    public IQueryable<TeamLogo> Logos => Set<TeamLogo>();

#if IncludePlayerInfrastructure
    public IQueryable<TeamPlayer> TeamPlayers => Set<TeamPlayer>();
#endif

    #endregion General

    #region Data

#if IncludePlayerInfrastructure
    public IQueryable<TeamPlayerStatus> TeamPlayerStatuses => Set<TeamPlayerStatus>();
#endif

    #endregion Data

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.TeamSchemaName);

        // data
        DataDbContext.ApplyDataConfigurations(modelBuilder);

        // identity
        IdentityDbContext.ApplyIdentityConfigurations(modelBuilder, Database.IsSqlServer());

#if IncludePlayerInfrastructure
        // player
        PlayerDbContext.ApplyPlayerConfigurations(modelBuilder);
#endif

        // team
        ApplyTeamConfigurations(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableInterceptor);
        optionsBuilder.AddInterceptors(_dataEntityInterceptor);
        optionsBuilder.AddInterceptors(_userEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    public static void ApplyTeamConfigurations(ModelBuilder modelBuilder)
    {
#if IncludePlayerInfrastructure
        modelBuilder.ApplyConfiguration(new TeamPlayerStatusConfiguration());

        modelBuilder.ApplyConfiguration(new TeamPlayerConfiguration());
#endif

        modelBuilder.ApplyConfiguration(new TeamAvailabilityConfiguration());

        modelBuilder.ApplyConfiguration(new TeamConfiguration());

        modelBuilder.ApplyConfiguration(new TeamFinancialProfileConfiguration());

        modelBuilder.ApplyConfiguration(new TeamGeneralProfileConfiguration());

        modelBuilder.ApplyConfiguration(new TeamLogoConfiguration());        

        modelBuilder.ApplyConfiguration(new TeamShirtConfiguration());

        modelBuilder.ApplyConfiguration(new TeamTagConfiguration());
    }
}
#endif