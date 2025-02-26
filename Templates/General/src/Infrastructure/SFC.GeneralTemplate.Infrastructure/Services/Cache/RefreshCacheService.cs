using SFC.GeneralTemplate.Application.Interfaces.Cache;

namespace SFC.GeneralTemplate.Infrastructure.Services.Cache;
public class RefreshCacheService(ICache cache) : IRefreshCache
{
    private readonly ICache _cache = cache;

    public Task RefreshAsync(CancellationToken token = default)
    {
        return Task.CompletedTask;
    }

    private Task RefreshAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        _cache.DeleteAsync($"{typeof(T).Name}", cancellationToken);
        return _cache.SetAsync($"{typeof(T).Name}", entities, null, cancellationToken);
    }
}
