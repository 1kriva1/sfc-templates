using Microsoft.AspNetCore.Authorization;

namespace SFC.GeneralTemplate.Infrastructure.Authorization;
public class PolicyModel
{
    public string Name { get; set; } = default!;

    public AuthorizationPolicy Policy { get; set; } = default!;
}
