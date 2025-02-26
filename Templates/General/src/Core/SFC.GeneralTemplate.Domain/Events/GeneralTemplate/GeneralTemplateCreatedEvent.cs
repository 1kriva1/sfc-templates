using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Events.GeneralTemplate;
public class GeneralTemplateCreatedEvent(GeneralTemplateEntity entity) : BaseEvent
{
    public GeneralTemplateEntity GeneralTemplate { get; } = entity;
}
