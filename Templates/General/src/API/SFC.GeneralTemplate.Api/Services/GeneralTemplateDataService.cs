#if IncludeDataInfrastructure
using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Data.Queries.GetAll;
using SFC.GeneralTemplate.Contracts.Messages.GeneralTemplate.Data.GetAll;
using SFC.GeneralTemplate.Infrastructure.Constants;

using static SFC.GeneralTemplate.Contracts.Services.GeneralTemplateDataService;

namespace SFC.GeneralTemplate.Api.Services;

[Authorize(Policy.General)]
public class GeneralTemplateDataService(IMapper mapper, ISender mediator) : GeneralTemplateDataServiceBase
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;

    public override async Task<GetAllGeneralTemplateDataResponse> GetAll(GetAllGeneralTemplateDataRequest request, ServerCallContext context)
    {
        GetAllGeneralTemplateDataQuery query = new();

        GetAllGeneralTemplateDataViewModel model = await _mediator.Send(query).ConfigureAwait(true);

        return _mapper.Map<GetAllGeneralTemplateDataResponse>(model);
    }
}
#endif