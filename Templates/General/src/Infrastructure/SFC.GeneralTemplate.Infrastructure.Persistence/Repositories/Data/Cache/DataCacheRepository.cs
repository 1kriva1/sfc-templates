using SFC.GeneralTemplate.Application.Interfaces.Cache;
using SFC.GeneralTemplate.Domain.Common;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Data.Cache;
public class DataCacheRepository<T, TEnum>(DataRepository<T, TEnum> repository, ICache cache)
    : CacheRepository<T, DataDbContext, TEnum>(repository, cache)
     where T : EnumDataEntity<TEnum>
     where TEnum : struct
{
    private readonly DataRepository<T, TEnum> _repository = repository;

    public Task<bool> AnyAsync(TEnum id)
    {
        return Cache.TryGet(CacheKey, out IReadOnlyList<T> list)
        ? Task.FromResult(list.Any(u => u.Id.Equals(id)))
            : _repository.AnyAsync(id);
    }

    public Task<T[]> ResetAsync(IEnumerable<T> entities) => _repository.ResetAsync(entities);
}
