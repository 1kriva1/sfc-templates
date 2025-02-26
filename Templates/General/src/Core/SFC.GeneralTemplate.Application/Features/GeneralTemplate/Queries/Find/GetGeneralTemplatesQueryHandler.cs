using AutoMapper;

using MediatR;

using SFC.GeneralTemplate.Application.Features.Common.Dto.Pagination;
using SFC.GeneralTemplate.Application.Features.Common.Models.Find;
using SFC.GeneralTemplate.Application.Features.Common.Models.Find.Filters;
using SFC.GeneralTemplate.Application.Features.Common.Models.Find.Paging;
using SFC.GeneralTemplate.Application.Features.Common.Models.Find.Sorting;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Common.Dto;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Find.Extensions;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.GeneralTemplate;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Find;
public class GetGeneralTemplatesQueryHandler(
    IMapper mapper,
    IGeneralTemplateRepository generalTemplateRepository)
    : IRequestHandler<GetGeneralTemplatesQuery, GetGeneralTemplatesViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGeneralTemplateRepository _generalTemplateRepository = generalTemplateRepository;

    public async Task<GetGeneralTemplatesViewModel> Handle(GetGeneralTemplatesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Filter<GeneralTemplateEntity>> filters = request.Filter.BuildSearchFilters();

        IEnumerable<Sorting<GeneralTemplateEntity, dynamic>>? sorting = request.Sorting.BuildGeneralTemplateSearchSorting();

        FindParameters<GeneralTemplateEntity> parameters = new()
        {
            Pagination = _mapper.Map<Pagination>(request.Pagination),
            Filters = new Filters<GeneralTemplateEntity>(filters),
            Sorting = sorting != null
                ? new Sortings<GeneralTemplateEntity>(sorting)
                : new Sortings<GeneralTemplateEntity>()
        };

        PagedList<GeneralTemplateEntity> pageList = await _generalTemplateRepository
                                                             .FindAsync(parameters)
                                                             .ConfigureAwait(true);

        return new GetGeneralTemplatesViewModel
        {
            Items = _mapper.Map<IEnumerable<GeneralTemplateDto>>(pageList),
            Metadata = _mapper.Map<PageMetadataDto>(pageList)
        };
    }
}
