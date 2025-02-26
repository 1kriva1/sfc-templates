using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Get;

public class GetGeneralTemplateQuery : Request<GetGeneralTemplateViewModel>
{
    public override RequestId RequestId { get => RequestId.GetGeneralTemplate; }

    public long GeneralTemplateId { get; set; }
}
