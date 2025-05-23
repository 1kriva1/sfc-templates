#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.GeneralTemplate.Domain.Entities.Team.Data;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Team.Data;
public class TeamPlayerStatusRepository(TeamDbContext context)
    : TeamDataRepository<TeamPlayerStatus, TeamPlayerStatusEnum>(context), ITeamPlayerStatusRepository
{ }
#endif