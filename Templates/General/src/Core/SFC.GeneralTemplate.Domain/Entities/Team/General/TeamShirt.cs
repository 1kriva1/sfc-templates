#if IncludeTeamInfrastructure
namespace SFC.GeneralTemplate.Domain.Entities.Team.General;
public class TeamShirt : BaseTeamEntity
{
    public ShirtEnum ShirtId { get; set; }
}
#endif