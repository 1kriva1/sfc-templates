using Microsoft.AspNetCore.Http;

using SFC.GeneralTemplate.Application.Interfaces.Identity;
using SFC.GeneralTemplate.Infrastructure.Extensions;

namespace SFC.GeneralTemplate.Infrastructure.Services.Identity;
public class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Guid? GetUserId() => _httpContextAccessor.GetUserId();
}
