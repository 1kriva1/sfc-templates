#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Domain.Entities.Team.General;

namespace SFC.GeneralTemplate.Application.Common.Dto.Team.General;
public class TeamFinancialProfileDto : IMapFromReverse<TeamFinancialProfile>
{
    public bool FreePlay { get; set; }
}
#endif