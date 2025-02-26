#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Entities.Data;

namespace SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Data;
public interface IGameStyleRepository : IDataRepository<GameStyle, GameStyleEnum> { }
#endif