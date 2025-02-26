using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;
using SFC.GeneralTemplate.Infrastructure.Persistence.Extensions;
using SFC.GeneralTemplate.Infrastructure.Persistence.Interceptors;

namespace SFC.GeneralTemplate.Infrastructure.Persistence;
public static class PersistenceRegistration
{
    public static void AddPersistenceServices(this WebApplicationBuilder builder)
    {
        // contexts
        builder.Services.AddDbContext<MetadataDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<DataDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<IdentityDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<GeneralTemplateDbContext>(builder.Configuration, builder.Environment);

        // interceptors
        builder.Services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        builder.Services.AddScoped<DispatchDomainEventsSaveChangesInterceptor>();
        builder.Services.AddScoped<DataEntitySaveChangesInterceptor>();
        builder.Services.AddScoped<UserEntitySaveChangesInterceptor>();

        // contexts by interfaces
        builder.Services.AddScoped<IMetadataDbContext, MetadataDbContext>();
        builder.Services.AddScoped<IDataDbContext, DataDbContext>();
        builder.Services.AddScoped<IIdentityDbContext, IdentityDbContext>();
        builder.Services.AddScoped<IGeneralTemplateDbContext, GeneralTemplateDbContext>();

        // repositories
        builder.Services.AddRepositories(builder.Configuration);
    }
}
