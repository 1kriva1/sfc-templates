using SFC.GeneralTemplate.Domain.Entities.Identity;

namespace SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;

/// <summary>
/// Identity service related entities.
/// </summary>
public interface IIdentityDbContext : IDbContext
{
    IQueryable<User> Users { get; }
}
