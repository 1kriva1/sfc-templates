#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Application.Interfaces.Cache;
using SFC.GeneralTemplate.Domain.Entities.Team.Data;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Team.Data;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Team.Data.Cache;
public class TeamPlayerStatusCacheRepository(TeamPlayerStatusRepository repository, ICache cache)
    : TeamDataCacheRepository<TeamPlayerStatus, TeamPlayerStatusEnum>(repository, cache), ITeamPlayerStatusRepository
{ }
#endif