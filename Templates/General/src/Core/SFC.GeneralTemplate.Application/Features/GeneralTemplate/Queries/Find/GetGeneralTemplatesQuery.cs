using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Find.Dto.Filters;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Find;
public class GetGeneralTemplatesQuery : BasePaginationRequest<GetGeneralTemplatesViewModel, GetGeneralTemplatesFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetGeneralTemplates; }
}
