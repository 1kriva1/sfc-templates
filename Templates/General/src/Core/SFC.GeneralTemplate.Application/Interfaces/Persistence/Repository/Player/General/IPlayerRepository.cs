#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Common;

namespace SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Player.General;
public interface IPlayerRepository : IRepository<PlayerEntity, IPlayerDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<PlayerEntity[]> AddRangeIfNotExistsAsync(params PlayerEntity[] entities);
}
#endif