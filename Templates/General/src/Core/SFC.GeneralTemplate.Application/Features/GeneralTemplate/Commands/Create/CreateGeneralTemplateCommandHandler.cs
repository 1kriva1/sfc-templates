using AutoMapper;

using MediatR;

using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.GeneralTemplate;
using SFC.GeneralTemplate.Domain.Events.GeneralTemplate;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Commands.Create;
public class CreateGeneralTemplateCommandHandler(
    IMapper mapper,
    IGeneralTemplateRepository generalTemplateRepository)
    : IRequestHandler<CreateGeneralTemplateCommand, CreateGeneralTemplateViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGeneralTemplateRepository _generalTemplateRepository = generalTemplateRepository;

    public async Task<CreateGeneralTemplateViewModel> Handle(CreateGeneralTemplateCommand request, CancellationToken cancellationToken)
    {
        GeneralTemplateEntity generaltemplate = _mapper.Map<GeneralTemplateEntity>(request.GeneralTemplate);

        generaltemplate.AddDomainEvent(new GeneralTemplateCreatedEvent(generaltemplate));

        await _generalTemplateRepository.AddAsync(generaltemplate)
                             .ConfigureAwait(false);

        return _mapper.Map<CreateGeneralTemplateViewModel>(generaltemplate);
    }
}
