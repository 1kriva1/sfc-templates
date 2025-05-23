#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Application.Common.Dto.Team.General;

namespace SFC.GeneralTemplate.Application.Interfaces.Team.General;
public interface ITeamService
{
    Task<TeamDto?> GetTeamAsync(long id, CancellationToken cancellationToken = default);
}
#endif