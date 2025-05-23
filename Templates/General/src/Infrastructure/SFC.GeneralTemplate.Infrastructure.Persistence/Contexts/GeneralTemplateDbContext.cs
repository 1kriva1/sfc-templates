using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using SFC.GeneralTemplate.Application.Interfaces.Common;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;

using SFC.GeneralTemplate.Infrastructure.Persistence.Interceptors;
using SFC.GeneralTemplate.Infrastructure.Persistence.Seeds;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;
public class GeneralTemplateDbContext(
    IDateTimeService dateTimeService,
    IHostEnvironment hostEnvironment,
    DbContextOptions<GeneralTemplateDbContext> options,
    AuditableEntitySaveChangesInterceptor auditableInterceptor,
    UserEntitySaveChangesInterceptor userEntityInterceptor,
#if IncludePlayerInfrastructure
    PlayerEntitySaveChangesInterceptor playerEntityInterceptor,
#endif
#if IncludeTeamInfrastructure
    TeamEntitySaveChangesInterceptor teamEntityInterceptor,
#endif
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<GeneralTemplateDbContext>(options, eventsInterceptor), IGeneralTemplateDbContext
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IDateTimeService _dateTimeService = dateTimeService;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly AuditableEntitySaveChangesInterceptor _auditableInterceptor = auditableInterceptor;
    private readonly UserEntitySaveChangesInterceptor _userEntityInterceptor = userEntityInterceptor;
#if IncludePlayerInfrastructure
    private readonly PlayerEntitySaveChangesInterceptor _playerEntityInterceptor = playerEntityInterceptor;
#endif
#if IncludeTeamInfrastructure
    private readonly TeamEntitySaveChangesInterceptor _teamEntityInterceptor = teamEntityInterceptor;
#endif

    #region General

    public IQueryable<GeneralTemplateEntity> GeneralTemplateMultiple => Set<GeneralTemplateEntity>();

    #endregion General
#if IncludeDataInfrastructure
    #region Data

    #endregion Data
#endif
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.DefaultSchemaName);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

#if IncludeDataInfrastructure
        // seed generaltemplate data
        modelBuilder.SeedGeneralTemplateData(_dateTimeService);
#endif
        // metadata
        MetadataDbContext.ApplyMetadataConfigurations(modelBuilder, _hostEnvironment.IsDevelopment());

        // identity
        IdentityDbContext.ApplyIdentityConfigurations(modelBuilder, Database.IsSqlServer());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableInterceptor);
        optionsBuilder.AddInterceptors(_userEntityInterceptor);
#if IncludePlayerInfrastructure
        optionsBuilder.AddInterceptors(_playerEntityInterceptor);
#endif
#if IncludeTeamInfrastructure
        optionsBuilder.AddInterceptors(_teamEntityInterceptor);
#endif
        base.OnConfiguring(optionsBuilder);
    }
}
