using MediatR;

using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.General;
using SFC.GeneralTemplate.Domain.Events.GeneralTemplate;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Notifications.GeneralTemplateCreated;
public class GeneralTemplateCreatedNotificationHandler(IGeneralTemplateService generalTemplateService) : INotificationHandler<GeneralTemplateCreatedEvent>
{
    private readonly IGeneralTemplateService _generalTemplateService = generalTemplateService;

    public Task Handle(GeneralTemplateCreatedEvent notification, CancellationToken cancellationToken)
    {
        return _generalTemplateService.NotifyGeneralTemplateCreatedAsync(notification.GeneralTemplate, cancellationToken);
    }
}
