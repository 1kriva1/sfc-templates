﻿namespace SFC.GeneralTemplate.Infrastructure.Constants;
public static class Endpoint
{
    public const string Identity = "identity";
#if IncludePlayerInfrastructure
    public const string Player = "player";
#endif
#if IncludeTeamInfrastructure
    public const string Team = "team";
#endif
}
