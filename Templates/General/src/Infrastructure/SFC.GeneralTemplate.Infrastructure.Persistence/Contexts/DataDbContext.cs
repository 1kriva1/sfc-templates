using Microsoft.EntityFrameworkCore;

using SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;
using SFC.GeneralTemplate.Domain.Entities.Data;
#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Data;
#endif
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;
using SFC.GeneralTemplate.Infrastructure.Persistence.Interceptors;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;
public class DataDbContext(
    DbContextOptions<DataDbContext> options,
    DataEntitySaveChangesInterceptor dataEntityInterceptor,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<DataDbContext>(options, eventsInterceptor), IDataDbContext
{
    private readonly DataEntitySaveChangesInterceptor _dataEntityInterceptor = dataEntityInterceptor;
#if IncludePlayerInfrastructure
    public IQueryable<GameStyle> GameStyles => Set<GameStyle>();

    public IQueryable<FootballPosition> FootballPositions => Set<FootballPosition>();

    public IQueryable<StatCategory> StatCategories => Set<StatCategory>();

    public IQueryable<StatSkill> StatSkills => Set<StatSkill>();

    public IQueryable<StatType> StatTypes => Set<StatType>();

    public IQueryable<WorkingFoot> WorkingFoots => Set<WorkingFoot>();
#endif

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.DataSchemaName);

        // data
        ApplyDataConfigurations(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Example:
    /// modelBuilder.ApplyConfiguration(new ShirtConfiguration());
    /// </summary>
    /// <param name="modelBuilder">Model builder</param>
    public static void ApplyDataConfigurations(ModelBuilder modelBuilder)
    {
        // add data configurations
#if IncludePlayerInfrastructure
        modelBuilder.ApplyConfiguration(new GameStyleConfiguration());

        modelBuilder.ApplyConfiguration(new FootballPositionConfiguration());

        modelBuilder.ApplyConfiguration(new StatCategoryConfiguration());

        modelBuilder.ApplyConfiguration(new StatSkillConfiguration());

        modelBuilder.ApplyConfiguration(new StatTypeConfiguration());

        modelBuilder.ApplyConfiguration(new WorkingFootConfiguration());
#endif
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_dataEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
