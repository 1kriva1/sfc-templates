﻿#if IncludeTeamInfrastructure
using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SFC.GeneralTemplate.Application.Features.Team.General.Commands.CreateRange;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Team.Messages.Commands.Team.General;
using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq;
using SFC.GeneralTemplate.Infrastructure.Extensions;

namespace SFC.GeneralTemplate.Infrastructure.Consumers.Team.Domain.Team.Seed;
public class SeedTeamsConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ILogger<SeedTeamsConsumer> logger,
    ISender mediator,
    ITeamRepository teamRepository) : IConsumer<SeedTeams>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ILogger<SeedTeamsConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
    private readonly ITeamRepository _teamRepository = teamRepository;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<SeedTeams> context)
    {
        if (_environment.IsDevelopment())
        {
            SeedTeams message = context.Message;

            CreateTeamsCommand command = _mapper.Map<CreateTeamsCommand>(message.Teams);

            await _mediator.Send(command)
                           .ConfigureAwait(false);
        }
    }
}

public class SeedTeamsConsumerDefinition : ConsumerDefinition<SeedTeamsConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Team.Value.Domain.Team.Seed.Seed; } }

    public SeedTeamsConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.generaltemplate.team.teams.seed.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SeedTeamsConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.RoutingKey = _settings.Exchanges.GeneralTemplate.Key.BuildExchangeRoutingKey(_settings.Exchanges.Team.Key);
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}
#endif