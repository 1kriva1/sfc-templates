using AutoMapper;

using MediatR;

using SFC.GeneralTemplate.Domain.Events.Data;

namespace SFC.GeneralTemplate.Application.Features.Data.Commands.Reset;
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
