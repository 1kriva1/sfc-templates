using AutoMapper;

using MediatR;

using SFC.GeneralTemplate.Application.Common.Constants;
using SFC.GeneralTemplate.Application.Common.Exceptions;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.GeneralTemplate.General;
using SFC.GeneralTemplate.Domain.Events.GeneralTemplate;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Commands.Update;
public class UpdateGeneralTemplateCommandHandler(IMapper mapper, IGeneralTemplateRepository generalTemplateRepository)
    : IRequestHandler<UpdateGeneralTemplateCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGeneralTemplateRepository _generalTemplateRepository = generalTemplateRepository;

    public async Task Handle(UpdateGeneralTemplateCommand request, CancellationToken cancellationToken)
    {
        GeneralTemplateEntity generaltemplate = await _generalTemplateRepository.GetByIdAsync(request.GeneralTemplateId).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.GeneralTemplateNotFound);

        GeneralTemplateEntity updatedGeneralTemplate = _mapper.Map(request.GeneralTemplate, generaltemplate);

        updatedGeneralTemplate.AddDomainEvent(new GeneralTemplateUpdatedEvent(updatedGeneralTemplate));

        await _generalTemplateRepository.UpdateAsync(updatedGeneralTemplate)
                                        .ConfigureAwait(false);
    }
}
