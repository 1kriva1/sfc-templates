#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Common;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;

namespace SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Team.General;
public interface ITeamRepository : IRepository<TeamEntity, ITeamDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<TeamEntity[]> AddRangeIfNotExistsAsync(params TeamEntity[] entities);
}
#endif