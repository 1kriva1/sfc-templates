#if IncludeDataInfrastructure
using SFC.GeneralTemplate.Application.Interfaces.Cache;
using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.Data;
using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.Data.Models;

namespace SFC.GeneralTemplate.Infrastructure.Services.Cache;
public class RefreshCacheService(ICache cache, IGeneralTemplateDataService generalTemplateDataService) : IRefreshCache
{
    private readonly ICache _cache = cache;
    private readonly IGeneralTemplateDataService _generalTemplateDataService = generalTemplateDataService;

    public async Task RefreshAsync(CancellationToken token = default)
    {
        GetAllGeneralTemplateDataModel model = await _generalTemplateDataService.GetAllGeneralTemplateDataAsync().ConfigureAwait(false);

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        //RefreshAsync(model., token);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    }

    private Task RefreshAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        _cache.DeleteAsync($"{typeof(T).Name}", cancellationToken);
        return _cache.SetAsync($"{typeof(T).Name}", entities, null, cancellationToken);
    }
}
#else
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
#endif