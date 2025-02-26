using MediatR;

using SFC.GeneralTemplate.Domain.Events.GeneralTemplate;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Notifications.GeneralTemplateUpdated;
public class GeneralTemplateUpdatedNotificationHandler : INotificationHandler<GeneralTemplateUpdatedEvent>
{
    public Task Handle(GeneralTemplateUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
