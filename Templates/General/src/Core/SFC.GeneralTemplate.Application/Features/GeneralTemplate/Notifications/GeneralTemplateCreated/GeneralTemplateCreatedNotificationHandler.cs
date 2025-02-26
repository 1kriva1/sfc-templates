using MediatR;

using SFC.GeneralTemplate.Domain.Events.GeneralTemplate;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Notifications.GeneralTemplateCreated;
public class GeneralTemplateCreatedNotificationHandler : INotificationHandler<GeneralTemplateCreatedEvent>
{
    public Task Handle(GeneralTemplateCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
