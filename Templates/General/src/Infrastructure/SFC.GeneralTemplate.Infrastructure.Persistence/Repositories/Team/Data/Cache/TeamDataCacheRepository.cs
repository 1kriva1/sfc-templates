#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Application.Interfaces.Cache;
using SFC.GeneralTemplate.Domain.Common;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Common.Data;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Team.Data.Cache;
public class TeamDataCacheRepository<TEntity, TEnum>(TeamDataRepository<TEntity, TEnum> repository, ICache cache)
    : DataCacheRepository<TEntity, TeamDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }
#endif