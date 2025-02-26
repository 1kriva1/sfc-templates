#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Interfaces.Cache;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Data;
using SFC.GeneralTemplate.Domain.Entities.Data;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Data.Cache;
public class GameStyleCacheRepository(GameStyleRepository repository, ICache cache)
    : DataCacheRepository<GameStyle, GameStyleEnum>(repository, cache), IGameStyleRepository
{ }
#endif