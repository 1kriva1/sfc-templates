#if IncludePlayerInfrastructure
namespace SFC.GeneralTemplate.Application.Interfaces.Player;
public interface IPlayerSeedService
{
    Task SendRequirePlayersSeedAsync(CancellationToken cancellationToken = default);
}
#endif