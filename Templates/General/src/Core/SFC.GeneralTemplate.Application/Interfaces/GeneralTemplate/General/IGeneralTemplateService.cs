namespace SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.General;
public interface IGeneralTemplateService
{
    Task NotifyGeneralTemplateCreatedAsync(GeneralTemplateEntity generalTemplate, CancellationToken cancellationToken = default);

    Task NotifyGeneralTemplateUpdatedAsync(GeneralTemplateEntity generalTemplate, CancellationToken cancellationToken = default);
}
