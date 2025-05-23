using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.GeneralTemplate.Api.Infrastructure.Extensions;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Find;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Get;
using SFC.GeneralTemplate.Contracts.Headers;
using SFC.GeneralTemplate.Contracts.Messages.GeneralTemplate.General.Find;
using SFC.GeneralTemplate.Contracts.Messages.GeneralTemplate.General.Get;
using SFC.GeneralTemplate.Infrastructure.Constants;

using static SFC.GeneralTemplate.Contracts.Services.GeneralTemplateService;

namespace SFC.GeneralTemplate.Api.Services;

[Authorize(Policy.General)]
public class GeneralTemplateService(IMapper mapper, ISender mediator) : GeneralTemplateServiceBase
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;

    public override async Task<GetGeneralTemplateResponse> GetGeneralTemplate(GetGeneralTemplateRequest request, ServerCallContext context)
    {
        GetGeneralTemplateQuery query = _mapper.Map<GetGeneralTemplateQuery>(request);

        GetGeneralTemplateViewModel model = await _mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(_mapper.Map<AuditableHeader>(model.GeneralTemplate));

        return _mapper.Map<GetGeneralTemplateResponse>(model);
    }

    public override async Task<GetGeneralTemplateMultipleResponse> GetGeneralTemplateMultiple(GetGeneralTemplateMultipleRequest request, ServerCallContext context)
    {
        GetGeneralTemplateMultipleQuery query = _mapper.Map<GetGeneralTemplateMultipleQuery>(request);

        GetGeneralTemplateMultipleViewModel result = await _mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(_mapper.Map<PaginationHeader>(result.Metadata));

        return _mapper.Map<GetGeneralTemplateMultipleResponse>(result);
    }
}