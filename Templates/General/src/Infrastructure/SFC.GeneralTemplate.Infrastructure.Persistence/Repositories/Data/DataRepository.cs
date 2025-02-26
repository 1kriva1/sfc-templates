using Microsoft.EntityFrameworkCore;

using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Data;
using SFC.GeneralTemplate.Domain.Common;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;
using SFC.GeneralTemplate.Infrastructure.Persistence.Extensions;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Data;
public class DataRepository<T, TEnum>(DataDbContext context) : Repository<T, DataDbContext, TEnum>(context), IDataRepository<T, TEnum>
     where T : EnumDataEntity<TEnum>
     where TEnum : struct
{
    public virtual Task<bool> AnyAsync(TEnum id)
    {
        return Context.Set<T>().AnyAsync(u => u.Id.Equals(id));
    }

    public Task<T[]> ResetAsync(IEnumerable<T> entities)
    {
        Context.Clear<T>();

        return AddRangeAsync(entities.ToArray());
    }
}
