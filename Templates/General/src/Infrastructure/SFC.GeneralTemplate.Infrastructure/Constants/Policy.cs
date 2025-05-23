namespace SFC.GeneralTemplate.Infrastructure.Constants;
public static class Policy
{
    public const string General = "General";
    public const string OwnGeneralTemplate = "GeneralTemplate";
#if IncludePlayerInfrastructure
    public const string OwnPlayer = "Player";
#endif
#if IncludeTeamInfrastructure
    public const string OwnTeam = "Team";
#endif
}
