#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Domain.Entities.Data;

namespace SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Data;
public interface IShirtRepository : IDataRepository<Shirt, ShirtEnum> { }
#endif
