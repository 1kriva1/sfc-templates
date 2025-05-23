#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Application.Common.Dto.Data;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Domain.Entities.Team.Data;

namespace SFC.GeneralTemplate.Application.Features.Team.Data.Common.Dto;
public class TeamPlayerStatusDto : DataDto, IMapTo<TeamPlayerStatus> { }
#endif