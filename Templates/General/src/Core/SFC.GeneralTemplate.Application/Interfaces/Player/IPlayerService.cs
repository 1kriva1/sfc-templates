#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Common.Dto.Player.General;

namespace SFC.GeneralTemplate.Application.Interfaces.Player;
public interface IPlayerService
{
    Task<PlayerDto?> GetPlayerAsync(long id, CancellationToken cancellationToken = default);
}
#endif