using SFC.GeneralTemplate.Api.Infrastructure.Extensions;
using SFC.GeneralTemplate.Api.Services;
using SFC.GeneralTemplate.Infrastructure.Constants;
using SFC.GeneralTemplate.Infrastructure.Extensions;
using SFC.GeneralTemplate.Infrastructure.Settings;

namespace SFC.GeneralTemplate.Api.Infrastructure.Extensions;

public static class GrpcExtensions
{
    public static WebApplication UseGrpc(this WebApplication app)
    {
        KestrelSettings settings = app.Configuration.GetKestrelSettings();

        if (settings?.Endpoints?.TryGetValue(SettingConstants.KestrelInternalEndpoint, out KestrelEndpointSettings? endpoint) ?? false)
        {
            app.MapGrpcService<GeneralTemplateService>()
               .MapInternalService(endpoint.Url);
        }
        else
        {
            app.MapGrpcService<GeneralTemplateService>();
        }

        return app;
    }

    /// <summary>
    /// Without RequireHost WebApi and Grpc not working together
    /// RequireHost distinguish webapi and grpc by port value
    /// Also required Kestrel endpoint configuration in appSettings
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="url"></param>
    private static void MapInternalService(this GrpcServiceEndpointConventionBuilder builder, string url)
        => builder.RequireHost($"*:{new Uri(url).Port}");
}
