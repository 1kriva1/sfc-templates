using AutoMapper;

using MassTransit;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Messages.Commands.Data;
#if IncludeDataInfrastructure
using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.Data;
using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.Data.Models;
using SFC.GeneralTemplate.Infrastructure.Extensions.Messages;
using SFC.GeneralTemplate.Messages.Events.GeneralTemplate.Data;
#endif

namespace SFC.GeneralTemplate.Infrastructure.Services.Hosted;
public class DataInitializationHostedService(
    ILogger<DataInitializationHostedService> logger,
    IServiceProvider services) : BaseInitializationService(logger)
{
    private readonly IServiceProvider _services = services;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        EventId eventId = new((int)RequestId.InitData, Enum.GetName(RequestId.InitData));
        Action<ILogger, Exception?> logStartExecution = LoggerMessage.Define(LogLevel.Information, eventId,
            "Data Initialization Hosted Service running.");
        logStartExecution(Logger, null);

        using IServiceScope scope = _services.CreateScope();
#if IncludeDataInfrastructure
        // publish team data
        await PublishDataInitializedAsync(scope, cancellationToken).ConfigureAwait(false);
#endif
        // send require data
        await SendRequireDataAsync(scope, cancellationToken).ConfigureAwait(false);
    }
#if IncludeDataInfrastructure
    private static async Task PublishDataInitializedAsync(IServiceScope scope, CancellationToken cancellationToken)
    {
        IGeneralTemplateDataService generalTemplateDataService = scope.ServiceProvider.GetRequiredService<IGeneralTemplateDataService>();

        GetAllGeneralTemplateDataModel model = await generalTemplateDataService.GetAllGeneralTemplateDataAsync()
                                                         .ConfigureAwait(true);

        IMapper mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

        DataInitialized @event = mapper.BuildGeneralTemplateDataInitializedEvent(model);

        IPublishEndpoint publisher = scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();

        await publisher.Publish(@event, cancellationToken)
                       .ConfigureAwait(false);
    }
#endif
    private static Task SendRequireDataAsync(IServiceScope scope, CancellationToken cancellationToken)
    {
        // use bus because it is Initiator (reference to mass transit documentation)
        IBus bus = scope.ServiceProvider.GetRequiredService<IBus>();

        bus.Send(new SFC.GeneralTemplate.Messages.Commands.Data.RequireData(), cancellationToken);

#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
        bus.Send(new SFC.GeneralTemplate.Messages.Commands.Team.Data.RequireData(), cancellationToken);
#endif

        return Task.CompletedTask;
    }
}
