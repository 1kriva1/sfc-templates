using MediatR;

using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.General;
using SFC.GeneralTemplate.Domain.Events.GeneralTemplate;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Notifications.GeneralTemplateUpdated;
public class GeneralTemplateUpdatedNotificationHandler(IGeneralTemplateService generalTemplateService) : INotificationHandler<GeneralTemplateUpdatedEvent>
{
    private readonly IGeneralTemplateService _generalTemplateService = generalTemplateService;

    public Task Handle(GeneralTemplateUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return _generalTemplateService.NotifyGeneralTemplateUpdatedAsync(notification.GeneralTemplate, cancellationToken);
    }
}
