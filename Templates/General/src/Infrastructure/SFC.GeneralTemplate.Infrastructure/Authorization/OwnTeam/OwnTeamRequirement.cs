#if IncludeTeamInfrastructure
using Microsoft.AspNetCore.Authorization;

namespace SFC.GeneralTemplate.Infrastructure.Authorization.OwnTeam;
public class OwnTeamRequirement : IAuthorizationRequirement
{
    public OwnTeamRequirement() { }

    public override string ToString()
    {
        return "OwnTeamRequirement: Requires user has be owner of resource.";
    }
}
#endif