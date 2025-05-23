﻿using AutoMapper;

using MediatR;

using SFC.GeneralTemplate.Domain.Events.Data;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Data;
#if (IncludePlayerInfrastructure || IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Domain.Entities.Data;
#endif
namespace SFC.GeneralTemplate.Application.Features.Data.Commands.Reset;
#if (IncludePlayerInfrastructure || IncludeTeamInfrastructure)
#if (IncludePlayerInfrastructure && !IncludeTeamInfrastructure)
    public class ResetDataCommandHandler(
    IMapper mapper,
    IMediator mediator,
    IFootballPositionRepository positionsRepository,
    IGameStyleRepository gameStylesRepository,
    IStatCategoryRepository statCategoriesRepository,
    IStatSkillRepository statSkillsRepository,
    IStatTypeRepository statTypesRepository,
    IWorkingFootRepository workingFootsRepository) : IRequestHandler<ResetDataCommand>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMediator _mediator = mediator;
    private readonly IFootballPositionRepository _positionsRepository = positionsRepository;
    private readonly IGameStyleRepository _gameStylesRepository = gameStylesRepository;
    private readonly IStatCategoryRepository _statCategoriesRepository = statCategoriesRepository;
    private readonly IStatSkillRepository _statSkillsRepository = statSkillsRepository;
    private readonly IStatTypeRepository _statTypesRepository = statTypesRepository;
    private readonly IWorkingFootRepository _workingFootsRepository = workingFootsRepository;

    public async Task Handle(ResetDataCommand request, CancellationToken cancellationToken)
    {
        await _positionsRepository.ResetAsync(_mapper.Map<IEnumerable<FootballPosition>>(request.FootballPositions))
                                                                         .ConfigureAwait(false);

        await _gameStylesRepository.ResetAsync(_mapper.Map<IEnumerable<GameStyle>>(request.GameStyles))
                                                            .ConfigureAwait(false);

        await _workingFootsRepository.ResetAsync(_mapper.Map<IEnumerable<WorkingFoot>>(request.WorkingFoots))
                                                                  .ConfigureAwait(false);

        await _statCategoriesRepository.ResetAsync(_mapper.Map<IEnumerable<StatCategory>>(request.StatCategories))
                                                                       .ConfigureAwait(false);

        await _statSkillsRepository.ResetAsync(_mapper.Map<IEnumerable<StatSkill>>(request.StatSkills))
                                                            .ConfigureAwait(false);

        await _statTypesRepository.ResetAsync(_mapper.Map<IEnumerable<StatType>>(request.StatTypes))
                                                         .ConfigureAwait(false);

        await PublishDataResetedEventAsync(cancellationToken).ConfigureAwait(false);
    }

    private Task PublishDataResetedEventAsync(CancellationToken cancellationToken)
    {
        DataResetedEvent @event = new();
        return _mediator.Publish(@event, cancellationToken);
    }
}
#endif

#if (!IncludePlayerInfrastructure && IncludeTeamInfrastructure)
  public class ResetDataCommandHandler(
    IMapper mapper,
    IMediator mediator,
    IShirtRepository shirtsRepository) : IRequestHandler<ResetDataCommand>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMediator _mediator = mediator;
    private readonly IShirtRepository _shirtsRepository = shirtsRepository;

    public async Task Handle(ResetDataCommand request, CancellationToken cancellationToken)
    {
        await _shirtsRepository.ResetAsync(_mapper.Map<IEnumerable<Shirt>>(request.Shirts))
                               .ConfigureAwait(false);

        await PublishDataResetedEventAsync(cancellationToken).ConfigureAwait(false);
    }

    private Task PublishDataResetedEventAsync(CancellationToken cancellationToken)
    {
        DataResetedEvent @event = new();
        return _mediator.Publish(@event, cancellationToken);
    }
}
#endif

#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)                                                           
public class ResetDataCommandHandler(
    IMapper mapper,
    IMediator mediator,
    IFootballPositionRepository positionsRepository,
    IGameStyleRepository gameStylesRepository,
    IStatCategoryRepository statCategoriesRepository,
    IStatSkillRepository statSkillsRepository,
    IStatTypeRepository statTypesRepository,
    IWorkingFootRepository workingFootsRepository,
    IShirtRepository shirtsRepository) : IRequestHandler<ResetDataCommand>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMediator _mediator = mediator;
    private readonly IFootballPositionRepository _positionsRepository = positionsRepository;
    private readonly IGameStyleRepository _gameStylesRepository = gameStylesRepository;
    private readonly IStatCategoryRepository _statCategoriesRepository = statCategoriesRepository;
    private readonly IStatSkillRepository _statSkillsRepository = statSkillsRepository;
    private readonly IStatTypeRepository _statTypesRepository = statTypesRepository;
    private readonly IWorkingFootRepository _workingFootsRepository = workingFootsRepository;
    private readonly IShirtRepository _shirtsRepository = shirtsRepository;

    public async Task Handle(ResetDataCommand request, CancellationToken cancellationToken)
    {
        await _positionsRepository.ResetAsync(_mapper.Map<IEnumerable<FootballPosition>>(request.FootballPositions))
                                                                         .ConfigureAwait(false);

        await _gameStylesRepository.ResetAsync(_mapper.Map<IEnumerable<GameStyle>>(request.GameStyles))
                                                            .ConfigureAwait(false);

        await _workingFootsRepository.ResetAsync(_mapper.Map<IEnumerable<WorkingFoot>>(request.WorkingFoots))
                                                                  .ConfigureAwait(false);

        await _statCategoriesRepository.ResetAsync(_mapper.Map<IEnumerable<StatCategory>>(request.StatCategories))
                                                                       .ConfigureAwait(false);

        await _statSkillsRepository.ResetAsync(_mapper.Map<IEnumerable<StatSkill>>(request.StatSkills))
                                                            .ConfigureAwait(false);

        await _statTypesRepository.ResetAsync(_mapper.Map<IEnumerable<StatType>>(request.StatTypes))
                                                         .ConfigureAwait(false);

        await _shirtsRepository.ResetAsync(_mapper.Map<IEnumerable<Shirt>>(request.Shirts))
                               .ConfigureAwait(false);

        await PublishDataResetedEventAsync(cancellationToken).ConfigureAwait(false);
    }

    private Task PublishDataResetedEventAsync(CancellationToken cancellationToken)
    {
        DataResetedEvent @event = new();
        return _mediator.Publish(@event, cancellationToken);
    }
}
#endif
#else
public class ResetDataCommandHandler(
    IMapper mapper,
    IMediator mediator) : IRequestHandler<ResetDataCommand>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMediator _mediator = mediator;

    public Task Handle(ResetDataCommand request, CancellationToken cancellationToken)
    {
        return PublishDataResetedEventAsync(cancellationToken);
    }

    private Task PublishDataResetedEventAsync(CancellationToken cancellationToken)
    {
        DataResetedEvent @event = new();
        return _mediator.Publish(@event, cancellationToken);
    }

}
#endif
