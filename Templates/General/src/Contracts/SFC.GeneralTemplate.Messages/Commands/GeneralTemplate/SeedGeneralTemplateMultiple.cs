using SFC.GeneralTemplate.Messages.Commands.Common;

namespace SFC.GeneralTemplate.Messages.Commands.GeneralTemplate;
public class SeedGeneralTemplateMultiple : InitiatorCommand
{
    public IEnumerable<GeneralTemplateEntity> GeneralTemplateMultiple { get; init; } = [];
}
