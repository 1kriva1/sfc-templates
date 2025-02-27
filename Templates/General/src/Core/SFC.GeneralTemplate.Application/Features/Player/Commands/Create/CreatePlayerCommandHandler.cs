﻿#if IncludePlayerInfrastructure
using AutoMapper;

using MediatR;

using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Player;

namespace SFC.GeneralTemplate.Application.Features.Player.Commands.Create;

public class CreatePlayerCommandHandler(
    IMapper mapper,
    IPlayerRepository playerRepository) : IRequestHandler<CreatePlayerCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IPlayerRepository _playerRepository = playerRepository;

    public async Task Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        PlayerEntity player = _mapper.Map<PlayerEntity>(request.Player);

        await _playerRepository.AddAsync(player)
                               .ConfigureAwait(false);
    }
}
#endif