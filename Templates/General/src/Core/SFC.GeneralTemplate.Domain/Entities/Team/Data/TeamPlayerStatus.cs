#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Team.Data;
public class TeamPlayerStatus : EnumDataEntity<TeamPlayerStatusEnum>
{
    public TeamPlayerStatus() : base() { }

    public TeamPlayerStatus(TeamPlayerStatusEnum enumType) : base(enumType) { }
}
#endif