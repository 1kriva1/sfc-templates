using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.General;
using SFC.GeneralTemplate.Infrastructure.Extensions;
using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq;
using SFC.GeneralTemplate.Messages.Commands.GeneralTemplate;

namespace SFC.GeneralTemplate.Infrastructure.Consumers.GeneralTemplate.Domain.GeneralTemplate.Seed;
public class RequireGeneralTemplateMultipleSeedConsumer(
    ILogger<RequireGeneralTemplateMultipleSeedConsumer> logger,
    IMapper mapper,
    IGeneralTemplateSeedService generalTemplateSeedService) : IConsumer<RequireGeneralTemplateMultipleSeed>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly ILogger<RequireGeneralTemplateMultipleSeedConsumer> _logger = logger;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IGeneralTemplateSeedService _generalTemplateSeedService = generalTemplateSeedService;

    public async Task Consume(ConsumeContext<RequireGeneralTemplateMultipleSeed> context)
    {
        RequireGeneralTemplateMultipleSeed message = context.Message;

        IEnumerable<GeneralTemplateEntity> generalTemplateMultiple = await _generalTemplateSeedService.GetSeedGeneralTemplateMultipleAsync().ConfigureAwait(true);

        SeedGeneralTemplateMultiple command = _mapper.Map<SeedGeneralTemplateMultiple>(generalTemplateMultiple)
                                                     .SetCommandInitiator(message.Initiator);

        await context.Publish(command).ConfigureAwait(false);
    }
}

public class RequireGeneralTemplateMultipleSeedDefinition : ConsumerDefinition<RequireGeneralTemplateMultipleSeedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.GeneralTemplate.Value.Domain.GeneralTemplate.Seed.RequireSeed; } }

    public RequireGeneralTemplateMultipleSeedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.generaltemplate.generaltemplatemultiple.seed.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireGeneralTemplateMultipleSeedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}
