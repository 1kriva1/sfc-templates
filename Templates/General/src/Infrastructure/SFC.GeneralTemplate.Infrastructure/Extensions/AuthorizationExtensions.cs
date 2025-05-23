using Microsoft.AspNetCore.Authorization;

using SFC.GeneralTemplate.Infrastructure.Authorization;

namespace SFC.GeneralTemplate.Infrastructure.Extensions;
public static class AuthorizationExtensions
{
    public static void AddGeneralPolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        ArgumentNullException.ThrowIfNull(options);

        PolicyModel general = AuthorizationPolicies.General(claims);
        options.AddPolicy(general.Name, general.Policy);
    }

    public static void AddOwnGeneralTemplatePolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        PolicyModel ownGeneralTemplate = AuthorizationPolicies.OwnGeneralTemplate(claims);
        options.AddPolicy(ownGeneralTemplate.Name, ownGeneralTemplate.Policy);
    }

#if IncludePlayerInfrastructure
    public static void AddOwnPlayerPolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        PolicyModel ownPlayer = AuthorizationPolicies.OwnPlayer(claims);
        options.AddPolicy(ownPlayer.Name, ownPlayer.Policy);
    }
#endif

#if IncludeTeamInfrastructure
    public static void AddOwnTeamPolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        PolicyModel ownTeam = AuthorizationPolicies.OwnTeam(claims);
        options.AddPolicy(ownTeam.Name, ownTeam.Policy);
    }
#endif
}
