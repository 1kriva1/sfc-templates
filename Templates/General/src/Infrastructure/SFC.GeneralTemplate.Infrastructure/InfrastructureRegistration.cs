using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using SFC.GeneralTemplate.Infrastructure.Extensions;
using SFC.GeneralTemplate.Infrastructure.Extensions.Grpc;
using SFC.GeneralTemplate.Application.Interfaces.Common;
using SFC.GeneralTemplate.Infrastructure.Services.Common;
using SFC.GeneralTemplate.Application.Interfaces.Metadata;
using SFC.GeneralTemplate.Application.Interfaces.Identity;
using SFC.GeneralTemplate.Infrastructure.Services.Identity;
using SFC.GeneralTemplate.Infrastructure.Services.Metadata;
using SFC.GeneralTemplate.Application.Interfaces.Reference;
using SFC.GeneralTemplate.Infrastructure.Services.Reference;
using SFC.GeneralTemplate.Infrastructure.Services.Hosted;
#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Interfaces.Player;
using SFC.GeneralTemplate.Infrastructure.Services.Player;
#endif

namespace SFC.GeneralTemplate.Infrastructure;
public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        builder.Services.AddHangfire(builder.Configuration);

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddAccessTokenManagement();

        builder.Services.AddRedis(builder.Configuration);

        builder.AddMassTransit();

        builder.Services.AddCache(builder.Configuration);

        builder.Services.AddGrpc(builder.Configuration, builder.Environment);

        builder.Services.AddSingleton<IUriService>(o =>
        {
            IHttpContextAccessor accessor = o.GetRequiredService<IHttpContextAccessor>();
            HttpRequest request = accessor.HttpContext!.Request;
            return new UriService(string.Concat(request.Scheme, "://", request.Host.ToUriComponent()));
        });

        // custom services
        builder.Services.AddTransient<IMetadataService, MetadataService>();
        builder.Services.AddTransient<IDateTimeService, DateTimeService>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IUserSeedService, UserSeedService>();
#if IncludePlayerInfrastructure
        builder.Services.AddTransient<IPlayerSeedService, PlayerSeedService>();
#endif

        // grpc
        builder.Services.AddTransient<IIdentityService, IdentityService>();
#if IncludePlayerInfrastructure
        builder.Services.AddTransient<IPlayerService, PlayerService>();
#endif

        // references
        builder.Services.AddScoped<IIdentityReference, IdentityReference>();
#if IncludePlayerInfrastructure
        builder.Services.AddScoped<IPlayerReference, PlayerReference>();
#endif

        // hosted services
        builder.Services.AddHostedService<DatabaseResetHostedService>();
        builder.Services.AddHostedService<DataInitializationHostedService>();
        builder.Services.AddHostedService<JobsInitializationHostedService>();

        // authorization
    }
}
