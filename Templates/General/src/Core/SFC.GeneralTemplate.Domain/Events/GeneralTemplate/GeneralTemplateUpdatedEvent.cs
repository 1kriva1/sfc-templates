using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Events.GeneralTemplate;
public class GeneralTemplateUpdatedEvent(GeneralTemplateEntity entity) : BaseEvent
{
    public GeneralTemplateEntity GeneralTemplate { get; } = entity;
}
