using Microsoft.AspNetCore.Authorization;

namespace SFC.GeneralTemplate.Infrastructure.Authorization.OwnGeneralTemplate;
public class OwnGeneralTemplateRequirement : IAuthorizationRequirement
{
    public OwnGeneralTemplateRequirement() { }

    public override string ToString()
    {
        return "OwnGeneralTemplateRequirement: Requires user has be owner of resource.";
    }
}
