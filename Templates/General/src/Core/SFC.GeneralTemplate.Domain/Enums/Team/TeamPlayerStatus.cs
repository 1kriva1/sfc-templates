#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
namespace SFC.GeneralTemplate.Domain.Enums.Team;
public enum TeamPlayerStatus
{
    Active = 0,
    Injured = 1,
    Retired = 2,
    Unavailable = 3,
    Removed = 4
}
#endif