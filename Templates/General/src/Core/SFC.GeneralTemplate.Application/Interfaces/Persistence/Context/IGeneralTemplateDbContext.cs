namespace SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;

/// <summary>
/// Core DB context of the service.
/// </summary>
public interface IGeneralTemplateDbContext : IDbContext
{
    IQueryable<GeneralTemplateEntity> GeneralTemplateMultiple { get; }
}
