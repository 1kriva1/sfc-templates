using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.GeneralTemplate.Api.Infrastructure.Extensions;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Find;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Get;
using SFC.GeneralTemplate.Contracts.Headers;
using SFC.GeneralTemplate.Contracts.Messages.Find;
using SFC.GeneralTemplate.Contracts.Messages.Get;
using SFC.GeneralTemplate.Infrastructure.Constants;

using static SFC.GeneralTemplate.Contracts.Services.GeneralTemplateService;

namespace SFC.GeneralTemplate.Api.Services;

[Authorize(Policy.General)]
public class GeneralTemplateService(IMapper mapper, ISender mediator) : GeneralTemplateServiceBase
{
    public override async Task<GetGeneralTemplateResponse> GetGeneralTemplate(GetGeneralTemplateRequest request, ServerCallContext context)
    {
        GetGeneralTemplateQuery query = mapper.Map<GetGeneralTemplateQuery>(request);

        GetGeneralTemplateViewModel model = await mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(mapper.Map<AuditableHeader>(model.GeneralTemplate));

        return mapper.Map<GetGeneralTemplateResponse>(model);
    }

    public override async Task<GetGeneralTemplatesResponse> GetGeneralTemplates(GetGeneralTemplatesRequest request, ServerCallContext context)
    {
        GetGeneralTemplatesQuery query = mapper.Map<GetGeneralTemplatesQuery>(request);

        GetGeneralTemplatesViewModel result = await mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(mapper.Map<PaginationHeader>(result.Metadata));

        return mapper.Map<GetGeneralTemplatesResponse>(result);
    }
}