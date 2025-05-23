#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Team.General;
public abstract class BaseTeamEntity : BaseEntity<long>
{
    public TeamEntity Team { get; set; } = null!;
}
#endif