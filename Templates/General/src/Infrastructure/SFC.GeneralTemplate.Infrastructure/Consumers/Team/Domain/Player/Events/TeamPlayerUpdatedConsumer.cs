#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Team.Messages.Events.Team.Player;
using SFC.GeneralTemplate.Application.Features.Team.Player.Commands.Update;
using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq;
using SFC.GeneralTemplate.Infrastructure.Extensions;

namespace SFC.GeneralTemplate.Infrastructure.Consumers.Team.Domain.Player.Events;
public class TeamPlayerUpdatedConsumer(
    IMapper mapper,
    ILogger<TeamPlayerUpdatedConsumer> logger,
    ISender mediator) : IConsumer<TeamPlayerUpdated>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<TeamPlayerUpdatedConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<TeamPlayerUpdated> context)
    {
        TeamPlayerUpdated @event = context.Message;

        UpdateTeamPlayerCommand command = _mapper.Map<UpdateTeamPlayerCommand>(@event);

        await _mediator.Send(command)
                       .ConfigureAwait(false);
    }
}

public class TeamPlayerUpdatedConsumerDefinition : ConsumerDefinition<TeamPlayerUpdatedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Team.Value.Domain.Player.Events.Updated; } }

    public TeamPlayerUpdatedConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.generaltemplate.team.player.updated.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<TeamPlayerUpdatedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.team.player.updated"
            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}
#endif