using SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Common;

namespace SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.GeneralTemplate.General;

/// <summary>
/// Repository for core entity of the service.
/// </summary>
public interface IGeneralTemplateRepository : IRepository<GeneralTemplateEntity, IGeneralTemplateDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<GeneralTemplateEntity[]> AddRangeIfNotExistsAsync(params GeneralTemplateEntity[] entities);
}
