#if IncludePlayerInfrastructure
using Microsoft.AspNetCore.Authorization;

namespace SFC.GeneralTemplate.Infrastructure.Authorization.OwnPlayer;
public class OwnPlayerRequirement : IAuthorizationRequirement
{
    public OwnPlayerRequirement() { }

    public override string ToString()
    {
        return "OwnPlayerRequirement: Requires user has be owner of resource.";
    }
}
#endif