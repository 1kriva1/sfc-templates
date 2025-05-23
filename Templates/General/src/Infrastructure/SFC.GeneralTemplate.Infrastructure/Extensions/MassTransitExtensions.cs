using System.Globalization;
using System.Reflection;

using MassTransit;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SFC.GeneralTemplate.Infrastructure.Extensions;
using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq;
using SFC.GeneralTemplate.Messages.Commands.Common;
using SFC.GeneralTemplate.Messages.Commands.Data;
using SFC.GeneralTemplate.Messages.Commands.GeneralTemplate;
using SFC.GeneralTemplate.Messages.Events.GeneralTemplate.General;
using SFC.Identity.Messages.Commands;
#if IncludeDataInfrastructure
using SFC.GeneralTemplate.Messages.Events.GeneralTemplate.Data;
#endif
#if IncludePlayerInfrastructure
using SFC.Player.Messages.Commands.Player;
#endif
#if IncludeTeamInfrastructure
using SFC.Team.Messages.Commands.Team.General;
#endif
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.Team.Messages.Commands.Team.Player;
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

                rabbitMqConfigure.AddExchanges(builder.Environment, settings.Exchanges);

                rabbitMqConfigure.ConfigureEndpoints(context);

                MapEndpoints(settings.Exchanges, builder.Environment);
            });
        });
    }

    public static string BuildExchangeRoutingKey(this string initiator, string key)
        => $"{key.ToLower(CultureInfo.CurrentCulture)}.{initiator.ToString().ToLower(CultureInfo.CurrentCulture)}";

    #endregion Public

    #region Private

    private static void AddExchanges(
        this IRabbitMqBusFactoryConfigurator configure,
        IWebHostEnvironment environment,
        RabbitMqExchangesSettings exchangesSettings)
    {
#if IncludeDataInfrastructure
        // "sfc.generaltemplate.data.initialized"
        configure.AddExchange<DataInitialized>(exchangesSettings.GeneralTemplate.Value.Data.Source.Initialized);
#endif

        // "sfc.generaltemplate.generaltemplate.created"
        configure.AddExchange<GeneralTemplateCreated>(exchangesSettings.GeneralTemplate.Value.Domain.GeneralTemplate.Events.Created);

        // "sfc.generaltemplate.generaltemplate.updated"
        configure.AddExchange<GeneralTemplateUpdated>(exchangesSettings.GeneralTemplate.Value.Domain.GeneralTemplate.Events.Updated);

        if (environment.IsDevelopment())
        {
            // "sfc.generaltemplate.generaltemplatemultiple.seed"
            configure.AddExchange<SeedGeneralTemplateMultiple>(exchangesSettings.GeneralTemplate.Value.Domain.GeneralTemplate.Seed.Seed, exchangesSettings.GeneralTemplate.Key);
        }

        // exclude base command
        configure.Publish<InitiatorCommand>(p => p.Exclude = true);
    }

    private static void MapEndpoints(RabbitMqExchangesSettings exchangesSettings, IWebHostEnvironment environment)
    {
        EndpointConvention.Map<SFC.GeneralTemplate.Messages.Commands.Data.RequireData>(exchangesSettings.GeneralTemplate.Value.Data.Dependent.Data.RequireInitialize.GetExchangeEndpointUri());

#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
        EndpointConvention.Map<SFC.GeneralTemplate.Messages.Commands.Team.Data.RequireData>(exchangesSettings.GeneralTemplate.Value.Data.Dependent.Team.RequireInitialize.GetExchangeEndpointUri());

        // need extend team service before use it here
        //EndpointConvention.Map<SFC.Team.Messages.Commands.GeneralTemplate.InitializeData>(exchangesSettings.Team.Value.Data.Dependent.GeneralTemplate.Initialize.GetExchangeEndpointUri());
#endif

        if (environment.IsDevelopment())
        {
            // "sfc.identity.users.seed.require"
            EndpointConvention.Map<SFC.Identity.Messages.Commands.RequireUsersSeed>(exchangesSettings.Identity.Value.Domain.User.Seed.RequireSeed.GetExchangeEndpointUri());

#if IncludePlayerInfrastructure
            // "sfc.player.players.seed.require"
            EndpointConvention.Map<SFC.Player.Messages.Commands.Player.RequirePlayersSeed>(exchangesSettings.Player.Value.Domain.Player.Seed.RequireSeed.GetExchangeEndpointUri());
#endif

#if IncludeTeamInfrastructure
            // "sfc.team.teams.seed.require"
            EndpointConvention.Map<SFC.Team.Messages.Commands.Team.General.RequireTeamsSeed>(exchangesSettings.Team.Value.Domain.Team.Seed.RequireSeed.GetExchangeEndpointUri());
#endif

#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
            // "sfc.team.player.seed.require"
            EndpointConvention.Map<SFC.Team.Messages.Commands.Team.Player.RequireTeamPlayersSeed>(exchangesSettings.Team.Value.Domain.Player.Seed.RequireSeed.GetExchangeEndpointUri());
#endif
        }
    }

    private static void AddExchange<T>(this IRabbitMqBusFactoryConfigurator configure, Exchange exchange)
        where T : class
    {
        configure.Message<T>(x => x.SetEntityName(exchange.Name));
        configure.Publish<T>(x =>
        {
            x.AutoDelete = true;
            x.ExchangeType = exchange.Type;
        });
    }

    private static void AddExchange<T>(this IRabbitMqBusFactoryConfigurator configure, Exchange exchange, Func<SendContext<T>, string?> formatter)
        where T : class
    {
        configure.Message<T>(x => x.SetEntityName(exchange.Name));
        configure.Send<T>(x => x.UseRoutingKeyFormatter(formatter));
        configure.Publish<T>(x =>
        {
            x.AutoDelete = true;
            x.ExchangeType = exchange.Type;
        });
    }

    private static void AddExchange<T>(this IRabbitMqBusFactoryConfigurator configure, Exchange exchange, string key)
        where T : InitiatorCommand
    {
        configure.Message<T>(x => x.SetEntityName(exchange.Name));
        configure.Send<T>(x => x.UseRoutingKeyFormatter(context => context.Message.Initiator.BuildExchangeRoutingKey(key)));
        configure.Publish<T>(x =>
        {
            x.AutoDelete = true;
            x.ExchangeType = exchange.Type;
        });
    }

    private static void UseRetries(this IRabbitMqBusFactoryConfigurator configure, RabbitMqRetrySettings settings)
    {
        configure.UseDelayedRedelivery(r =>
            r.Intervals(settings.Intervals.Select(i => TimeSpan.FromMinutes(i)).ToArray()));
        configure.UseMessageRetry(r => r.Immediate(settings.Limit));
    }

    private static Uri GetExchangeEndpointUri(this Message exchange) =>
       new($"{EXCHANGE_ENDPOINT_SHORT_ADDRESS}:{exchange.Name}?{EXCHANGE_ENDPOINT_AUTO_DELETE_PART}={true}");

#endregion Private
}