#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Entities.Data;

namespace SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Data;
public interface IStatCategoryRepository : IDataRepository<StatCategory, StatCategoryEnum> { }
#endif