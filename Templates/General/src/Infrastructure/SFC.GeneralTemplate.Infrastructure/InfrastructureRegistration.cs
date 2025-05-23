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
using Microsoft.AspNetCore.Authorization;
using SFC.GeneralTemplate.Infrastructure.Authorization.OwnGeneralTemplate;
using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.General;
using SFC.GeneralTemplate.Infrastructure.Services.GeneralTemplate.General;
#if IncludeDataInfrastructure
using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.Data;
using SFC.GeneralTemplate.Infrastructure.Services.GeneralTemplate.Data;
#endif
#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Interfaces.Player;
using SFC.GeneralTemplate.Infrastructure.Services.Player;
using SFC.GeneralTemplate.Infrastructure.Authorization.OwnPlayer;
#endif
#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Infrastructure.Authorization.OwnTeam;
using SFC.GeneralTemplate.Application.Interfaces.Team.General;
using SFC.GeneralTemplate.Infrastructure.Services.Team.General;
#endif
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Application.Interfaces.Team.Player;
using SFC.GeneralTemplate.Infrastructure.Services.Team.Player;
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
#if IncludeDataInfrastructure
        builder.Services.AddTransient<IGeneralTemplateDataService, GeneralTemplateDataService>();
#endif
#if IncludePlayerInfrastructure
        builder.Services.AddTransient<IPlayerSeedService, PlayerSeedService>();
#endif
#if IncludeTeamInfrastructure
        builder.Services.AddTransient<ITeamSeedService, TeamSeedService>();
#endif
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
        builder.Services.AddTransient<ITeamPlayerSeedService, TeamPlayerSeedService>();
#endif
        builder.Services.AddTransient<IGeneralTemplateService, Services.GeneralTemplate.General.GeneralTemplateService>();
        builder.Services.AddTransient<IGeneralTemplateSeedService, GeneralTemplateSeedService>();

        // grpc
        builder.Services.AddTransient<IIdentityService, IdentityService>();
#if IncludePlayerInfrastructure
        builder.Services.AddTransient<IPlayerService, PlayerService>();
#endif
#if IncludeTeamInfrastructure
        builder.Services.AddTransient<ITeamService, TeamService>();
#endif

        // references
        builder.Services.AddScoped<IIdentityReference, IdentityReference>();
#if IncludePlayerInfrastructure
        builder.Services.AddScoped<IPlayerReference, PlayerReference>();
#endif
#if IncludeTeamInfrastructure
        builder.Services.AddScoped<ITeamReference, TeamReference>();
#endif

        // hosted services
        builder.Services.AddHostedService<DatabaseResetHostedService>();
        builder.Services.AddHostedService<DataInitializationHostedService>();
        builder.Services.AddHostedService<JobsInitializationHostedService>();

        // authorization
        builder.Services.AddScoped<IAuthorizationHandler, OwnGeneralTemplateHandler>();
#if IncludePlayerInfrastructure
        builder.Services.AddScoped<IAuthorizationHandler, OwnPlayerHandler>();
#endif
#if IncludeTeamInfrastructure
        builder.Services.AddScoped<IAuthorizationHandler, OwnTeamHandler>();
#endif
    }
}
