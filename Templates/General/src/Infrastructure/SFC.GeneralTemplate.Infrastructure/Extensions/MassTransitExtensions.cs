using System.Reflection;

using MassTransit;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SFC.GeneralTemplate.Infrastructure.Extensions;
using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq;
using SFC.GeneralTemplate.Messages.Commands;
using SFC.Identity.Messages.Commands;
#if IncludePlayerInfrastructure
using SFC.Player.Messages.Commands.Player;
#endif

namespace SFC.GeneralTemplate.Infrastructure.Extensions;
public static class MassTransitExtensions
{
    private const string EXCHANGE_ENDPOINT_SHORT_ADDRESS = "exchange";
    private const string EXCHANGE_ENDPOINT_AUTO_DELETE_PART = "autodelete";

    #region Public

    public static IServiceCollection AddMassTransit(this WebApplicationBuilder builder)
    {
        return builder.Services.AddMassTransit(masTransitConfigure =>
        {
            masTransitConfigure.AddConsumers(Assembly.GetExecutingAssembly());

            masTransitConfigure.UsingRabbitMq((context, rabbitMqConfigure) =>
            {
                RabbitMqSettings settings = builder.Configuration.GetRabbitMqSettings();

                string rabbitMqConnectionString = builder.Configuration.GetConnectionString("RabbitMq")!;

                rabbitMqConfigure.Host(new Uri(rabbitMqConnectionString), settings.Name, h =>
                {
                    h.Username(settings.Username);
                    h.Password(settings.Password);
                });

                rabbitMqConfigure.UseRetries(settings.Retry);

                rabbitMqConfigure.ConfigureEndpoints(context);

                MapEndpoints(settings.Exchanges, builder.Environment);
            });
        });
    }

    public static string BuildExchangeRoutingKey(this string initiator, string key)
        => $"{key.ToLower(System.Globalization.CultureInfo.CurrentCulture)}.{initiator.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)}";

    #endregion Public

    #region Private

    private static void MapEndpoints(RabbitMqExchangesSettings exchangesSettings, IWebHostEnvironment environment)
    {
        // "sfc.generaltemplate.data.require"
        EndpointConvention.Map<RequireData>(exchangesSettings.GeneralTemplate.Value.DataRequire.GetExchangeEndpointUri());

        if (environment.IsDevelopment())
        {
            // "sfc.identity.users.seed.require"
            EndpointConvention.Map<RequireUsersSeed>(exchangesSettings.Identity.Value.RequireUsersSeed.GetExchangeEndpointUri());
#if IncludePlayerInfrastructure
            // "sfc.player.players.seed.require"
            EndpointConvention.Map<RequirePlayersSeed>(exchangesSettings.Player.Value.RequirePlayersSeed.GetExchangeEndpointUri());
#endif
        }
    }

    private static void UseRetries(this IRabbitMqBusFactoryConfigurator configure, RabbitMqRetrySettings settings)
    {
        configure.UseDelayedRedelivery(r =>
            r.Intervals(settings.Intervals.Select(i => TimeSpan.FromMinutes(i)).ToArray()));
        configure.UseMessageRetry(r => r.Immediate(settings.Limit));
    }

    private static Uri GetExchangeEndpointUri(this Exchange exchange) =>
       new($"{EXCHANGE_ENDPOINT_SHORT_ADDRESS}:{exchange.Name}?{EXCHANGE_ENDPOINT_AUTO_DELETE_PART}={true}");

    #endregion Private
}