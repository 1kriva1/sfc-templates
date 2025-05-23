#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Domain.Entities.Team.Data;

namespace SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Team.Data;
public interface ITeamPlayerStatusRepository : ITeamDataRepository<TeamPlayerStatus, TeamPlayerStatusEnum> { }
#endif