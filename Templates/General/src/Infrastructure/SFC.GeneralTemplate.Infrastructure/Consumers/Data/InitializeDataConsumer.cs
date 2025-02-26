using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.GeneralTemplate.Application.Features.Data.Commands.Reset;
using SFC.GeneralTemplate.Infrastructure.Extensions;
using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq;
using SFC.GeneralTemplate.Messages.Commands;

namespace SFC.GeneralTemplate.Infrastructure.Consumers.Data;
public class InitializeDataConsumer(
    IMapper mapper,
    ILogger<InitializeDataConsumer> logger,
    ISender mediator) : IConsumer<InitializeData>
{
    private readonly IMapper _mapper = mapper;
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly ILogger<InitializeDataConsumer> _logger = logger;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly ISender _mediator = mediator;

    public async Task Consume(ConsumeContext<InitializeData> context)
    {
        InitializeData message = context.Message;

        ResetDataCommand command = _mapper.Map<ResetDataCommand>(message);

        await _mediator.Send(command)
                       .ConfigureAwait(false);
    }
}

public class RequireDataConsumerDefinition : ConsumerDefinition<InitializeDataConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.GeneralTemplate.Value.DataInit; } }

    public RequireDataConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.generaltemplate.data.initialize.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<InitializeDataConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.generaltemplate.data.init"
            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}
