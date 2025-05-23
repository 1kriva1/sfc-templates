#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Application.Common.Dto.Team.General;

namespace SFC.GeneralTemplate.Application.Interfaces.Reference;
public interface ITeamReference : IReference<TeamEntity, long, TeamDto> { }
#endif
