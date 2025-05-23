using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Identity.General;
using SFC.GeneralTemplate.Domain.Entities.Identity.General;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;
using SFC.GeneralTemplate.Infrastructure.Persistence.Extensions;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Common;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Identity;
public class UserRepository(IdentityDbContext context)
    : Repository<User, IdentityDbContext, Guid>(context), IUserRepository
{
    public async Task<User[]> AddRangeIfNotExistsAsync(params User[] users)
    {
        await Context.Set<User>().AddRangeIfNotExistsAsync<User, Guid>(users).ConfigureAwait(false);

        await Context.SaveChangesAsync().ConfigureAwait(false);

        return users;
    }
}
