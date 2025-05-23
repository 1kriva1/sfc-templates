#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Domain.Common;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Common.Data;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Team.Data;
public class TeamDataRepository<TEntity, TEnum>(TeamDbContext context)
    : DataRepository<TEntity, TeamDbContext, TEnum>(context), ITeamDataRepository<TEntity, TEnum>
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }
#endif