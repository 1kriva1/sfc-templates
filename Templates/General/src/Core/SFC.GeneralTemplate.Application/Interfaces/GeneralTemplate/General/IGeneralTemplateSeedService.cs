namespace SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.General;
public interface IGeneralTemplateSeedService
{
    Task<IEnumerable<GeneralTemplateEntity>> GetSeedGeneralTemplateMultipleAsync();

    Task SeedGeneralTemplateMultipleAsync(CancellationToken cancellationToken = default);
}
