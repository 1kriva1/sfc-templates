using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Find.Dto.Filters;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Find;
public class GetGeneralTemplateMultipleQuery : BasePaginationRequest<GetGeneralTemplateMultipleViewModel, GetGeneralTemplateMultipleFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetGeneralTemplates; }
}
