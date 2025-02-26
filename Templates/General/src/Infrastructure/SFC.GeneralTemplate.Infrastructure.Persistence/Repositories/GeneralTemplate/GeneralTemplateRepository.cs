using Microsoft.EntityFrameworkCore;

using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.GeneralTemplate;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.GeneralTemplate;
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

    #endregion Public

    #region Ovveride

    #endregion Ovveride
}
