#if IncludeTeamInfrastructure
namespace SFC.GeneralTemplate.Application.Interfaces.Team.General;
public interface ITeamSeedService
{
    Task SendRequireTeamsSeedAsync(CancellationToken cancellationToken = default);
}
#endif