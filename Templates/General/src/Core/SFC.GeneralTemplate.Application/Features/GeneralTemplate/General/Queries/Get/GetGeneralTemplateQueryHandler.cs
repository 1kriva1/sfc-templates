using AutoMapper;

using MediatR;

using SFC.GeneralTemplate.Application.Common.Constants;
using SFC.GeneralTemplate.Application.Common.Exceptions;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.GeneralTemplate.General;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Get;
public class GetGeneralTemplateQueryHandler(IMapper mapper, IGeneralTemplateRepository generalTemplateRepository)
    : IRequestHandler<GetGeneralTemplateQuery, GetGeneralTemplateViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGeneralTemplateRepository _generalTemplateRepository = generalTemplateRepository;

    public async Task<GetGeneralTemplateViewModel> Handle(GetGeneralTemplateQuery request, CancellationToken cancellationToken)
    {
        GeneralTemplateEntity generaltemplate = await _generalTemplateRepository.GetByIdAsync(request.Id).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.GeneralTemplateNotFound);

        return _mapper.Map<GetGeneralTemplateViewModel>(generaltemplate);
    }
}
