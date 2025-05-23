#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using AutoMapper;

using MediatR;

using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.GeneralTemplate.Domain.Entities.Team.Player;

namespace SFC.GeneralTemplate.Application.Features.Team.Player.Commands.Create;
public class CreateTeamPlayerHandler(
    IMapper mapper,
    ITeamPlayerRepository teamPlayerRepository)
    : IRequestHandler<CreateTeamPlayerCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerRepository _teamPlayerRepository = teamPlayerRepository;

    public async Task Handle(CreateTeamPlayerCommand request, CancellationToken cancellationToken)
    {
        TeamPlayer teamPlayer = _mapper.Map<TeamPlayer>(request.TeamPlayer);

        await _teamPlayerRepository.AddAsync(teamPlayer)
                                   .ConfigureAwait(true);
    }
}
#endif