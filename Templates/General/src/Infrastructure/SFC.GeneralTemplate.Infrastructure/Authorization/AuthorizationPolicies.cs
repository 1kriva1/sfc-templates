using Microsoft.AspNetCore.Authorization;

using SFC.GeneralTemplate.Infrastructure.Authorization.OwnGeneralTemplate;
using SFC.GeneralTemplate.Infrastructure.Constants;
#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Infrastructure.Authorization.OwnPlayer;
#endif

namespace SFC.GeneralTemplate.Infrastructure.Authorization;
public static class AuthorizationPolicies
{
    #region Public

    public static PolicyModel General(IDictionary<string, IEnumerable<string>> claims)
    {
        ArgumentNullException.ThrowIfNull(claims);

        AuthorizationPolicyBuilder builder = GetGeneralPolicyBuilder(claims);
        return BuildPolicyModel(Policy.General, builder);
    }

    public static PolicyModel OwnGeneralTemplate(IDictionary<string, IEnumerable<string>> claims)
    {
        AuthorizationPolicyBuilder builder = GetGeneralPolicyBuilder(claims)
            .AddRequirements(new OwnGeneralTemplateRequirement());

        return BuildPolicyModel(Policy.OwnGeneralTemplate, builder);
    }

#if IncludePlayerInfrastructure
    public static PolicyModel OwnPlayer(IDictionary<string, IEnumerable<string>> claims)
    {
        AuthorizationPolicyBuilder builder = GetGeneralPolicyBuilder(claims)
            .AddRequirements(new OwnPlayerRequirement());

        return BuildPolicyModel(Policy.OwnPlayer, builder);
    }
#endif


    #endregion Public

    #region Private

    private static AuthorizationPolicyBuilder GetGeneralPolicyBuilder(IDictionary<string, IEnumerable<string>> claims)
    {
        AuthorizationPolicyBuilder builder = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser();

        foreach (KeyValuePair<string, IEnumerable<string>> claim in claims)
        {
            builder.RequireClaim(claim.Key, claim.Value);
        }

        return builder;
    }

    private static PolicyModel BuildPolicyModel(string name, AuthorizationPolicyBuilder builder)
    {
        return new PolicyModel { Name = name, Policy = builder.Build() };
    }

    #endregion Private
}