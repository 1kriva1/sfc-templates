using Microsoft.EntityFrameworkCore;

using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.GeneralTemplate.General;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;
using SFC.GeneralTemplate.Infrastructure.Persistence.Extensions;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Common;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.GeneralTemplate.General;
public class GeneralTemplateRepository(GeneralTemplateDbContext context)
    : Repository<GeneralTemplateEntity, GeneralTemplateDbContext, long>(context), IGeneralTemplateRepository
{
    #region Public

    public Task<bool> AnyAsync(long id)
    {
        return Context.GeneralTemplateMultiple.AnyAsync(u => u.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.GeneralTemplateMultiple.AnyAsync(u => u.Id == id && u.UserId == userId);
    }

    public async Task<GeneralTemplateEntity[]> AddRangeIfNotExistsAsync(params GeneralTemplateEntity[] entities)
    {
        await Context.Set<GeneralTemplateEntity>().AddRangeIfNotExistsAsync<GeneralTemplateEntity, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }

    #endregion Public

    #region Ovveride

    #endregion Ovveride
}
