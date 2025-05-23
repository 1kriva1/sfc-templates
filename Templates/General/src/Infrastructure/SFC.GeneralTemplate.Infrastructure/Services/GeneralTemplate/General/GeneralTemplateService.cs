using AutoMapper;

using MassTransit;

using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.General;
using SFC.GeneralTemplate.Messages.Events.GeneralTemplate.General;

namespace SFC.GeneralTemplate.Infrastructure.Services.GeneralTemplate.General;
public class GeneralTemplateService(IMapper mapper, IPublishEndpoint publisher) : IGeneralTemplateService
{
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IMapper _mapper = mapper;

    public Task NotifyGeneralTemplateCreatedAsync(GeneralTemplateEntity generalTemplate, CancellationToken cancellationToken = default)
    {
        GeneralTemplateCreated @event = _mapper.Map<GeneralTemplateCreated>(generalTemplate);
        return _publisher.Publish(@event, cancellationToken);
    }

    public Task NotifyGeneralTemplateUpdatedAsync(GeneralTemplateEntity generalTemplate, CancellationToken cancellationToken = default)
    {
        GeneralTemplateUpdated @event = _mapper.Map<GeneralTemplateUpdated>(generalTemplate);
        return _publisher.Publish(@event, cancellationToken);
    }
}
