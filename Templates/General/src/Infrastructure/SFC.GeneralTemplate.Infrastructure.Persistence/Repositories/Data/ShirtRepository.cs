#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Data;
using SFC.GeneralTemplate.Domain.Entities.Data;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Data;
public class ShirtRepository(DataDbContext context)
    : DataRepository<Shirt, ShirtEnum>(context), IShirtRepository
{ }
#endif