#if IncludeDataInfrastructure
using AutoMapper;

using MediatR;
using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.Data;
using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.Data.Models;
using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Data.Queries.Common.Dto;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Data.Queries.GetAll;
public class GetAllGeneralTemplateDataQueryHandler(IMapper mapper, IGeneralTemplateDataService generalTemplateDataService)
    : IRequestHandler<GetAllGeneralTemplateDataQuery, GetAllGeneralTemplateDataViewModel>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IGeneralTemplateDataService _generalTemplateDataService = generalTemplateDataService;

    public async Task<GetAllGeneralTemplateDataViewModel> Handle(GetAllGeneralTemplateDataQuery request, CancellationToken cancellationToken)
    {
        GetAllGeneralTemplateDataModel model = await _generalTemplateDataService.GetAllGeneralTemplateDataAsync().ConfigureAwait(true);

        return new GetAllGeneralTemplateDataViewModel
        {
            
        };
    }
}
#endif