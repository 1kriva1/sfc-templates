using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.GeneralTemplate;
using SFC.GeneralTemplate.Infrastructure.Extensions;

namespace SFC.GeneralTemplate.Infrastructure.Authorization.OwnGeneralTemplate;
public class OwnGeneralTemplateHandler(IGeneralTemplateRepository generalTemplateRepository, IHttpContextAccessor httpContextAccessor)
    : AuthorizationHandler<OwnGeneralTemplateRequirement>
{
    private readonly IGeneralTemplateRepository _generalTemplateRepository = generalTemplateRepository;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnGeneralTemplateRequirement requirement)
    {
        string? generalTemplateIdValue = _httpContextAccessor.HttpContext?.GetRouteValue("id")?.ToString();

        if (!long.TryParse(generalTemplateIdValue, out long generalTemplateId))
        {
            context.Fail(new AuthorizationFailureReason(this, "Route does not have \"id\" parameter value."));
            return;
        }

        Guid? userId = _httpContextAccessor.GetUserId();

        if (!userId.HasValue)
        {
            context.Fail(new AuthorizationFailureReason(this, "User does not have NameIdentifier claim value."));
            return;
        }

        if (!await _generalTemplateRepository.AnyAsync(generalTemplateId, userId.Value).ConfigureAwait(true))
        {
            context.Fail(new AuthorizationFailureReason(this, $"User - {userId} does not related to this resource - {generalTemplateId}."));
            return;
        }

        context.Succeed(requirement);
    }
}
