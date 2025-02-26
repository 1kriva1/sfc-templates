#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Data;
using SFC.GeneralTemplate.Domain.Entities.Data;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Data;
public class FootballPositionRepository(DataDbContext context)
    : DataRepository<FootballPosition, FootballPositionEnum>(context), IFootballPositionRepository
{ }
#endif