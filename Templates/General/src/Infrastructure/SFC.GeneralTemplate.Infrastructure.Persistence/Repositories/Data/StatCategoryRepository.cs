#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Data;
using SFC.GeneralTemplate.Domain.Entities.Data;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Data;
public class StatCategoryRepository(DataDbContext context)
    : DataRepository<StatCategory, StatCategoryEnum>(context), IStatCategoryRepository
{ }
#endif