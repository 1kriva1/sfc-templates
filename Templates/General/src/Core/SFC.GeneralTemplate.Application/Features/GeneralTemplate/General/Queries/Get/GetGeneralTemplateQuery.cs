using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Get;

public class GetGeneralTemplateQuery : Request<GetGeneralTemplateViewModel>
{
    public override RequestId RequestId { get => RequestId.GetGeneralTemplate; }

    public long Id { get; set; }
}
