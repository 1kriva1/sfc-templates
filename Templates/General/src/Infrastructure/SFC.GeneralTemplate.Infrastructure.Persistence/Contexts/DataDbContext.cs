using Microsoft.EntityFrameworkCore;

using SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;
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
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_dataEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
