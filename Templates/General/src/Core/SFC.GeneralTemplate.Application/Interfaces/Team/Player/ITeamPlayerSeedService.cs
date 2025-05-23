#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
namespace SFC.GeneralTemplate.Application.Interfaces.Team.Player;
public interface ITeamPlayerSeedService
{
    Task SendRequireTeamPlayersSeedAsync(CancellationToken cancellationToken = default);
}
#endif